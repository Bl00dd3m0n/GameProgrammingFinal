using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crafting;
using CraftingLibrary.Items.Interfaces;
using CraftingLibrary.Recipes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using ShopGame.GameUI;
using ShopGameFinalProject.Managers;

namespace ShopGame.Pages
{
    class PageCanvas : Canvas
    {
        internal ItemsButtons[] items;
        internal List<Text> RecipeText;
        internal Button pressedButton;
        internal Button exitButton;
        string screentitle;
        public PageCanvas(Game game, string title) : base(game)
        {
            this.screentitle = title;
            RecipeText = new List<Text>();
            exitButton = new Button(game,"Exit");
            enabled = true;
        }
        public void SetUpCanvas()
        {
            this.Components.AddRange(RecipeText);
            this.Components.Add(pressedButton);
            this.Components.AddRange(items);
            this.enabled = true;
        }
        protected void AddEssentials()
        {
            Vector2 corner = new Vector2(Game.GraphicsDevice.Viewport.Width - exitButton.buttonText.TextPositions("Exit").X - 10, 0);
            exitButton.CreateButton("Exit", corner, Color.Red, Color.Black);
            this.Components.Add(exitButton);
            Text title = new Text(Game);
            title.SetTextValues($"{screentitle}", new Vector2(this.GraphicsDevice.Viewport.Width / 2, 0), Color.White);
            title.enabled = true;
            this.Components.Add(title);
        }
        public virtual void CreateButtons(Inventory someInventory)
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new ItemsButtons(Game, someInventory.GetInventory()[i]);
                items[i].Initialize();
                items[i].CreateButton(items[i].item.Name, items[i].position, Color.Magenta, Color.Black);
                this.Components.Add(items[i]);
            }
        }
        public virtual void ButtonListener(Button button, Button.Action buttonClicked, ShopKeeper player)
        {
            if (player.CursorDown)
            {
                if (button.Contains(player.CursorPosition.ToPoint()))
                {
                    buttonClicked();
                }
            }
        }
        internal virtual void SetButtons(Inventory someInventory)
        {
            AddEssentials();
            items = new ItemsButtons[someInventory.GetInventory().Count];
        }
        public bool TextWithColorCode(Recipe recipe)
        {
            foreach (Text text in RecipeText)
            {
                this.Components.Remove(text);
            }
            this.RecipeText.Clear();
            foreach (var text in recipe.RecipeItems)
            {
                int wordCount = 0;
                string[] words = new string[4];//RGB values + text
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != ',')
                    {
                        words[wordCount] += text[i];
                    }
                    else
                    {
                        wordCount++;
                    }
                }
                Color color = new Color(Convert.ToUInt32(words[0]), Convert.ToUInt32(words[1]), Convert.ToUInt32(words[2]));
                string ActualText = words[3];
                Text newText = new Text(Game);
                newText.SetTextValues(ActualText, new Vector2(this.GraphicsDevice.Viewport.Width / 4, (this.GraphicsDevice.Viewport.Height - (this.GraphicsDevice.Viewport.Height * 0.92f)) + newText.TextPositions(ActualText).Y * recipe.RecipeItems.IndexOf(text)), color);
                newText.Initialize();
                newText.enabled = true;
                this.RecipeText.Add(newText);
            }
            this.Components.AddRange(RecipeText);
            return true;
        }
    }
    class MonoGamePage : GameScreen
    {
        protected float wordspacing;
        protected float marginx;
        protected float marginy;
        protected bool RenderRecipe;
        protected ScreenManager screen;
        protected PageCanvas canvas;
        protected Inventory someInventory;
        protected bool CraftablePage;
        Button.Action ButtonPress;
        protected Recipe recipe;

        protected bool RecipeLoaded;
        public MonoGamePage(Game game, ShopKeeper player) : base(game, player)
        {
            this.CraftablePage = false;
            this.Rotate = 0;
            this.game = game;
            this.Direction = new Vector2(0, 0);
            this.player = player;
            someInventory = player.inventory;
        }
        public virtual void SetUpCanvas()
        {
            canvas = new PageCanvas(game, this.GetType().Name);
            canvas.Initialize();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, new Rectangle((int)this.Location.X, (int)this.Location.Y, (int)this.Texture.Width, (int)this.Texture.Height), null, Color.White, MathHelper.ToRadians(Rotate), new Vector2(0, 0), SpriteEffects.None, 0);
        }
        public virtual void SetButtons()
        {
            canvas.SetButtons(someInventory);
        }

        public virtual void CreateButtons()
        {
            canvas.CreateButtons(someInventory);
        }
        public void ExitScene()
        {
            player.CloseScene();
        }

        public override void Draw(GameTime gameTime)
        {

            sb.Begin();
            for (int i = 0; i < canvas.Components.Count; i++)
            {

                //TODO add recipe for inventory items
                //if (items[i].item.GetType().GetInterface("ICraftable") != null)
                //{
                //    recipe = ((ICraftable)items[i].item).itemRecipe;
                //}//This resets recipe for the crafting menus don't do this.
                if (canvas.Components[i] is Button)
                {
                    if (((Button)canvas.Components[i]).buttonText.text == "Exit") ButtonPress = ExitScene;
                    else ButtonPress = Nothing;
                    canvas.ButtonListener(((Button)canvas.Components[i]), ButtonPress, player);
                }
                if (canvas.Components[i].GetType() == typeof(ItemsButtons))
                {
                    canvas.Components[i].position = new Vector2(marginx, (i + 1) * (((ItemsButtons)canvas.Components[i]).bounds.Height + marginy));//NOTE Since crafted items at the moment are only one object type using [0] should be fine, however, if you can craft multiple things possibly change this
                    ((ItemsButtons)canvas.Components[i]).UpdateBoundaries(canvas.Components[i].position);
                }
            }
            if (recipe != null)
            {
                DrawRecipe(gameTime, recipe);
            }
            sb.End();

            base.Draw(gameTime);
            canvas.Draw(gameTime, sb);
        }
        public void Nothing()
        {

        }
        protected override void LoadContent()
        {
            base.LoadContent();
            if (string.IsNullOrEmpty(TextureName))
                TextureName = "CraftingPage";
            Texture = game.Content.Load<Texture2D>(TextureName);
            wordspacing = 20;
            marginx = Texture.Width / 90;
            marginy = 20;
            SetUpCanvas();
            SetButtons();
            CreateButtons();
        }
        protected virtual void NewButton(GameTime gameTime)
        {
        
        }

        protected virtual void DrawRecipe(GameTime gameTime, Recipe recipe)
        {
            if (RenderRecipe)
            {
                if (!RecipeLoaded) {
                    RecipeLoaded = canvas.TextWithColorCode(recipe);
                }
            }
        }
    }
}


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
        public bool CheckButton;
        public Point PositionCheck;
        public ItemsButtons selectedItem;
        internal List<Component> DisplayableComponents;
        public PageCanvas(Game game, string title) : base(game)
        {
            CheckButton = false;
            DisplayableComponents = new List<Component>();
        }

        public virtual Text AddText(string text, Vector2 position, Color color)
        {
            Text newText = new Text(Game);
            newText.SetTextValues(text, position, color);
            newText.enabled = true;
            this.Components.Add(newText);
            return newText;
        }

        public virtual Text AddTextWithColorCode(string text, Vector2 position)
        {
            Text newText = new Text(Game);
            string[] textWithColor = new string[4];
            int a = 0;
            for(int i = 0; i < text.Length;i++)
            {
                if(text[i] == ',')
                {
                    a++;
                } else
                {
                    textWithColor[a] += text[i];
                }
            }

            newText.SetTextValues(textWithColor[3], position, new Color(int.Parse(textWithColor[0]), int.Parse(textWithColor[1]),int.Parse(textWithColor[2])));
            newText.enabled = true;
            this.Components.Add(newText);
            return newText;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (CheckButton)
            {
                foreach (Component component in Components)
                {
                    if (component is Button)
                    {
                        Button button = (Button)component;
                        if (button.Contains(PositionCheck))
                        {
                            if (button.GetType() == typeof(ItemsButtons))
                            {
                                DisplayValues((ItemsButtons)button);
                                selectedItem = (ItemsButtons)button;
                            }
                            else if (button.GetType() == typeof(RecipeButtons))
                            {
                                selectedItem = (RecipeButtons)button;
                                button.delegatedMethod();
                            }
                            else
                                button.delegatedMethod();
                            CheckButton = false;
                            break;
                        }
                    }
                }
            }
            base.Draw(gameTime, spriteBatch);
        }
        public virtual void DisplayValues(ItemsButtons button)
        {
            List<Component> temp = Components.Where(x => x.GetType() == typeof(Text)).ToList();
            foreach (var item in temp)
            {
                Components.Remove(item);
            }
            temp.Clear();
            selectedItem = button;
            AddText($"Name: {button.item.Name}", new Vector2(this.GraphicsDevice.Viewport.Width / 4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), Color.Black);
            AddText($"Price: {button.item.Price}", new Vector2(this.GraphicsDevice.Viewport.Width / 4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), Color.Black);
        }

        public virtual Button AddButton(IItem item, float price, Vector2 position)
        {
            item.Price = price;
            ItemsButtons itemButton = new ItemsButtons(Game, item);
            itemButton.CreateButton(item.Name, position, Color.Magenta, Color.Black);
            this.Components.Add(itemButton);
            return itemButton;
        }
        public virtual Button AddButton(string Message, Vector2 position, Button.Action Event, Color color)
        {
            Button itemButton = new Button(Game, Message);
            itemButton.CreateButton(Message, position, color, Color.Black);
            this.Components.Add(itemButton);
            itemButton.delegatedMethod = Event;
            return itemButton;
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
            RenderRecipe = true;
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
        public virtual void CreateButtons()
        {
            if (canvas.Components.Count <= 0)
            {
                foreach (var item in someInventory.GetInventory())
                {
                    canvas.AddButton(item, item.Price, new Vector2(this.GraphicsDevice.Viewport.Width / 100, 50 + someInventory.GetInventory().IndexOf(item) * 20));
                }
            }
             canvas.AddButton("Exit", new Vector2(this.GraphicsDevice.Viewport.Width - 50, 0), ExitScene, Color.Red);
        }
        public void ExitScene()
        {
            player.CloseScene();
        }

        public override void Draw(GameTime gameTime)
        {

            sb.Begin();
            if (player.CursorDown)
            {
                canvas.CheckButton = true;
                canvas.PositionCheck = player.CursorPosition.ToPoint();
            }
            if (recipe != null)
            {
                DrawRecipe(gameTime, recipe);
            }
            sb.End();

            base.Draw(gameTime);
            canvas.Draw(gameTime, sb);
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
            CreateButtons();
        }

        protected virtual void DrawRecipe(GameTime gameTime, Recipe recipe)
        {
            if (RenderRecipe)
            {
                if (!RecipeLoaded) {
                    foreach(var component in canvas.DisplayableComponents)
                    {
                        canvas.Components.Remove(component);
                    }
                    canvas.DisplayableComponents.Clear();
                    foreach(var textrecipe in recipe.RecipeItems)
                    {
                        canvas.DisplayableComponents.Add(canvas.AddTextWithColorCode(textrecipe,new Vector2(this.GraphicsDevice.Viewport.Width/4,50+(recipe.RecipeItems.IndexOf(textrecipe)*20))));
                    }
                }
                RenderRecipe = false;
                RecipeLoaded = true;
            }
        }
    }
}


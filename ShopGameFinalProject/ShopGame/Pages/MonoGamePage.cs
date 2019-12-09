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
using ShopGame.Pages.CanvasPages;
using ShopGameFinalProject.Managers;

namespace ShopGame.Pages
{
 
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
            if (this.GetType() == typeof(MonoGameInventory))
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


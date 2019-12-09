using Crafting;
using CraftingLibrary.CraftingSystem;
using CraftingLibrary.Items.Interfaces;
using CraftingLibrary.Recipes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using ShopGame.GameUI;
using ShopGameFinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Pages
{
    class CraftingCanvas : PageCanvas
    {
        
        public CraftingCanvas(Game game, string title) : base(game, title)
        {
        }
        public Button AddButton(IItem item, Button.Action action, Vector2 position)
        {
            RecipeButtons rb = new RecipeButtons(Game, item, ((ICraftable)item).itemRecipe);
            rb.CreateButton(item.Name, position, Color.Magenta, Color.Black);
            Components.Add(rb);
            rb.delegatedMethod = action;
            return rb;
        }
    }
    class MonoGameCrafting : MonoGamePage
    {
        protected TemplateCraftingSystem crafting;
        Button craft;
        Button.Action action;//CraftItem
        float ButtonPressedtimer;
        GameTime gt;
        public MonoGameCrafting(Game game, ShopKeeper player) : base(game,player)
        {
            this.CraftablePage = true;
            this.ButtonPressedtimer = 0;
            SetUpCanvas();
        }

        public override void SetUpCanvas()
        {
            canvas = new CraftingCanvas(game, this.GetType().Name);
            canvas.Initialize();
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void CreateButtons()
        {
            foreach(var button in crafting.SystemRecipes)
            {
                ((CraftingCanvas)canvas).AddButton(button.craftedItems.GetInventory().FirstOrDefault(), SetRecipe,new Vector2(this.GraphicsDevice.Viewport.Width / 100, 50 + crafting.SystemRecipes.IndexOf(button) * 20));
            }
            base.CreateButtons();
        }
        public override void Update(GameTime gameTime)
        {

            ButtonPressedtimer += gameTime.ElapsedGameTime.Milliseconds;
            if (ButtonPressedtimer < 2)
            {
                if (canvas.selectedItem.pressed)
                {
                    canvas.selectedItem.ButtonReleased();
                }
            }
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            CreateButtons();
            action = CraftItem;
        }
        protected void NewButton(GameTime gameTime)
        {
            craft = new Button(Game, "Craft");
            craft.Initialize();
            craft.CreateButton("Craft", new Vector2(this.GraphicsDevice.Viewport.Width/4, 100 + recipe.RecipeItems.Count() * 15), Color.White, Color.Black);
            craft.Draw(sb);
            craft.delegatedMethod = CraftItem;
            canvas.DisplayableComponents.Add(craft);
            canvas.Components.Add(craft);
        }

        internal void CraftItem()
        {
            player.inventory.Add(crafting.Craft(recipe));
            RecipeLoaded = false;
            RenderRecipe = true;
        }

        public void SetRecipe()
        {
            if(this.canvas.selectedItem is RecipeButtons)
            {
                recipe = ((RecipeButtons)canvas.selectedItem).recipe;
                RecipeLoaded = false;
                RenderRecipe = true;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            gt = gameTime;

            if (recipe != null)
            {
                if (!RecipeLoaded)
                {
                    foreach(var component in canvas.DisplayableComponents)
                    {
                        canvas.Components.Remove(component);
                    }
                    recipe.LoadRecipe(true,player.inventory);
                    DrawRecipe(gameTime, recipe);
                    NewButton(gameTime);
                    RecipeLoaded = true;
                }
            }
            sb.End();
            base.Draw(gameTime);
            canvas.Draw(gameTime, sb);
        }
    }
}

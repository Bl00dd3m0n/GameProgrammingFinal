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
        public void CreateButtons(Inventory someInventory, TemplateCraftingSystem crafting)
        {
            AddEssentials();
            for (int i = 0; i < items.Length; i++)
            {
                this.items[i] = new RecipeButtons(Game, crafting.SystemRecipes[i].craftedItems.GetInventory()[0], crafting.SystemRecipes[i]);
                this.items[i].enabled = true;
                this.Components.Add(items[i]);
            }
        }
        internal void SetButtons(TemplateCraftingSystem crafting)
        {
            this.items = new RecipeButtons[crafting.SystemRecipes.Count()];
        }
        internal bool ButtonListeners(Button button,TemplateCraftingSystem crafting, ShopKeeper player, Recipe recipe)
        {
            if (player.CursorDown)
            {
                if (button.Contains(player.CursorPosition.ToPoint()))
                {
                    if (button.GetType() == typeof(RecipeButtons) && recipe != ((RecipeButtons)button).recipe)
                    {

                        recipe = ((RecipeButtons)button).recipe;
                        recipe.LoadRecipe(true, recipe.ItemsNeeded);

                        button.Buttonpressed();
                        this.pressedButton = button;

                        return true;
                    }

                    else if (button.GetType() != typeof(RecipeButtons))
                    {
                        button.Buttonpressed();
                        pressedButton = button;
                        if (button.delegatedMethod != null)
                        {
                            button.delegatedMethod();
                        }
                        return false;
                    }
                }
            }
            return false;
        }
        internal void ClickedRecipeButton(RecipeButtons.GetRecipe ChangedRecipe, int i, Recipe recipe, Point playercursor,Inventory someInventory)
        {

            ChangedRecipe();
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
        public override void SetButtons()
        {
            if (canvas.GetType() == typeof(CraftingCanvas))
                ((CraftingCanvas)canvas).SetButtons(crafting);
            else
                canvas.SetButtons(someInventory);
        }
        public override void CreateButtons()
        {
            if (canvas.GetType() == typeof(CraftingCanvas))
                ((CraftingCanvas)canvas).CreateButtons(someInventory, crafting);
            else
                canvas.CreateButtons(someInventory);
        }
        public override void Update(GameTime gameTime)
        {

            ButtonPressedtimer += gameTime.ElapsedGameTime.Milliseconds;
            if (ButtonPressedtimer < 2)
            {
                if (canvas.pressedButton.pressed)
                {
                    canvas.pressedButton.ButtonReleased();
                }
            }
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            SetButtons();
            CreateButtons();
            action = CraftItem;
        }
        protected override void NewButton(GameTime gameTime)
        {
            canvas.Components.Remove(craft);
            craft = new Button(Game, "Craft");
            craft.Initialize();
            craft.CreateButton("Craft", new Vector2(500, 100 + recipe.RecipeItems.Count() * 15), Color.White, Color.Black);
            craft.Draw(sb);
            craft.delegatedMethod = CraftItem;
            canvas.Components.Add(craft);
        }

        internal void CraftItem()
        {
            player.inventory.Add(crafting.Craft(recipe));
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            gt = gameTime;
            for (int i = 0; i < canvas.Components.Count; i++)
            {

                if (canvas.Components[i] is Button)
                {
                    if (canvas.Components[i] is RecipeButtons)
                    {
                        canvas.Components[i].position = new Vector2(marginx, (i) * (((Button)canvas.Components[i]).bounds.Height + marginy));//NOTE Since crafted items at the moment are only one object type using [0] should be fine, however, if you can craft multiple things possibly change this
                        ((Button)canvas.Components[i]).UpdateBoundaries(canvas.Components[i].position);
                    }
                    if (((CraftingCanvas)canvas).ButtonListeners((Button)canvas.Components[i], crafting, player, recipe))
                    {
                        recipe = ((RecipeButtons)canvas.Components[i]).recipe;
                        recipe.LoadRecipe(true,player.inventory);
                        RenderRecipe = true;
                        RecipeLoaded = false;
                    }
                } else
                {
                    canvas.Components[i].position = new Vector2(500, 100);
                }
            }
            if (recipe != null)
            {
                if (!RecipeLoaded)
                {
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

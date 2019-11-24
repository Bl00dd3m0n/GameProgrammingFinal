using Crafting;
using CraftingLibrary.CraftingSystem;
using CraftingLibrary.Items.Interfaces.Final_Items;
using CraftingLibrary.Recipes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Util;
using ShopGame.GameSceneObjects;
using ShopGameFinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Pages
{
    class MonoGameCrafting : MonoGamePage
    {

        protected delegate void Craft();
        protected Recipe recipe;
        protected TemplateCraftingSystem crafting;
        Button craft;
        Button.ReturnInventory action;//CraftItem
        Button pressedButton;
        float ButtonPressedtimer;
        public MonoGameCrafting(Game game, ShopKeeper player, ScreenManager screen) : base(game,player)
        {
            this.CraftablePage = true;
            this.screen = screen;

            this.ButtonPressedtimer = 0;
        }

        protected void SetButtons()
        {
            items = new RecipeButtons[crafting.SystemRecipes.Count()];
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void CreateButtons()
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new RecipeButtons(Game, crafting.SystemRecipes[i].craftedItems.GetInventory()[0], crafting.SystemRecipes[i]);
                items[i].Initialize();
            }
        }
        public override void Update(GameTime gameTime)
        {
            ButtonPressedtimer += gameTime.ElapsedGameTime.Milliseconds;
            if (ButtonPressedtimer < 2)
            {
                if (pressedButton.pressed)
                {
                    pressedButton.ButtonReleased();
                }
            }
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            action = CraftItem;
        }
        protected override void NewButton(GameTime gameTime)
        {
            craft = new Button(Game);
            craft.Initialize();
            craft.Draw(gameTime, sb, font, "Craft", new Vector2(500, 100 + recipe.RecipeItems.Count() * font.MeasureString(recipe.RecipeItems[0]).Y), Color.White);
        }


        Inventory CraftItem()
        {
            return crafting.Craft(recipe);
        }

        
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            this.Draw(sb);
            for (int i = 0; i < crafting.SystemRecipes.Count(); i++)
            {
                if (player.CursorDown)
                {
                    if (items[i].Contains(player.CursorPosition.ToPoint()))
                    {
                        recipe = ((RecipeButtons)items[i]).recipe;
                        crafting.LoadRecipe(recipe, true);
                        RenderRecipe = true;
                        items[i].Buttonpressed();
                        pressedButton = items[i];
                    }
                    else if (craft != null && action != null)
                    {
                        if (craft.Contains(player.CursorPosition.ToPoint()))
                        {
                            craft.Buttonpressed();
                            pressedButton = craft;
                            action();
                        }
                    }
                }
                items[i].Draw(gameTime, sb, font, crafting.SystemRecipes[i].craftedItems.GetInventory()[0].Name, new Vector2(marginx, i * items[i].bounds.Height + marginy));//NOTE Since crafted items at the moment are only one object type using [0] should be fine, however, if you can craft multiple things possibly change this
            }
            if (recipe != null)
            {
                DrawRecipe(gameTime, recipe);
            }
            sb.End();
        }
    }
}

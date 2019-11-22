using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crafting.CraftingSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGameFinalProject.Managers;

namespace ShopGame.Crafting_Pages
{
    class MonogameCraftingTable : MonoGameCrafting
    {
        CraftingTable crafting;
        SpriteBatch spriteBatch;
        ScreenManager screen;
        bool RenderRecipe;
        public MonogameCraftingTable(Game game, ShopKeeper player, SpriteBatch sb, ScreenManager screen) : base(game,player, screen)
        {
            this.screen = screen;
            crafting = new CraftingTable(player.inventory);
            Recipes = new RecipeMenuButton[crafting.SystemRecipes.Count];
            this.spriteBatch = sb;
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            CreateButtons();
        }
        void DrawRecipe()
        {
            if (RenderRecipe)
            {
                foreach (string text in crafting.RecipeItems)
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
                    sb.DrawString(font, ActualText, new Vector2(500, 100 + crafting.RecipeItems.IndexOf(text) * 10), color);
                }
            }
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            for (int i = 0; i < crafting.SystemRecipes.Count(); i++)
            {
                Recipes[i].Draw(gameTime,spriteBatch,font,crafting.SystemRecipes[i].craftedItem.Name, new Vector2(marginx, i * Recipes[i].bounds.Height + marginy));
                if (screen.CursorDown)
                {
                    if (Recipes[i].Contains(screen.CursorPosition.ToPoint()))
                    {
                        crafting.LoadRecipe(Recipes[i].recipe,true);
                        RenderRecipe = true;
                    }
                }
            }
            DrawRecipe();
            sb.End();

        }
    }
}

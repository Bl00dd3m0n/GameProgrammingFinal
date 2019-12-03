using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftingLibrary.CraftingSystem;
using CraftingLibrary.Items.Interfaces;
using CraftingLibrary.Recipes;
using Microsoft.Xna.Framework;
using ShopGame.Pages;

namespace ShopGame.GameSceneObjects
{
    class RecipeButtons : ItemsButtons
    {
        public Recipe recipe;
        public delegate Recipe GetRecipe();
        public RecipeButtons(Game game, IItem item, Recipe recipe) : base(game,item)
        {
            this.item = item;
            this.recipe = recipe;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftingLibrary.CraftingSystem;
using CraftingLibrary.Items.Interfaces.Final_Items;
using CraftingLibrary.Recipes;
using Microsoft.Xna.Framework;
using ShopGame.Pages;

namespace ShopGame.GameSceneObjects
{
    class RecipeButtons : ItemsButtons
    {
        public Recipe recipe;
        public RecipeButtons(Game game, IItem item, Recipe recipe) : base(game,item)
        {
            this.item = item;
            this.recipe = recipe;
        }
    }
}

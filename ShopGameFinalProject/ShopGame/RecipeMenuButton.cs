using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crafting.Recipes;
using Microsoft.Xna.Framework;

namespace ShopGame
{
    class RecipeMenuButton : Button
    {
        public Recipe recipe;
        public RecipeMenuButton(Game game, Recipe recipe) : base(game)
        {
            this.recipe = recipe;
        }
    }
}

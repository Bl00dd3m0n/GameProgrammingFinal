using CraftingLibrary.Items.Interfaces;
using Microsoft.Xna.Framework;
using ShopGame.GameSceneObjects;
using ShopGame.GameUI;
using ShopGame.Pages;
using ShopGame.Pages.CanvasPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame
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
}

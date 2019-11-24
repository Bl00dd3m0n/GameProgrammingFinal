using Crafting;
using CraftingLibrary.Recipes;
using CraftingLibrary.Recipes.Carpentry_Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingLibrary.CraftingSystem
{
    public class CarpentryStation : TemplateCraftingSystem
    {
        public CarpentryStation(Inventory currentInventory) : base(currentInventory)
        {
            this.currentInventory = currentInventory;
            CurrentRecipe = null;//May not be anything....If the case should just be an empty screen
            SystemRecipes = new List<Recipe>() { new HandleRecipe() };
        }

        public override Inventory Craft(Recipe recipe)
        {
            return base.Craft(recipe);
        }

        public override bool LoadRecipe(Recipe recipe, bool DisplayRecipes)
        {
            return base.LoadRecipe(recipe, DisplayRecipes);
        }
    }
}

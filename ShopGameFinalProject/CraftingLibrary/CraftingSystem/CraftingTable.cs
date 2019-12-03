using Crafting;
using Crafting.Items;
using CraftingLibrary.CraftingSystem;
using CraftingLibrary.Items.Interfaces;
using CraftingLibrary.Recipes;
using CraftingLibrary.Recipes.Crafting_Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crafting.CraftingSystem
{
    public class CraftingTable : TemplateCraftingSystem
    {
        public CraftingTable(Inventory currentInventory) : base(currentInventory)
        {
            this.currentInventory = currentInventory;
            CurrentRecipe = null;//May not be anything....If the case should just be an empty screen
            SystemRecipes = new List<Recipe>() { new SwordRecipe(), new BowRecipe() };
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

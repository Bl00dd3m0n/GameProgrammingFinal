using Crafting;
using Crafting.Items;
using CraftingLibrary.Items.Interfaces.Final_Items;
using CraftingLibrary.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingLibrary.CraftingSystem
{
    public abstract class TemplateCraftingSystem
    {
        public List<Recipe> SystemRecipes { get; set; }
        protected Recipe CurrentRecipe { get; set; }
        protected Inventory currentInventory;
        protected bool canCraft;

        public TemplateCraftingSystem(Inventory currentInventory)
        {
            this.currentInventory = currentInventory;
        }
        public virtual Inventory Craft(Recipe recipe)
        {
            if (LoadRecipe(recipe, false))
            {
                currentInventory.Remove(recipe.ItemsNeeded.GetInventory());
                return recipe.craftedItems;
            }
            return new Inventory(0);
        }
        public virtual bool LoadRecipe(Recipe recipe, bool DisplayRecipes)
        {
            CurrentRecipe = recipe;
            return recipe.LoadRecipe(DisplayRecipes,currentInventory);
        }
    }
}

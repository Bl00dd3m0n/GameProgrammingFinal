using Crafting.Items;
using CraftingLibrary.Items.CraftingMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingLibrary.Recipes.Furnace
{
    class BladeRecipe : Recipe
    {
        public BladeRecipe()
        {
            craftedItems.Add(new Blade());
            itemsNeeded.Add(new Iron_Ore(), 3);
        }
    }
}

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
            Blade CreatedBlade = new Blade();
            CreatedBlade.itemRecipe = this;
            craftedItems.Add(CreatedBlade);
            itemsNeeded.Add(new Iron_Ore(), 3);
        }
    }
}

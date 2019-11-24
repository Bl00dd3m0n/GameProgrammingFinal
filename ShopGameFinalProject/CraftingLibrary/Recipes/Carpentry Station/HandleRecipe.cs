using Crafting;
using Crafting.Items;
using CraftingLibrary.Items.CraftingMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingLibrary.Recipes.Carpentry_Station
{
    class HandleRecipe : Recipe 
    {
        public HandleRecipe()
        {
            Handle CreatedHandle = new Handle();
            CreatedHandle.itemRecipe = this;
            craftedItems.Add(CreatedHandle,2);
            itemsNeeded.Add(new Logs(), 1);
        }
    }
}

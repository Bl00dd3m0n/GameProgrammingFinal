using Crafting;
using Crafting.Items;
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
            craftedItems.Add(new Handle(),2);
            itemsNeeded.Add(new Handle(), 1);
        }
    }
}

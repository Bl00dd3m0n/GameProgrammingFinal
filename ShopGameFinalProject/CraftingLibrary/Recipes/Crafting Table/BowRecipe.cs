using Crafting;
using Crafting.Items;
using CraftingLibrary.Items.Final_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingLibrary.Recipes.Crafting_Table
{
    class BowRecipe : Recipe
    {
        public BowRecipe()
        {
            Bow createdBow = new Bow();
            itemsNeeded.Add(new Handle(),3);
            createdBow.itemRecipe = this;
            craftedItems.Add(createdBow);
        }
    }
}

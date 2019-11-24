using Crafting;
using Crafting.Items;
using CraftingLibrary.Final_Items.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingLibrary.Recipes
{
    public class SwordRecipe : Recipe
    {
        public SwordRecipe()
        {
            craftedItems.Add(new Sword());
            itemsNeeded.Add(new Blade(),2);
            itemsNeeded.Add(new Handle());
        }
    }
}

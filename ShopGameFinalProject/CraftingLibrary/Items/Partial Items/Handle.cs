using CraftingLibrary.Items.Interfaces.Final_Items;
using CraftingLibrary.Recipes;
using CraftingLibrary.Recipes.Carpentry_Station;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crafting.Items
{
    public class Handle : IItem, ICraftable
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public Recipe itemRecipe { get; set; }

        public Handle()
        {
            Name = this.GetType().Name;
        }
    }
}

using CraftingLibrary.Items.Interfaces;
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

        public float Price { get; set; }

        public Recipe itemRecipe { get; set; }

        public Handle()
        {
            Name = this.GetType().Name;
        }
    }
}

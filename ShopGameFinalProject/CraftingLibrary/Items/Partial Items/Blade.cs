using CraftingLibrary.Items.Interfaces;
using CraftingLibrary.Recipes;
using CraftingLibrary.Recipes.Furnace;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crafting.Items
{
    public class Blade : IItem , ICraftable
    {
        public string Name { get; set; }

        public float Price { get; set; }
        public Recipe itemRecipe { get; set; }

        public Blade()
        {
            Name = this.GetType().Name;
        }
    }
}

using CraftingLibrary.Items.Interfaces.Final_Items;
using CraftingLibrary.Recipes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftingLibrary.Final_Items.Items
{
    class Sword : IItem, ICraftable
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public Recipe itemRecipe { get; set; }

        public Sword()
        {
            Name = this.GetType().Name;
        }
    }
}

using CraftingLibrary.Items.Interfaces.Final_Items;
using CraftingLibrary.Recipes;
using CraftingLibrary.Recipes.Crafting_Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingLibrary.Items.Final_Items
{
    internal class Bow : IItem, ICraftable
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public Recipe itemRecipe { get; set; }

        public Bow()
        {
            Name = this.GetType().Name;
        }
    }
}

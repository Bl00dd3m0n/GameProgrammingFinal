using CraftingLibrary.Items.Interfaces;
using CraftingLibrary.Recipes;
using CraftingLibrary.Recipes.Crafting_Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingLibrary.Items.Final_Items
{
    public class Bow : IItem, ICraftable
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public Recipe itemRecipe { get; set; }

        public Bow()
        {
            Name = this.GetType().Name;
        }
    }
}

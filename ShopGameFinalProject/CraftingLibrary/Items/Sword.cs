using Crafting.Recipes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crafting.Items
{
    public class Sword : IItem, ICraftable
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        public List<IItem> itemRecipe { get; set; }

        public Sword()
        {
            Name = this.GetType().Name;
        }
    }
}

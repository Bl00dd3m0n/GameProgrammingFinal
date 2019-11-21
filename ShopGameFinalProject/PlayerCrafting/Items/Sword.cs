using Crafting.Recipes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crafting.Items
{
    public class Sword : IItem, ICraftable
    {
        public int Name { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        public List<IItem> itemRecipe { get; set; }

        public Sword()
        {

        }
    }
}

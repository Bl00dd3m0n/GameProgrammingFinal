using System;
using System.Collections.Generic;
using System.Text;

namespace Crafting.Items
{
    public class Blade : IItem
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }
        public Blade()
        {
            Name = this.GetType().Name;
        }
    }
}

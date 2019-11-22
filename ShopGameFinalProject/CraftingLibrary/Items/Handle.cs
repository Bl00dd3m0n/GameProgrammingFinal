using System;
using System.Collections.Generic;
using System.Text;

namespace Crafting.Items
{
    public class Handle : IItem
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        public Handle()
        {
            Name = this.GetType().Name;
        }
    }
}

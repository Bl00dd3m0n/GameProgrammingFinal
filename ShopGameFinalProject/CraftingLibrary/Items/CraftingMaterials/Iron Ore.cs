using CraftingLibrary.Items.Interfaces.Final_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingLibrary.Items.CraftingMaterials
{
    class Iron_Ore : IItem
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public Iron_Ore()
        {
            Name = this.GetType().Name;
        }
    }
}

using CraftingLibrary.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingLibrary.Items.CraftingMaterials
{
    public class Iron_Ore : IItem
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public Iron_Ore()
        {
            Name = this.GetType().Name;
        }
    }
}

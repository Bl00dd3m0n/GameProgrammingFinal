using CraftingLibrary.Items.Interfaces.Final_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingLibrary.Items.CraftingMaterials
{
    public class Logs : IItem
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public Logs()
        {
            Name = this.GetType().Name;
        }
    }
}

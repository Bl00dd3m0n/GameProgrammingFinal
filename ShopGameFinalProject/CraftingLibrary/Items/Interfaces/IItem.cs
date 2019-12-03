using System;
using System.Collections.Generic;
using System.Text;

namespace CraftingLibrary.Items.Interfaces
{
    public interface IItem
    {
        string Name { get; }
        float Price { get; set; }
    }
}

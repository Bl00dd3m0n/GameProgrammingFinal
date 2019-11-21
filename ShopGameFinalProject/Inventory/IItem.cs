using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    interface IItem
    {
        int Name { get; }
        int Price { get; }
        List<IItem> Recipes;
    }
}

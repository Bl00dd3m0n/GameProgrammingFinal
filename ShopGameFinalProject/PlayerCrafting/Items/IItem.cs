using System;
using System.Collections.Generic;
using System.Text;

namespace Crafting
{
    public interface IItem
    {
        int Name { get; }
        int Price { get; }
        int Count { get; } 
    }
}

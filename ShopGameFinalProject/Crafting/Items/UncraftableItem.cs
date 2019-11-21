using System;
using System.Collections.Generic;
using System.Text;

namespace Crafting.Items
{
    class UncraftableItem : IItem, ICraftable
    {
        public int Name => throw new NotImplementedException();

        public int Price => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public List<IItem> itemRecipe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

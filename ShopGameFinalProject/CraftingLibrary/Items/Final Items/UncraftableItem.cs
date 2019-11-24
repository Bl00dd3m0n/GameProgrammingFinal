using CraftingLibrary.Items.Interfaces.Final_Items;
using CraftingLibrary.Recipes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crafting.Items
{
    sealed class UncraftableItem : IItem, ICraftable
    {
        public string Name => throw new NotImplementedException();

        public int Price => throw new NotImplementedException();

        public Recipe itemRecipe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

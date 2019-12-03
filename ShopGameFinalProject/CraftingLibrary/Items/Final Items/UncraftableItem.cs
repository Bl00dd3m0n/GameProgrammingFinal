using CraftingLibrary.Items.Interfaces;
using CraftingLibrary.Recipes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crafting.Items
{
    sealed class UncraftableItem : IItem, ICraftable
    {
        public string Name => throw new NotImplementedException();

        public float Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Recipe itemRecipe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

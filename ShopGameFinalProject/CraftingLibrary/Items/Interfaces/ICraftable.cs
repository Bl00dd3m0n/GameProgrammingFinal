using CraftingLibrary.Recipes;
using System.Collections.Generic;

namespace CraftingLibrary.Items.Interfaces.Final_Items
{
    public interface ICraftable
    {
        string Name { get; }
        Recipe itemRecipe { get; set; }
    }
}
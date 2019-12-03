using CraftingLibrary.Recipes;
using System.Collections.Generic;

namespace CraftingLibrary.Items.Interfaces
{
    public interface ICraftable
    {
        string Name { get; }
        Recipe itemRecipe { get; set; }
    }
}
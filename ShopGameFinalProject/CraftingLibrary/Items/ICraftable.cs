using System.Collections.Generic;

namespace Crafting.Items
{
    public interface ICraftable
    {
        string Name { get; }
        List<IItem> itemRecipe { get; set; }
    }
}
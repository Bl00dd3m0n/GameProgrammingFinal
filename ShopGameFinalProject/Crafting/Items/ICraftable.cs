using System.Collections.Generic;

namespace Crafting.Items
{
    public interface ICraftable
    {
        List<IItem> itemRecipe { get; set; }
    }
}
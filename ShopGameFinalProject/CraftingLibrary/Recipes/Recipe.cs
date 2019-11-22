using Crafting.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crafting.Recipes
{
    public class Recipe
    {
        public ICraftable craftedItem;
        List<IItem> itemsNeeded;
        public List<IItem> ItemsNeeded { get { return itemsNeeded; } }
        public bool LoadedRecipe { get;  set;}
        public Recipe()
        {
            craftedItem = new Sword();
            itemsNeeded = new List<IItem>();
            itemsNeeded.Add(new Blade());
            itemsNeeded.Add(new Blade());
            itemsNeeded.Add(new Handle());//TODO make this it's own Recipe
        }
    }
}

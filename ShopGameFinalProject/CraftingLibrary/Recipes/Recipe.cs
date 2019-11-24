using Crafting;
using Crafting.Items;
using CraftingLibrary.Items.Interfaces.Final_Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftingLibrary.Recipes
{
    public abstract class Recipe
    {
        public Inventory craftedItems;//Making it an inventory object allows for multiple items to be made or one item to be made with multiple resources
        protected Inventory itemsNeeded;
        public Inventory ItemsNeeded { get { return itemsNeeded; } }
        public bool LoadedRecipe { get;  set;}
        public List<string> RecipeItems;
        public Recipe()
        {
            RecipeItems = new List<string>();
            craftedItems = new Inventory(0);
            itemsNeeded = new Inventory(0);
        }
        public virtual bool LoadRecipe(bool DisplayRecipes, Inventory inventory)
        {
            bool canCraft = false;
            Inventory craftingrecipe = this.ItemsNeeded;//So it doesn't create a new list every time it's called
            string colorCode = "";
            RecipeItems.Clear();
            if (inventory.checkForItems(craftingrecipe.GetInventory()))
            {
                canCraft = true;
            }
            if (DisplayRecipes)
            {
                int index = 0;
                RecipeItems.Add("0,0,0,Recipe: ");
                foreach (IItem item in craftingrecipe.GetInventory())
                {
                    colorCode = "200,0,0";
                    if (inventory.CheckForItem(item, craftingrecipe.NumberOfObjects(item)))
                    {
                        colorCode = "0,0,200";
                    }
                    RecipeItems.Add($"{colorCode},{item.Name} x {inventory.NumberOfObjects(item)}/{craftingrecipe.NumberOfObjects(item)}");
                    index++;
                }
            }
            return canCraft;
        }
    }
}

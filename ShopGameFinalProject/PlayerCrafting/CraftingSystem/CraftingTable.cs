﻿using Crafting;
using Crafting.Items;
using Crafting.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crafting.CraftingSystem
{
    public class CraftingTable
    {
        List<Recipe> SystemRecipes;
        Recipe CurrentRecipe;
        Inventory currentInventory;
        bool canCraft;
        List<string> RecipeItems;
        public CraftingTable(Inventory currentInventory)
        {
            RecipeItems = new List<string>();
            this.currentInventory = currentInventory;
            CurrentRecipe = null;//May not be anything....If the case should just be an empty screen
            SystemRecipes = new List<Recipe>() { new Recipe() };
        }

        public virtual ICraftable Craft(Recipe recipe)
        {
            if (LoadRecipe(recipe, false))
            {
                return recipe.craftedItem;
            }
            return new UncraftableItem();
        }
        public virtual bool LoadRecipe(Recipe recipe, bool DisplayRecipes)
        {
            List<IItem> items = recipe.ItemsNeeded;//So it doesn't create a new list every time it's called
            CurrentRecipe = recipe;
            canCraft = false;
            string colorCode = "";
            if (SystemRecipes.Where(x => x.GetType() == recipe.GetType()).Count() > 0) //If the system contains the recipe see if you can make it
            {
                RecipeItems.Clear();
                if (currentInventory.checkForItems(items))
                {
                    if (DisplayRecipes)
                    {
                        colorCode = "#0000ff";
                    }
                    canCraft = true;
                }
                else
                {
                    if (DisplayRecipes)
                    {
                        colorCode = "#ff0000";
                    }
                }
            }
            foreach (IItem item in items)
            {
                RecipeItems.Add($"{colorCode}{item.Name.ToString()}");
            }
            return canCraft;
        }
    }
}
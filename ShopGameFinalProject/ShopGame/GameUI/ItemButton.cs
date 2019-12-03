using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftingLibrary.CraftingSystem;
using CraftingLibrary.Items.Interfaces;
using CraftingLibrary.Recipes;
using Microsoft.Xna.Framework;
using ShopGame.GameUI;
using ShopGame.Pages;

namespace ShopGame.GameSceneObjects
{
    class ItemsButtons : Button
    {
        public IItem item;
        public ItemsButtons(Game game, IItem item) : base(game,item.Name)
        {
            this.item = item;
        }
    }
}

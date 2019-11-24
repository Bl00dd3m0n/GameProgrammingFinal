using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crafting;
using Crafting.CraftingSystem;
using Crafting.Items;
using CraftingLibrary.Items.Interfaces.Final_Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using ShopGameFinalProject.Managers;

namespace ShopGame.Pages
{
    class MonogameCraftingTable : MonoGameCrafting
    {
        SpriteBatch spriteBatch;


        public MonogameCraftingTable(Game game, ShopKeeper player, SpriteBatch sb, ScreenManager screen) : base(game,player, screen)
        {
            this.screen = screen;
            this.crafting = new CraftingTable(player.inventory);
            SetButtons();
            this.spriteBatch = sb;
        }


    }
}

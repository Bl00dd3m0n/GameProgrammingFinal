using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crafting;
using Crafting.CraftingSystem;
using Crafting.Items;
using CraftingLibrary.Items.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using ShopGameFinalProject.Managers;

namespace ShopGame.Pages
{
    class MonogameCraftingTable : MonoGameCrafting
    {
        SpriteBatch spriteBatch;


        public MonogameCraftingTable(Game game, ShopKeeper player, SpriteBatch sb) : base(game,player)
        {
            this.canvas = new CraftingCanvas(game, this.GetType().Name);
            this.crafting = new CraftingTable(player.inventory);
            this.spriteBatch = sb;
        }
    }
}

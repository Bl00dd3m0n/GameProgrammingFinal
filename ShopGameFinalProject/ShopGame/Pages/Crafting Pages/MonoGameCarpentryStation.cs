using Crafting.CraftingSystem;
using CraftingLibrary.CraftingSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using ShopGameFinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Pages
{
    class MonoGameCarpentryStation : MonoGameCrafting
    {
        SpriteBatch spriteBatch;


        public MonoGameCarpentryStation(Game game, ShopKeeper player, SpriteBatch sb) : base(game, player)
        {
            this.canvas = new CraftingCanvas(game, this.GetType().Name);
            this.crafting = new CarpentryStation(player.inventory);
            this.spriteBatch = sb;
        }
    }
}

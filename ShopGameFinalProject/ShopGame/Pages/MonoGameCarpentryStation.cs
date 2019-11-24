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


        public MonoGameCarpentryStation(Game game, ShopKeeper player, SpriteBatch sb, ScreenManager screen) : base(game, player, screen)
        {
            this.screen = screen;
            this.crafting = new CarpentryStation(player.inventory);
            SetButtons();
            this.spriteBatch = sb;
        }
    }
}

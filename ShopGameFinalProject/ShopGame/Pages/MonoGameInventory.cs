using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crafting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using ShopGameFinalProject.Managers;

namespace ShopGame.Pages
{
    class MonoGameInventory : MonoGamePage // Should abstract this point to just a plain page instead of a crafting page
    {
        SpriteBatch spriteBatch;
        public MonoGameInventory(Game game, ShopKeeper player, ScreenManager screen) : base(game, player)
        {
            this.screen = screen;
            items = new ItemsButtons[items.Length];
            this.spriteBatch = sb;
        }
    }
}

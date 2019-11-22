using Crafting;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame
{
    class ShopKeeper : DrawableGameComponent
    {
        public ShopKeeper(Game game) : base(game)
        {
            inventory = new Inventory(50);
        }

        public Inventory inventory { get; set; }
    }
}

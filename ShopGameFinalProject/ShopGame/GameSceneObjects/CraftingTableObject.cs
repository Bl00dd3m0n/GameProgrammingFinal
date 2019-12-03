using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ShopGame.Managers;
using ShopGame.Pages;
using ShopGameFinalProject.Managers;

namespace ShopGame.GameSceneObjects
{
    class CraftingTableObject : CraftingObjects
    {
        public CraftingTableObject(Game game, WorldManager world) : base(game, world)
        {
            TextureName = "CraftingTable";
            page = ScreenStateEnum.Crafting;
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ShopGame.Pages;
using ShopGameFinalProject.Managers;

namespace ShopGame.GameSceneObjects
{
    class FurnaceObject : CraftingObjects
    {
        public FurnaceObject(Game game) : base(game)
        {
            TextureName = "Furnace";
            page = ScreenStateEnum.Smelting;
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}

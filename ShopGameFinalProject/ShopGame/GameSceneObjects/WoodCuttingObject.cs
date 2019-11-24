﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ShopGame.Pages;
using ShopGameFinalProject.Managers;

namespace ShopGame.GameSceneObjects
{
    class WoodCuttingObject : CraftingObjects
    {
        public WoodCuttingObject(Game game) : base(game)
        {
            TextureName = "Sawmill";
            page = ScreenStateEnum.Woodcutting;
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
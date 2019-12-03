using CraftingLibrary.CraftingSystem;
using Microsoft.Xna.Framework;
using ShopGame.Managers;
using ShopGame.Pages;
using ShopGameFinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.GameSceneObjects
{
    abstract class CraftingObjects : CollidableGameObject
    {
        protected ScreenStateEnum page;
        public ScreenStateEnum Page { get { return page; } }
        public CraftingObjects(Game game, WorldManager manager) : base(game, manager)
        {

        }
        protected override void LoadContent()
        {
            base.LoadContent();
            float xval = Texture.Width*2;
            float yval = GraphicsDevice.Viewport.Height - Texture.Height;
            Position = new Vector2(xval, yval);
            SetPosition(xval);
        }

        protected virtual void SetPosition(float xval)
        {
            if (world.ColliderCheck(this) != null)
            {
                Position += new Vector2(xval, 0);
                SetPosition(xval);
            }
        }
    }
}

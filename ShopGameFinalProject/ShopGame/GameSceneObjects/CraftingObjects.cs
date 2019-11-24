using CraftingLibrary.CraftingSystem;
using Microsoft.Xna.Framework;
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
        public CraftingObjects(Game game) : base(game)
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
            foreach (CollidableGameObject item in CollidableObjects)
            {
                if (item.Texture != null)//This will ignore if the Asset hasn't been loaded yet
                {
                    MovePos(xval, item);
                }
            }
        }
        private void MovePos(float xval, CollidableGameObject item)
        {
            if (item != this)
            {
                if (this.CheckBoundaryCollision(item))
                {
                    Position += new Vector2(xval, 0);
                    MovePos(xval, item);
                }
            }
        }
    }
}

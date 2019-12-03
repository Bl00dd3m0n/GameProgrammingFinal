using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.GameUI
{
    class Canvas : DrawableGameComponent
    {
        public List<Component> Components;
        public bool enabled;
        public Canvas(Game game) : base(game)
        {
            enabled = false;
            Components = new List<Component>();
        }
        public virtual void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (enabled)
            {
                foreach (var component in Components)
                {
                    if (component != null && component.enabled)
                    {
                        component.Draw(spriteBatch);
                    }
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}

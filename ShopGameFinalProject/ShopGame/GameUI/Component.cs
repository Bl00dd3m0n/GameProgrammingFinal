using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.GameUI
{

    public class Component : DrawableGameComponent
    {
        public bool enabled;
        public Vector2 position;
        public Component(Game game) : base(game)
        {
            enabled = false;
        }
        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            Draw(sb);
            base.Draw(gameTime);
        }
        public override void Initialize()
        {
            base.Initialize();
        }

        public virtual void Draw(SpriteBatch sb)
        {
            
        }
    }
}

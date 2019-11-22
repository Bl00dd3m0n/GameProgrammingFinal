using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame 
{
    public class Button : DrawableGameComponent
    {
        public Rectangle bounds;
        public Rectangle Bounds { get { return bounds; } }
        public Button(Game game) : base(game)
        {

        }
        public bool Contains(Point point)
        {
            if(bounds.Left <= point.X && bounds.Right >= point.X && bounds.Top <= point.Y && bounds.Bottom >= point.Y)
            {
                return true;
            }
            return false;
        }
        public bool Contains(Rectangle rect)
        {
            if ((rect.Right < bounds.Left && rect.Left > bounds.Right) &&(rect.Bottom >bounds.Top && rect.Top < bounds.Bottom))
            {
                return true;
            }
            return false;
        }
        public void Draw(GameTime gameTime, SpriteBatch sb, SpriteFont font, string message,Vector2 positon)
        {
            bounds.X = (int)positon.X;
            bounds.Y = (int)positon.Y;
            bounds.Width = message.Count()*8;
            bounds.Height = 20;

            sb.DrawString(font,message,positon,Color.Black);

            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShopGame.GameUI
{
    public class Text : Component
    {
        SpriteFont font;
        internal string text;
        Vector2 position;
        Color textColor;
        public Text(Game game) : base(game)
        {
            font = Game.Content.Load<SpriteFont>("Recipes");
        }
        public void SetTextValues(string message, Vector2 position, Color color)
        {
            SetText(message);
            this.position = position;
            textColor = color;
        }
        public void SetText(string text)
        {
            this.text = text;
        }
        public override void Draw(SpriteBatch sb)
        {
            Draw(sb, text, position, textColor);
        }
        public void Draw(SpriteBatch sb,string message, Vector2 position)
        {
            Draw(sb, message, position, Color.Black);
        }
        void Draw(SpriteBatch sb, string message, Vector2 position,Color color)
        {
            if(message == null)
            {
                message = "null";
            }
            sb.DrawString(font, message, position, color);
        }
        public Vector2 TextPositions(string message)
        {
            if (message == null) message = "null";
            return font.MeasureString(message);
        }
    }
}

using Crafting;
using Crafting.Items;
using CraftingLibrary.Items.Interfaces.Final_Items;
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
        public delegate Inventory ReturnInventory();
        public delegate void Action();
        Color buttonColor;
        int DarkIncrement;
        public bool pressed;
        public Button(Game game) : base(game)
        {
            DarkIncrement = 20;
            buttonColor = Color.Magenta;
        }
        public bool Contains(Point point)
        {
            if (bounds.Left <= point.X && bounds.Right >= point.X && bounds.Top <= point.Y && bounds.Bottom >= point.Y)
            {
                return true;
            }
            return false;
        }
        public bool Contains(Rectangle rect)
        {
            if ((rect.Right < bounds.Left && rect.Left > bounds.Right) && (rect.Bottom > bounds.Top && rect.Top < bounds.Bottom))
            {
                return true;
            }
            return false;
        }
        public void Draw(GameTime gameTime, SpriteBatch sb, SpriteFont font, string message, Vector2 positon)
        {
            Draw(gameTime, sb, font, message, positon, buttonColor);
        }
        public void Buttonpressed()
        {
            if(buttonColor != Color.Magenta)
                buttonColor = new Color(buttonColor.R - DarkIncrement, buttonColor.G - DarkIncrement, buttonColor.B - DarkIncrement);
            pressed = true;
        }
        public void ButtonReleased()
        {
            buttonColor = new Color(buttonColor.R + DarkIncrement, buttonColor.G + DarkIncrement, buttonColor.B + DarkIncrement);
            pressed = false;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="sb"></param>
        /// <param name="font"></param>
        /// <param name="message"></param>
        /// <param name="positon"></param>
        /// <param name="color"></param>
        /// <see cref="https://stackoverflow.com/questions/5751732/draw-rectangle-in-xna-using-spritebatch"/>
        public void Draw(GameTime gameTime, SpriteBatch sb, SpriteFont font, string message, Vector2 positon, Color color)
        {

            bounds.X = (int)positon.X;
            bounds.Y = (int)positon.Y;
            bounds.Width = (int)font.MeasureString(message).X;
            bounds.Height = (int)font.MeasureString(message).Y;
            if (color != Color.Magenta)
            {
                Texture2D rect = new Texture2D(GraphicsDevice, bounds.Width, bounds.Height);

                Color[] data = new Color[bounds.Width * bounds.Height];
                for (int i = 0; i < data.Length; ++i) data[i] = color;
                rect.SetData(data);

                sb.Draw(rect, positon, Color.White);
            }
            sb.DrawString(font, message, positon, Color.Black);

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

using Crafting;
using Crafting.Items;
using CraftingLibrary.Items.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.GameUI
{
    public class Button : Component
    {
        Color buttonColor;
        public Rectangle bounds;
        public Rectangle Bounds { get { return bounds; } }
        public delegate Inventory ReturnInventory();
        public delegate void Action();
        public Action delegatedMethod;
        public Text buttonText { get; protected set; }
        int DarkIncrement;
        public bool pressed;
        SpriteFont font;
        public Button(Game game, string text) : base(game)
        {
            DarkIncrement = 20;
            buttonText = new Text(game);
            buttonText.Initialize();
            buttonText.SetText(text);
            CreateButton(text, position, Color.Magenta, Color.Black);
            font = game.Content.Load<SpriteFont>("Recipes");
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

        public void Buttonpressed()
        {
            if (buttonColor != Color.Magenta)
                buttonColor = new Color(buttonColor.R - DarkIncrement, buttonColor.G - DarkIncrement, buttonColor.B - DarkIncrement);
            pressed = true;
        }
        public void ButtonReleased()
        {
            buttonColor = new Color(buttonColor.R + DarkIncrement, buttonColor.G + DarkIncrement, buttonColor.B + DarkIncrement);
            pressed = false;
        }
        public override void Draw(SpriteBatch sb)
        {
            if (enabled)
            {
                Draw(sb, buttonColor,position);
            }
        }
        public void UpdateBoundaries(Vector2 position)
        {
            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;
            bounds.Width = (int)buttonText.TextPositions(buttonText.text).X;
            bounds.Height = (int)buttonText.TextPositions(buttonText.text).Y;
            buttonText.SetTextValues(buttonText.text,position,Color.Black);
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
        public void Draw(SpriteBatch sb, Color color, Vector2 position)
        {
            UpdateBoundaries(position);
            if (color != Color.Magenta)
            {
                Texture2D rect = new Texture2D(GraphicsDevice, bounds.Width, bounds.Height);

                Color[] data = new Color[bounds.Width * bounds.Height];
                for (int i = 0; i < data.Length; ++i) data[i] = color;
                rect.SetData(data);

                sb.Draw(rect, position, Color.White);
            }
            buttonText.Draw(sb);
        }

        internal void CreateButton(string ButtonsText, Vector2 buttonpos, Color BackColor, Color textcolor)
        {
            this.position = buttonpos;
            this.buttonText.SetTextValues(ButtonsText,buttonpos,textcolor);
            buttonColor = BackColor;
            this.enabled = true;
            buttonText.enabled = true;
        }
    }
}

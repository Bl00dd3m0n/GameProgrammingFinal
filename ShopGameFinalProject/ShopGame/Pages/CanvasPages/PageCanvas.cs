using CraftingLibrary.Items.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using ShopGame.GameUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Pages.CanvasPages
{
    class PageCanvas : Canvas
    {
        public bool CheckButton;
        public Point PositionCheck;
        public ItemsButtons selectedItem;
        internal List<Component> DisplayableComponents;
        public PageCanvas(Game game, string title) : base(game)
        {
            CheckButton = false;
            DisplayableComponents = new List<Component>();
        }

        public virtual Text AddText(string text, Vector2 position, Color color)
        {
            Text newText = new Text(Game);
            newText.SetTextValues(text, position, color);
            newText.enabled = true;
            this.Components.Add(newText);
            return newText;
        }

        public virtual Text AddTextWithColorCode(string text, Vector2 position)
        {
            Text newText = new Text(Game);
            string[] textWithColor = new string[4];
            int a = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ',')
                {
                    a++;
                }
                else
                {
                    textWithColor[a] += text[i];
                }
            }

            newText.SetTextValues(textWithColor[3], position, new Color(int.Parse(textWithColor[0]), int.Parse(textWithColor[1]), int.Parse(textWithColor[2])));
            newText.enabled = true;
            this.Components.Add(newText);
            return newText;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (CheckButton)
            {
                foreach (Component component in Components)
                {
                    if (component is Button)
                    {
                        Button button = (Button)component;
                        if (button.Contains(PositionCheck))
                        {
                            if (button.GetType() == typeof(ItemsButtons))
                            {
                                DisplayValues((ItemsButtons)button);
                                selectedItem = (ItemsButtons)button;
                            }
                            else if (button.GetType() == typeof(RecipeButtons))
                            {
                                selectedItem = (RecipeButtons)button;
                                button.delegatedMethod();
                            }
                            else
                                button.delegatedMethod();
                            CheckButton = false;
                            break;
                        }
                    }
                }
            }
            base.Draw(gameTime, spriteBatch);
        }
        public virtual void DisplayValues(ItemsButtons button)
        {
            List<Component> temp = Components.Where(x => x.GetType() == typeof(Text)).ToList();
            foreach (var item in temp)
            {
                Components.Remove(item);
            }
            temp.Clear();
            selectedItem = button;
            AddText($"Name: {button.item.Name}", new Vector2(this.GraphicsDevice.Viewport.Width / 4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), Color.Black);
            AddText($"Price: {button.item.Price}", new Vector2(this.GraphicsDevice.Viewport.Width / 4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), Color.Black);
        }

        public virtual Button AddButton(IItem item, float price, Vector2 position)
        {
            item.Price = price;
            ItemsButtons itemButton = new ItemsButtons(Game, item);
            itemButton.CreateButton(item.Name, position, Color.Magenta, Color.Black);
            this.Components.Add(itemButton);
            return itemButton;
        }
        public virtual Button AddButton(string Message, Vector2 position, Button.Action Event, Color color)
        {
            Button itemButton = new Button(Game, Message);
            itemButton.CreateButton(Message, position, color, Color.Black);
            this.Components.Add(itemButton);
            itemButton.delegatedMethod = Event;
            return itemButton;
        }
    }
}

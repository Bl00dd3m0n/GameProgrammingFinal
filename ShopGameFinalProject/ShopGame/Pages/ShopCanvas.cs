using CraftingLibrary.Items.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using ShopGame.GameUI;
using System.Collections.Generic;
using System.Linq;

namespace ShopGame.Pages.Crafting_Pages
{
    internal class ShopCanvas : PageCanvas
    {
        public bool CheckButton;
        public Point PositionCheck;
        public bool PurchaseItem { get; internal set; }
        public ItemsButtons selectedItem;
        public ShopCanvas(Game game, string title) : base(game, title)
        {
            CheckButton = false;
        }

        public void AddText(string text, Vector2 position, Color color)
        {
            Text newText = new Text(Game);
            newText.SetTextValues(text, position, color);
            newText.enabled = true;
            this.Components.Add(newText);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(CheckButton)
            {
                foreach(Component component in Components)
                {
                    if (component is Button)
                    {
                        Button button = (Button)component;
                        if (button.Contains(PositionCheck))
                        {
                            if (button is ItemsButtons)
                                DisplayValues((ItemsButtons)button);
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
        public void DisplayValues(ItemsButtons button)
        {
            List<Component> temp = Components.Where(x=>x.GetType() == typeof(Text)).ToList();
            foreach(var item in temp)
            {
                Components.Remove(item);
            }
            temp.Clear();
            selectedItem = button;
            AddText($"Name: {button.item.Name}", new Vector2(this.GraphicsDevice.Viewport.Width/4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), Color.Black);
            AddText($"Price: {button.item.Price}", new Vector2(this.GraphicsDevice.Viewport.Width / 4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), Color.Black);
            AddButton(new Vector2(this.GraphicsDevice.Viewport.Width / 4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), CanPurchase);
        }
        internal void CanPurchase()
        {
            PurchaseItem = true;
        }
        public void AddButton(IItem item,float price, Vector2 position)
        {
            item.Price = price;
            ItemsButtons itemButton = new ItemsButtons(Game, item);
            itemButton.CreateButton(item.Name, position, Color.Magenta, Color.Black);
            this.Components.Add(itemButton);
        }
        public void AddButton(Vector2 position, Button.Action Event)
        {
            Button itemButton = new Button(Game, "Purchase");
            itemButton.CreateButton("Purchase", position, Color.White, Color.Black);
            this.Components.Add(itemButton);
            itemButton.delegatedMethod = Event;
        }
    }
}
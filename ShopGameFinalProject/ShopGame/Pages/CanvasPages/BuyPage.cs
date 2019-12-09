using Crafting;
using CraftingLibrary.Items.Interfaces;
using Microsoft.Xna.Framework;
using ShopGame.GameSceneObjects;
using ShopGame.GameUI;
using ShopGame.Pages.Crafting_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Pages.CanvasPages
{
    class BuyPageCanvas : ShopCanvas
    {
        internal bool SellItem;
        public BuyPageCanvas(Game game, string title) : base(game, title)
        {
        }

        public override void DisplayValues(ItemsButtons button)
        {
            foreach (var item in DisplayableComponents)
            {
                Components.Remove(item);
            }
            selectedItem = button;
            Component component;
            component = AddText($"Name: {button.item.Name}", new Vector2(this.GraphicsDevice.Viewport.Width / 4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), Color.Black);
            DisplayableComponents.Add(component);
            component = AddText($"Price: {button.item.Price}", new Vector2(this.GraphicsDevice.Viewport.Width / 4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), Color.Black);
            DisplayableComponents.Add(component);
            component = AddButton("Sell", new Vector2(this.GraphicsDevice.Viewport.Width / 4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), CanSell, Color.White);
            DisplayableComponents.Add(component);
        }

        private void CanSell()
        {
            SellItem = true;
        }
    }
}

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
        public bool PurchaseItem { get; internal set; }
        public List<Component> BuyableComponents;
        public ShopCanvas(Game game, string title) : base(game, title)
        {
            CheckButton = false;
            BuyableComponents = new List<Component>();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
        public override void DisplayValues(ItemsButtons button)
        {
            foreach(var item in DisplayableComponents)
            {
                Components.Remove(item);
            }
            selectedItem = button;
            Component component;
            component = AddText($"Name: {button.item.Name}", new Vector2(this.GraphicsDevice.Viewport.Width/4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), Color.Black);
            DisplayableComponents.Add(component);
            component = AddText($"Price: {button.item.Price}", new Vector2(this.GraphicsDevice.Viewport.Width / 4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), Color.Black);
            DisplayableComponents.Add(component);
            component = AddButton("Purchase", new Vector2(this.GraphicsDevice.Viewport.Width / 4, Components.Where(x => x.GetType() == typeof(Text)).Count() * 20 + 20), CanPurchase, Color.White);
            DisplayableComponents.Add(component);
        }
        internal void CanPurchase()
        {
            PurchaseItem = true;
        }
    }
}
using Crafting;
using CraftingLibrary.Final_Items.Items;
using EconomyLibrary;
using Microsoft.Xna.Framework;
using ShopGame.GameSceneObjects;
using ShopGame.Pages;
using ShopGame.Pages.CanvasPages;
using ShopGame.Pages.Crafting_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Pages.Crafting_Pages
{
    class BuyShop : MonoGamePage
    {
        Inventory BuyableItems;
        Store store;

        public BuyShop(Game game, ShopKeeper player, Inventory BuyableItems) : base(game, player)
        {
            this.BuyableItems = BuyableItems;
            store = new Store();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            ItemList();
        }
        public override void SetUpCanvas()
        {

            canvas = new BuyPageCanvas(Game,"Sell Shop");
            canvas.Initialize();
        }
        public override void Draw(GameTime gameTime)
        {
            if (((BuyPageCanvas)canvas).SellItem)
            {
                Sell();
                ((BuyPageCanvas)canvas).SellItem = false;
            }
            base.Draw(gameTime);
            canvas.Draw(gameTime, sb);
        }

        private void Sell()
        {
            if (player.inventory.CheckForItem(canvas.selectedItem.item, 1))
            {
                foreach (var component in ((ShopCanvas)canvas).BuyableComponents)
                {
                    canvas.Components.Remove(component);
                }
                foreach (var component in ((ShopCanvas)canvas).DisplayableComponents)
                {
                    canvas.Components.Remove(component);
                }
                store.Buy(canvas.selectedItem.item, player.inventory, player.wallet);
                BuyableItems.Remove(canvas.selectedItem.item);
                ItemList();
                ((ShopCanvas)canvas).PurchaseItem = false;
            }
        }

        public void ItemList()
        {
            int i = 0;
            foreach(var item in BuyableItems.GetInventory())
            {
                Random random = new Random();
                float price = random.Next(30,60);
                ((ShopCanvas)canvas).BuyableComponents.Add(canvas.AddButton(item,price,new Vector2(20, (i+1) * 20)));
                i++;
            }
        }
    }
}

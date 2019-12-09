using CraftingLibrary.Items.CraftingMaterials;
using CraftingLibrary.Items.Interfaces;
using EconomyLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Pages.Crafting_Pages
{
    class StorePage : MonoGamePage
    {
        public Store store;
        public StorePage(Game game, ShopKeeper player) : base(game, player)
        {
            store = new Store();
            store.ItemsToSell.Add(new Iron_Ore(), 25);
            store.ItemsToSell.Add(new Logs(), 25);
        }

        public override void SetUpCanvas()
        {
            canvas = new ShopCanvas(game, this.GetType().Name);
            canvas.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            if (((ShopCanvas)canvas).PurchaseItem)
                PurchaseItem();
            base.Draw(gameTime);
            canvas.Draw(gameTime, sb);
        }

        public void PurchaseItem()
        {
            if (canvas.selectedItem.item.Price <= player.wallet.Balance)
            {
                foreach(var component in ((ShopCanvas)canvas).BuyableComponents)
                {
                    canvas.Components.Remove(component);
                }foreach(var component in ((ShopCanvas)canvas).DisplayableComponents)
                {
                    canvas.Components.Remove(component);
                }
                store.Buy(canvas.selectedItem.item, player.inventory, player.wallet);
                canvas.Components.Remove(canvas.selectedItem);
                PopulateStore();
                ((ShopCanvas)canvas).PurchaseItem = false;
            }
        }

        public void PopulateStore()
        {
            int i = 0;
            foreach (IItem item in store.ItemsToSell.GetInventory())
            {
                int price = 0;
                if (item is Iron_Ore)
                    price = 5;
                else
                    price = 10;
                ((ShopCanvas)canvas).BuyableComponents.Add(canvas.AddButton(item,price,new Vector2(20, (i+1) * 20)));
                i++;
            }
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            if (string.IsNullOrEmpty(TextureName))
                TextureName = "CraftingPage";
            Texture = game.Content.Load<Texture2D>(TextureName);
            PopulateStore();
        }
    }
}

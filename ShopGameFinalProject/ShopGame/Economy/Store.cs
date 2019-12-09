using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crafting;
using CraftingLibrary.Items.Interfaces;
namespace EconomyLibrary
{
    public class Store
    {
        Inventory itemsToSell;
        public Inventory ItemsToSell { get { return itemsToSell; } }
        bool canRestore; //TODO for non-player stores RefreshableStore
        Wallet storeWallet;
        public Store() : this(0)
        {

        }
        public Store(int StartingBalance)
        {
            itemsToSell = new Inventory(0);
            storeWallet = new Wallet(StartingBalance);
        }
        /// <summary>
        /// Used for the player to buy items
        /// </summary>
        /// <param name="item"> the item to sell </param>
        /// <param name="BuyersInventory"> Players inventory - used to add to</param>
        /// <param name="purchaseWallet">Players walllet used to remove money</param>
        /// <returns></returns>
        public bool Sell(IItem item, Inventory BuyersInventory, Wallet purchaseWallet)
        {
            if (itemsToSell.CheckForItem(item, 1))
            {
                if (purchaseWallet.Withdraw(item.Price))
                {
                    itemsToSell.Remove(item);
                    BuyersInventory.Add(item);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Used to sell items to the shop
        /// </summary>
        /// <param name="item"></param>
        /// <param name="PurchaseInventory"></param>
        /// <returns></returns>
        public bool Buy(IItem item, Inventory PurchaseInventory, Wallet sellerWallet)
        {
            if (PurchaseInventory.CheckForItem(item, 1))
            {
                PurchaseInventory.Remove(item);
                itemsToSell.Add(item);
                sellerWallet.Inject(item.Price);
                return true;
            }
            return false;
        }
        public bool Buy(IItem item, Inventory PurchaseInventory, int sellCount, Wallet sellerWallet)
        {
            bool sold = true;
            for (int i = 0; i < sellCount; i++)
            {
                sold = Buy(item, PurchaseInventory, sellerWallet);
                if (!sold) break;
            }
            return sold;
        }
    }
}

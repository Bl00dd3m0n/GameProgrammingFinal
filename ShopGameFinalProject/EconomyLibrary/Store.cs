using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crafting;
using CraftingLibrary.Items.Interfaces;
namespace EconomyLibrary
{
    class Store
    {
        Inventory itemsToSell;
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
        public bool Buy(IItem item, Inventory PurchaseInventory, Wallet purchaseWallet)
        {
            if (itemsToSell.CheckForItem(item, 1))
            {
                if (purchaseWallet.Withdraw(item.Price))
                {
                    itemsToSell.Remove(item);
                    PurchaseInventory.Add(item);
                    return true;
                }
            }
            return false;
        }
        public bool Sell(IItem item, Inventory PurchaseInventory)
        {
            if (storeWallet.Withdraw(item.Price))
            {
                if (PurchaseInventory.CheckForItem(item, 1))
                {
                    PurchaseInventory.Remove(item);
                    itemsToSell.Add(item);
                    return true;
                }
            }
            return false;
        }
        public bool Sell(IItem item, Inventory PurchaseInventory, int sellCount)
        {
            bool sold = true;
            for (int i = 0; i < sellCount; i++)
            {
                sold = Sell(item, PurchaseInventory);
                if (!sold) break;
            }
            return sold;
        }
    }
}

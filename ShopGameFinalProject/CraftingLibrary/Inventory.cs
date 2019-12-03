using CraftingLibrary.Items.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Crafting
{
    public class Inventory
    {
        List<IItem> items;
        int Size;
        public Inventory(int size)
        {
            items = new List<IItem>();
            this.Size = size;
        }
        public virtual void Add(IItem item, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Add(item);
            }
        }
        public virtual void Add(Inventory inventory)
        {
            foreach (var item in inventory.GetInventory())
            {
                Add(item);
            }
        }
        public virtual void Add(IItem item)
        {
            if (items.Count < Size || Size == 0)
            {
                items.Add(item);
            }
        }

        public virtual List<IItem> GetInventory()
        {
            return items;
        }
        /// <summary>
        /// Finds the first occurance of the item in the inventory List - Replacement for List.Find() -ensures you find the item type and not the item specific to the list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual IItem Find(IItem item)
        {
            return AllOfType(item).First();
        }
        protected virtual List<IItem> AllOfType(IItem item)
        {
            return items.Where(x => x.GetType() == item.GetType()).ToList();
        }
        public virtual int NumberOfObjects(IItem item)
        {
            return AllOfType(item).Count();
        }

        public virtual bool Remove(IItem item)
        {
            if (CheckForItem(item, 1))
            {
                items.Remove(Find(item));
                return true;
            }
            return false;
        }
        public virtual bool Remove(List<IItem> otheritems)
        {
            bool remove = true;
            List<IItem> itemsToRemove = new List<IItem>();
            foreach (IItem item in otheritems)
            {
                if (CheckForItem(item, 1))
                {
                    itemsToRemove.Add(items.Where(x => x.GetType() == item.GetType()).FirstOrDefault());
                }
                else
                {
                    remove = false;
                    break;
                }
            }
            if (remove == false)
            {
                return false;
            }
            foreach (IItem item in itemsToRemove)
            {
                items.Remove(item);
            }
            itemsToRemove.Clear();
            return true;
        }

        public virtual bool CheckForItem(IItem item, int objectCount)
        {
            int number = NumberOfObjects(item);
            if (number >= objectCount)
            {
                return true;
            }
            return false;
        }
        public virtual bool checkForItems(List<IItem> itemsNeeded)
        {
            bool hasItems = true;
            foreach (IItem item in itemsNeeded)
            {
                if (!(AllOfType(item).Count() >= itemsNeeded.Where(x => x.GetType() == item.GetType()).Count()))
                {
                    hasItems = false;
                }
            }
            return hasItems;
        }
    }
}

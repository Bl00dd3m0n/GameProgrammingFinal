using CraftingLibrary.Items.Interfaces.Final_Items;
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
            for(int i = 0; i < count; i++)
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
            if(items.Count < Size || Size == 0)
            {
                items.Add(item);
            }
        }

        public virtual List<IItem> GetInventory()
        {
            return items;
        }

        public virtual int NumberOfObjects(IItem item)
        {
            return items.Where(x => x.GetType() == item.GetType()).Count();
        }

        public virtual void Remove(IItem item)
        {
            items.Remove(item);
        }
        public virtual void Remove(List<IItem> otheritems)
        {
            List<IItem> itemsToRemove = new List<IItem>();
            foreach(IItem item in otheritems)
            {
                if(CheckForItem(item,1))
                {
                    itemsToRemove.Add(items.Where(x => x.GetType() == item.GetType()).FirstOrDefault());
                }
            }
            foreach(IItem item in itemsToRemove)
            {
                items.Remove(item);
            }
            itemsToRemove.Clear();
        }
        public virtual bool CheckForItem(IItem item, int objectCount)
        {
            int number = NumberOfObjects(item);
            if (number >= objectCount )
            {
                return true;
            }
            return false;
        }
        public virtual bool checkForItems(List<IItem> itemsNeeded)
        {
            bool hasItems = true;
            foreach(IItem item in itemsNeeded)
            {
                if(!(items.Where(x => x.GetType() == item.GetType()).Count() >= itemsNeeded.Where(x=>x.GetType() == item.GetType()).Count()))
                {
                    hasItems = false;
                }
            }
            return hasItems;
        }
    }
}

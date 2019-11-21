using Crafting.Recipes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Crafting
{
    public class Inventory
    {
        List<IItem> items;
        int totalItems;
        int Size;
        public Inventory(int size)
        {
            items = new List<IItem>();
            totalItems = 0;
            this.Size = size;
        }
        public virtual void Add(IItem item, int count)
        {
            for(int i = 0; i < count; i++)
            {
                Add(item);
            }
        }
        public virtual void Add(IItem item)
        {
            if(items.Count < Size)
            {
                items.Add(item);
            }
        }
        protected virtual void Remove(IItem item)
        {
            items.Remove(item);
        }
        public virtual bool CheckForItem(IItem item)
        {
            List<IItem> tempitems = items.Where(x => x.GetType() == item.GetType()).ToList();
            int number = tempitems.Count();
            if (number > 0)
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

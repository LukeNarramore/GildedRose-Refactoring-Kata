using ApprovalUtilities.Utilities;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        private readonly ItemUpdater _itemUpdater;

        public GildedRose(IList<Item> Items)
            : this(Items, new ItemUpdater())
        { }

        public GildedRose(IList<Item> Items, ItemUpdater itemUpdater)
        {
            _items = Items;
            _itemUpdater = itemUpdater;
        }

        public IList<Item> Items => _items;

        public void UpdateQuality()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                Items[i] = _itemUpdater.UpdateQuality(ref item);
            }

            return;
        }
    }
}

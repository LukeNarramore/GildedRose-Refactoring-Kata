using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class ItemUpdater
    {
        private const int MAX_QUALITY = 50;
        private const int BACKSTAGE_FIRST_DAYS_BEFORE = 10; 
        private const int BACKSTAGE_SECOND_DAYS_BEFORE = 5;

        //public static readonly string[] SpecialCases = [Constants.AGED_BRIE, Constants.BACKSTAGE, Constants.SULFURAS];

        public Item UpdateQuality(Item item)
        {
            switch (item.Name)
            {
                case Constants.AGED_BRIE:
                    return UpdateQualityAgedBrie(item);
                case Constants.BACKSTAGE:
                    return UpdateQualityBackStage(item);
                case Constants.SULFURAS:
                    return UpdateQualitySulfuras(item);
                // Add new special cases here -->
                default:
                    return UpdateQualityDefault(item);
            }

            //if (item.Name != Constants.AGED_BRIE && item.Name != Constants.BACKSTAGE)
            //{
            //    if (item.Quality > 0)
            //    {
            //        if (item.Name != Constants.SULFURAS)
            //        {
            //            item.Quality--;
            //        }
            //    }
            //}
            //else
            //{
            //    if (item.Quality < MAX_QUALITY)
            //    {
            //        item.Quality++;

            //        if (item.Name == Constants.BACKSTAGE)
            //        {
            //            if (item.SellIn < 11)
            //            {
            //                if (item.Quality < MAX_QUALITY)
            //                {
            //                    item.Quality++;
            //                }
            //            }

            //            if (item.SellIn < 6)
            //            {
            //                if (item.Quality < MAX_QUALITY)
            //                {
            //                    item.Quality++;
            //                }
            //            }
            //        }
            //    }
            //}

            //if (item.Name != Constants.SULFURAS)
            //{
            //    item.SellIn--;
            //}

            //if (item.SellIn < 0)
            //{
            //    if (item.Name != Constants.AGED_BRIE)
            //    {
            //        if (item.Name != Constants.BACKSTAGE)
            //        {
            //            if (item.Quality > 0)
            //            {
            //                if (item.Name != Constants.SULFURAS)
            //                {
            //                    item.Quality--;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            item.Quality = 0;
            //        }
            //    }
            //    else
            //    {
            //        if (item.Quality < MAX_QUALITY)
            //        {
            //            item.Quality++;
            //        }
            //    }
            //}

            //return item;
        }


        private Item UpdateQualityAgedBrie(Item item)
        {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality++;
            }
            item.SellIn--;
            return item;
        }

        private Item UpdateQualityBackStage(Item item)
        {
            if (item.SellIn <= BACKSTAGE_SECOND_DAYS_BEFORE)
            {
                if (item.Quality < MAX_QUALITY)
                {
                    item.Quality += 3;
                }
            }
            else if (item.SellIn <= BACKSTAGE_FIRST_DAYS_BEFORE)
            {
                if (item.Quality < MAX_QUALITY)
                {
                    item.Quality += 2;
                }
            }
            else
            {
                item.Quality++;
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }

            return item;
        }

        private Item UpdateQualitySulfuras(Item item)
        {
            item.Quality = 80;
            return item;
        }

        private Item UpdateQualityDefault(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
                
            };

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }

            item.SellIn--;

            return item;
        }

    }
}

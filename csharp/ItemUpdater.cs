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

        public Item UpdateQuality(ref Item item)
        {
            switch (item.Name)
            {
                case Constants.AGED_BRIE:
                    return UpdateQualityAgedBrie(item);
                case Constants.BACKSTAGE:
                    return UpdateQualityBackStage(item);
                case Constants.SULFURAS:
                    return UpdateQualitySulfuras(item);

                case Constants.CONJURED:
                    return UpdateQualityConjured(item);
                // Add new special cases here -->
                default:
                    return UpdateQualityDefault(item);
            }
        }


        private Item UpdateQualityAgedBrie(Item item)
        {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality++;
            }
            
            item.SellIn--;
            
            if (item.SellIn < 0 && item.Quality < MAX_QUALITY)
            {
                item.Quality++;
            }

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
            else if (item.SellIn > 0)
            {
                item.Quality++;
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }

            if (item.Quality > MAX_QUALITY)
            {
                item.Quality = MAX_QUALITY;
            }

            return item;
        }

        private Item UpdateQualitySulfuras(Item item)
        {
            item.Quality = 80;
            return item;
        }

        private Item UpdateQualityConjured(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality-=2;
            };

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality-=2;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

            return item;
        }

        private Item UpdateQualityDefault(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            };

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality--;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

            return item;
        }

    }
}

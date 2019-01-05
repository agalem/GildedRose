using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        private Boolean isUnderHighestQualityValue(Item item) {
            return item.Quality < 50;
        }
        private Boolean isAboveLowestQualityValue(Item item) {
            return item.Quality > 0;
        }
        private void IncreaseQualityValue(Item item)
        {
            if (isUnderHighestQualityValue(item))
            {
                item.Quality = item.Quality + 1;
            }
        }
        private void DecreaseQualityValue(Item item)
        {
            if (isAboveLowestQualityValue(item))
            {
                item.Quality = item.Quality - 1;
            }
        }

        private void NormalUpdate(Item item) 
        {
            item.SellIn = item.SellIn - 1;
            DecreaseQualityValue(item);
            if(item.SellIn < 0) 
            {
                DecreaseQualityValue(item);
            }
        }

        private void BrieUpdate(Item item)
        {
            item.SellIn = item.SellIn - 1;
            IncreaseQualityValue(item);
            if(item.SellIn < 0) 
            {
                IncreaseQualityValue(item);
            }
        }

        private void SulfurasUpdate(Item item)
        {

        }

        private void BackstageUpdate(Item item)
        {
            item.SellIn = item.SellIn - 1;
            IncreaseQualityValue(item);

            if(item.SellIn < 10) 
            {
                IncreaseQualityValue(item);
            }

            if(item.SellIn < 5) 
            {
                IncreaseQualityValue(item);
            }

            if (item.SellIn < 0) 
            {
                item.Quality = 0;
            }
        }

        public void UpdateQuality()
        {
            foreach(Item item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    SulfurasUpdate(item);
                } 
                else if (item.Name == "Aged Brie")
                {
                    BrieUpdate(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    BackstageUpdate(item);
                }
                else
                {
                    NormalUpdate(item);
                }
            }
        }
    }
}

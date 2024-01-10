using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void StandardItem_UpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Item Foo", SellIn = 8, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That("Item Foo", Is.EqualTo(Items[0].Name));
            Assert.That(7, Is.EqualTo(Items[0].SellIn)); 
            Assert.That(9, Is.EqualTo(Items[0].Quality));
        }

        [Test]
        public void StandardItem_UpdateQuality_NeverNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Item Foo", SellIn = 8, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            for (int i = 0; i < 100; ++i)
            {
                app.UpdateQuality();
            }
            Assert.That("Item Foo", Is.EqualTo(Items[0].Name));
            Assert.That(-92, Is.EqualTo(Items[0].SellIn));
            Assert.That(0, Is.EqualTo(Items[0].Quality));
        }

        [Test]
        public void AgedBrie_UpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.AGED_BRIE, SellIn = 20, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Constants.AGED_BRIE, Is.EqualTo(Items[0].Name));
            Assert.That(19, Is.EqualTo(Items[0].SellIn));
            Assert.That(11, Is.EqualTo(Items[0].Quality));
        }

        [Test]
        public void AgedBrie_UpdateQuality_Max()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.AGED_BRIE, SellIn = 20, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Constants.AGED_BRIE, Is.EqualTo(Items[0].Name));
            Assert.That(19, Is.EqualTo(Items[0].SellIn));
            Assert.That(50, Is.EqualTo(Items[0].Quality));
        }

        [Test]
        public void BackedStage_UpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.BACKSTAGE, SellIn = 9, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Constants.BACKSTAGE, Is.EqualTo(Items[0].Name));
            Assert.That(8, Is.EqualTo(Items[0].SellIn));
            Assert.That(12, Is.EqualTo(Items[0].Quality));
        }

        [Test]
        public void BackedStage_UpdateQuality_LessThan5Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.BACKSTAGE, SellIn = 4, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Constants.BACKSTAGE, Is.EqualTo(Items[0].Name));
            Assert.That(3, Is.EqualTo(Items[0].SellIn));
            Assert.That(13, Is.EqualTo(Items[0].Quality));
        }


        [Test]
        public void SULFURAS_UpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.SULFURAS, SellIn = 20, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Constants.SULFURAS, Is.EqualTo(Items[0].Name));
            Assert.That(20, Is.EqualTo(Items[0].SellIn));
            Assert.That(80, Is.EqualTo(Items[0].Quality));
        }

    }
}

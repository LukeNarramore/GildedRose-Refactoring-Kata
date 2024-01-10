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
            Assert.That(Items[0].SellIn, Is.EqualTo(7));
            Assert.That(Items[0].Quality, Is.EqualTo(9));
        }

        [Test]
        public void StandardItem_UpdateQuality_NeverNegative_100()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Item Foo", SellIn = 8, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            for (int i = 0; i < 100; ++i)
            {
                app.UpdateQuality();
            }
            Assert.That("Item Foo", Is.EqualTo(Items[0].Name));
            Assert.That(Items[0].SellIn, Is.EqualTo(-92));
            Assert.That(Items[0].Quality, Is.EqualTo(0));
        }

        [Test]
        public void AgedBrie_UpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.AGED_BRIE, SellIn = 20, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Constants.AGED_BRIE, Is.EqualTo(Items[0].Name));
            Assert.That(Items[0].SellIn, Is.EqualTo(19));
            Assert.That(Items[0].Quality, Is.EqualTo(11));
        }

        [Test]
        public void AgedBrie_UpdateQuality_Max()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.AGED_BRIE, SellIn = 20, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Constants.AGED_BRIE, Is.EqualTo(Items[0].Name));
            Assert.That(Items[0].SellIn, Is.EqualTo(19));
            Assert.That(Items[0].Quality, Is.EqualTo(50));
        }

        [Test]
        public void AgedBrie_UpdateQuality_Max_10()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.AGED_BRIE, SellIn = 20, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            for (int i = 0; i < 10; ++i)
            {
                app.UpdateQuality();
            }
            Assert.That(Constants.AGED_BRIE, Is.EqualTo(Items[0].Name));
            Assert.That(Items[0].SellIn, Is.EqualTo(10));
            Assert.That(Items[0].Quality, Is.EqualTo(11));
        }

        [Test]
        public void AgedBrie_UpdateQuality_Max_30()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.AGED_BRIE, SellIn = 20, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            for (int i = 0; i < 30; ++i)
            {
                app.UpdateQuality();
            }
            Assert.That(Constants.AGED_BRIE, Is.EqualTo(Items[0].Name));
            Assert.That(Items[0].SellIn, Is.EqualTo(-10));
            Assert.That(Items[0].Quality, Is.EqualTo(41));
        }


        [Test]
        public void BackedStage_UpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.BACKSTAGE, SellIn = 9, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Constants.BACKSTAGE, Is.EqualTo(Items[0].Name));
            Assert.That(Items[0].SellIn, Is.EqualTo(8));
            Assert.That(Items[0].Quality, Is.EqualTo(12));
        }

        [Test]
        public void BackedStage_UpdateQuality_LessThan5Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.BACKSTAGE, SellIn = 4, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Constants.BACKSTAGE, Is.EqualTo(Items[0].Name));
            Assert.That(Items[0].SellIn, Is.EqualTo(3));
            Assert.That(Items[0].Quality, Is.EqualTo(13));
        }

        [Test]
        public void Sulfuras_UpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.SULFURAS, SellIn = 20, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Constants.SULFURAS, Is.EqualTo(Items[0].Name));
            Assert.That(Items[0].SellIn, Is.EqualTo(20));
            Assert.That(Items[0].Quality, Is.EqualTo(80));
        }

        [Test]
        public void Conjured_UpdateQuality_10()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.CONJURED, SellIn = 10, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            for (int i = 0; i < 10; ++i)
            {
                app.UpdateQuality();
            }
            Assert.That(Constants.CONJURED, Is.EqualTo(Items[0].Name));
            Assert.That(Items[0].SellIn, Is.EqualTo(0));
            Assert.That(Items[0].Quality, Is.EqualTo(10));
        }

        [Test]
        public void Conjured_UpdateQuality_100()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.CONJURED, SellIn = 10, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            for (int i = 0; i < 100; ++i)
            {
                app.UpdateQuality();
            }
            Assert.That(Constants.CONJURED, Is.EqualTo(Items[0].Name));
            Assert.That(Items[0].SellIn, Is.EqualTo(-90));
            Assert.That(Items[0].Quality, Is.EqualTo(0));
        }
    }
}

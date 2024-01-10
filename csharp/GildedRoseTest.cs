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
            IList<Item> Items = new List<Item> { new Item { Name = "Item Foo", SellIn = 10, Quality = 8 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That("Item Foo", Is.EqualTo(Items[0].Name));
            Assert.That(9, Is.EqualTo(Items[0].SellIn)); 
            Assert.That(7, Is.EqualTo(Items[0].Quality));
        }
    }
}

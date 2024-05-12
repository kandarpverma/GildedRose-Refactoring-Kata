using csharp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        IList<Item> Items = null;

        [SetUp]
        public void TestInitialize()
        {
            Items =new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }

        [Test]
        public void ConjuredDefaultInput()
        {
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(4, Items[8].Quality);
        }

        [Test]
        public void ConjuredHighQualityLowSellin()
        {
            Items[8].Quality = 20;
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(18, Items[8].Quality);
        }

        [Test]
        public void ConjuredLowQualityHighSellin()
        {
            Items[8].SellIn = 8;
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(4, Items[8].Quality);
        }
    }
}

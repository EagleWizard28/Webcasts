using DominionCardTracker.DataLayer.Repositories;
using DominionCardTracker.Models.Tables;
using NUnit.Framework;
using System.Linq;

namespace DominionCardTracker.IntegrationTests
{
    [TestFixture]
    public class CardTests
    {
        [SetUp]
        public void Init()
        {
            var repo = new DatabaseResetRepository();
            repo.ResetDatabase();
        }

        [Test]
        public void SelectViewTest()
        {
            var repo = new CardRepository();
            var result = repo.SelectView(2);  // witch

            Assert.AreEqual(2, result.Categories.Count());
            Assert.AreEqual(2, result.Modifiers.Count());
        }

        [Test]
        public void InsertTest()
        {
            var repo = new CardRepository();

            var newCard = new Card
            {
                CardSetID = 1,
                CardCost = 2,
                CardTitle = "Estate",
                ImagePath = "Estate.jpg"
            };

            var result = repo.Insert(newCard);

            Assert.AreEqual(3, result.CardID);
        }

        [Test]
        public void SelectAllTest()
        {
            var repo = new CardRepository();
            var results = repo.SelectAll();

            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void UpdateTest()
        {
            var repo = new CardRepository();
            var card = new Card
                {
                    CardID = 1,
                    CardSetID = 1,
                    CardTitle = "Updated",
                    CardCost = 5,
                    ImagePath = "Foo.jpg"
                };

            repo.Update(card);
        }

        [Test]
        public void DeleteTest()
        {
            var repo = new CardRepository();
            repo.Delete(2);

            var allSets = repo.SelectAll();
            Assert.AreEqual(1, allSets.Count);
        }
    }
}

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
            var result = repo.SelectView(31);  // witch

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
                CardTitle = "NewCard",
                ImagePath = "NewCard.jpg"
            };

            repo.Insert(newCard);
            var allCards = repo.SelectAll();

            Assert.IsNotNull(allCards.FirstOrDefault(c=>c.CardTitle=="NewCard"));
        }

        [Test]
        public void SelectAllTest()
        {
            var repo = new CardRepository();
            var results = repo.SelectAll();

            Assert.AreNotEqual(0, results.Count);
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
            repo.Delete(1);

            var allSets = repo.SelectAll();
            Assert.IsNull(allSets.FirstOrDefault(c=>c.CardID == 1));
        }
    }
}

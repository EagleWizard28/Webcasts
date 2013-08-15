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

using DominionCardTracker.DataLayer.Repositories;
using DominionCardTracker.Models.Tables;
using NUnit.Framework;

namespace DominionCardTracker.IntegrationTests
{
    [TestFixture]
    public class CardSetTests
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
            var repo = new CardSetRepository();
            var results = repo.SelectAll();

            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void InsertTest()
        {
            var repo = new CardSetRepository();
            var newCardSet = new CardSet();
            newCardSet.CardSetName = "Seaside";

            repo.Insert(newCardSet);

            Assert.AreEqual(3, repo.SelectAll().Count);
        }

        [Test]
        public void SelectTest()
        {
            var repo = new CardSetRepository();
            var cardSet = repo.Select(1);

            Assert.IsNotNull(cardSet);
        }

        [Test]
        public void UpdateTest()
        {
            var repo = new CardSetRepository();
            var cardSet = new CardSet { CardSetID = 1, CardSetName = "Updated" };
            repo.Update(cardSet);

            var updatedSet = repo.Select(1);
            Assert.AreEqual("Updated", updatedSet.CardSetName);
        }

        [Test]
        public void DeleteTest()
        {
            var repo = new CardSetRepository();
            repo.Delete(2);

            var allSets = repo.SelectAll();
            Assert.AreEqual(1, allSets.Count);
        }
    }
}

using DominionCardTracker.DataLayer.Repositories;
using DominionCardTracker.Models.Tables;
using NUnit.Framework;

namespace DominionCardTracker.IntegrationTests
{
    [TestFixture]
    public class ModifierTypeTests
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
            var repo = new ModifierTypeRepository();
            var results = repo.SelectAll();

            Assert.AreEqual(5, results.Count);
        }

        [Test]
        public void InsertTest()
        {
            var repo = new ModifierTypeRepository();
            var newModifierType = new ModifierType();
            newModifierType.ModifierTypeName = "New";

            repo.Insert(newModifierType);

            Assert.AreEqual(6, repo.SelectAll().Count);
        }

        [Test]
        public void SelectTest()
        {
            var repo = new ModifierTypeRepository();
            var cardSet = repo.Select(1);

            Assert.IsNotNull(cardSet);
        }

        [Test]
        public void UpdateTest()
        {
            var repo = new ModifierTypeRepository();
            var cardSet = new ModifierType { ModifierTypeID = 1, ModifierTypeName = "Updated" };
            repo.Update(cardSet);

            var updatedSet = repo.Select(1);
            Assert.AreEqual("Updated", updatedSet.ModifierTypeName);
        }

        [Test]
        public void DeleteTest()
        {
            var repo = new ModifierTypeRepository();
            repo.Delete(2);

            var allSets = repo.SelectAll();
            Assert.AreEqual(4, allSets.Count);
        }
    }
}

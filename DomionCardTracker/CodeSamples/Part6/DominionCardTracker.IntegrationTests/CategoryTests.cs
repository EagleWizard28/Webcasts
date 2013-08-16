using DominionCardTracker.DataLayer.Repositories;
using DominionCardTracker.Models.Tables;
using NUnit.Framework;

namespace DominionCardTracker.IntegrationTests
{
    [TestFixture]
    public class CategoryTests
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
            var repo = new CategoryRepository();
            var results = repo.SelectAll();

            Assert.AreEqual(5, results.Count);
        }

        [Test]
        public void InsertTest()
        {
            var repo = new CategoryRepository();
            var newCategory = new Category();
            newCategory.CategoryName = "New";

            repo.Insert(newCategory);

            Assert.AreEqual(6, repo.SelectAll().Count);
        }

        [Test]
        public void SelectTest()
        {
            var repo = new CategoryRepository();
            var cardSet = repo.Select(1);

            Assert.IsNotNull(cardSet);
        }

        [Test]
        public void UpdateTest()
        {
            var repo = new CategoryRepository();
            var cardSet = new Category { CategoryID = 1, CategoryName = "Updated" };
            repo.Update(cardSet);

            var updatedSet = repo.Select(1);
            Assert.AreEqual("Updated", updatedSet.CategoryName);
        }

        [Test]
        public void DeleteTest()
        {
            var repo = new CategoryRepository();
            repo.Delete(2);

            var allSets = repo.SelectAll();
            Assert.AreEqual(4, allSets.Count);
        }
    }
}

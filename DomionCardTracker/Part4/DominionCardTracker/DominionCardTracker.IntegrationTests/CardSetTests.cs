using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}

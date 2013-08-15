using DominionCardTracker.DataLayer.Repositories;
using DominionCardTracker.Models.Tables;
using NUnit.Framework;

namespace DominionCardTracker.IntegrationTests
{
    [TestFixture]
    public class CardModifierTests
    {
        [SetUp]
        public void Init()
        {
            var repo = new DatabaseResetRepository();
            repo.ResetDatabase();
        }

        [Test]
        public void InsertValueTest()
        {
            var repo = new CardModifierRepository();
            var newModifier = new CardModifier
                                  {
                                      CardID = 1,
                                      ModifierTypeID = 1,
                                      ModifierValue = 3
                                  };

            repo.Insert(newModifier);
        }

        [Test]
        public void InsertInstructionTest()
        {
            var repo = new CardModifierRepository();
            var newModifier = new CardModifier
            {
                CardID = 1,
                ModifierTypeID = 1,
                InstructionText = "New Value",
                ModifierValue = null,
            };

            repo.Insert(newModifier);
        }

        [Test]
        public void DeleteTest()
        {
            var repo = new CardModifierRepository();
            repo.Delete(2);
        }
    }
}

using System.Data;
using System.Data.SqlClient;
using Dapper;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.DataLayer.Repositories
{
    public class CardModifierRepository
    {
        public void Insert(CardModifier cardModifier)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardID", cardModifier.CardID);
                p.Add("@ModifierTypeID", cardModifier.ModifierTypeID);
                p.Add("@ModifierValue", cardModifier.ModifierValue);
                p.Add("@InstructionText", cardModifier.InstructionText);

                connection.Execute("CardModifierInsert", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int cardModifierID)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardModifierID", cardModifierID);

                connection.Execute("CardModifierDelete", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

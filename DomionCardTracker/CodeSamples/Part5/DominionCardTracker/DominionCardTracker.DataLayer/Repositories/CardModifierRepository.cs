using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DominionCardTracker.Models.Tables;
using DominionCardTracker.Models.Views;

namespace DominionCardTracker.DataLayer.Repositories
{
    public class CardModifierRepository
    {
        public List<CardModifierView> SelectByCardID(int cardID)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardID", cardID);

                return connection.Query<CardModifierView>("CardModifierSelectByCardID", p,
                commandType: CommandType.StoredProcedure).ToList();
            }
        }

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

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.DataLayer.Repositories
{
    public class CardRepository
    {
        public List<Card> SelectAll()
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                return connection.Query<Card>("CardSelectAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void Update(Card card)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardID", card.CardID);
                p.Add("@CardSetID", card.CardSetID);
                p.Add("@CardTitle", card.CardTitle);
                p.Add("@ImagePath", card.ImagePath);
                p.Add("@CardCost", card.CardCost);

                connection.Execute("CardUpdate", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int cardID)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardID", cardID);

                connection.Execute("CardDelete", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

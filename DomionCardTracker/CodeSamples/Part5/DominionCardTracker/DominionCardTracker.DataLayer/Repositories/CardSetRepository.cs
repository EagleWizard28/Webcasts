using System.Collections.Generic;
using System.Data;
using System.Linq;
using DominionCardTracker.Models.Tables;
using System.Data.SqlClient;
using Dapper;

namespace DominionCardTracker.DataLayer.Repositories
{
    public class CardSetRepository
    {
        public List<CardSet> SelectAll()
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                return connection.Query<CardSet>("CardSetSelectAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void Insert(CardSet cardSet)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardSetName", cardSet.CardSetName);

                connection.Execute("CardSetInsert", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(CardSet cardSet)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CardSetID", cardSet.CardSetID);
                p.Add("@CardSetName", cardSet.CardSetName);
                connection.Execute("CardSetUpdate", p, commandType: CommandType.StoredProcedure);
            }
        }

        public CardSet Select(int cardSetID)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CardSetID", cardSetID);

                return
                    connection.Query<CardSet>("CardSetSelectByID", p, commandType: CommandType.StoredProcedure)
                              .FirstOrDefault();
            }
        }

        public void Delete(int cardSetID)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CardSetID", cardSetID);

                connection.Execute("CardSetDelete", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}

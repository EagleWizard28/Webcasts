using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DominionCardTracker.Models.Tables;
using DominionCardTracker.Models.Views;

namespace DominionCardTracker.DataLayer.Repositories
{
    public class CardRepository
    {
        public CardView SelectView(int cardID)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CardID", cardID);

                using (var multi = connection.QueryMultiple("CardSelectView", p, commandType: CommandType.StoredProcedure))
                {
                    CardView view = multi.Read<CardView>().Single();
                    view.Categories = multi.Read<Category>().ToList();
                    view.Modifiers = multi.Read<CardModifierView>().ToList();

                    return view;
                }
            }
        }

        public Card Insert(Card card)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CardSetID", card.CardSetID);
                p.Add("@CardTitle", card.CardTitle);
                p.Add("@CardCost", card.CardCost);
                p.Add("@ImagePath", card.ImagePath);
                p.Add("@CardID", null, dbType:DbType.Int32, direction:ParameterDirection.Output);

                connection.Execute("CardInsert", p, commandType: CommandType.StoredProcedure);

                card.CardID = p.Get<int>("@CardID");
            }

            return card;
        }

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

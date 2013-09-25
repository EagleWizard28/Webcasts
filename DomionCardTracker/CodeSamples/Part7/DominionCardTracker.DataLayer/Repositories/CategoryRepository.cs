using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.DataLayer.Repositories
{
    public class CategoryRepository
    {
        public List<Category> SelectAll()
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                return connection.Query<Category>("CategorySelectAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void Insert(Category category)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CategoryName", category.CategoryName);

                connection.Execute("CategoryInsert", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Category category)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CategoryID", category.CategoryID);
                p.Add("@CategoryName", category.CategoryName);
                connection.Execute("CategoryUpdate", p, commandType: CommandType.StoredProcedure);
            }
        }

        public Category Select(int categoryID)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CategoryID", categoryID);

                return
                    connection.Query<Category>("CategorySelectByID", p, commandType: CommandType.StoredProcedure)
                              .FirstOrDefault();
            }
        }

        public void Delete(int categoryID)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CategoryID", categoryID);

                connection.Execute("CategoryDelete", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

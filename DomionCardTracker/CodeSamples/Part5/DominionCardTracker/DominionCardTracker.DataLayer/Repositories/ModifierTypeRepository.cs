using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.DataLayer.Repositories
{
    public class ModifierTypeRepository
    {
        public List<ModifierType> SelectAll()
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                return connection.Query<ModifierType>("ModifierTypeSelectAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void Insert(ModifierType modifierType)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ModifierTypeName", modifierType.ModifierTypeName);

                connection.Execute("ModifierTypeInsert", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(ModifierType modifierType)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ModifierTypeID", modifierType.ModifierTypeID);
                p.Add("@ModifierTypeName", modifierType.ModifierTypeName);
                connection.Execute("ModifierTypeUpdate", p, commandType: CommandType.StoredProcedure);
            }
        }

        public ModifierType Select(int modifierTypeID)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ModifierTypeID", modifierTypeID);

                return
                    connection.Query<ModifierType>("ModifierTypeSelectByID", p, commandType: CommandType.StoredProcedure)
                              .FirstOrDefault();
            }
        }

        public void Delete(int modifierTypeID)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ModifierTypeID", modifierTypeID);

                connection.Execute("ModifierTypeDelete", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

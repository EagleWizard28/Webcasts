using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using DominionCardTracker.DataLayer;

namespace DominionCardTracker.IntegrationTests
{
    class DatabaseResetRepository
    {
        public void ResetDatabase()
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                connection.Execute("DbReset", commandType:CommandType.StoredProcedure);
            }
        }
    }
}

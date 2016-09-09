using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RuleParser
{
    public class DBManager
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HydraDB"].ConnectionString;
        public bool InsertKeywordList(DataTable KeywordTable)
        {
            List<SqlParameter> commandParameters = new List<SqlParameter>();
            SqlParameter tableValuedParameter = new SqlParameter("@KeywordTable", KeywordTable);
            tableValuedParameter.SqlDbType = SqlDbType.Structured;
            commandParameters.Add(tableValuedParameter);
            bool status = false;
            try
            {
                int RecordsAffected = SqlHelper.ExecuteNonQuery(connectionString,CommandType.StoredProcedure,  "SP_UpdateKeywordList", commandParameters.ToArray());
                status = true;
            }
            catch(Exception Ex)
            {

            }
            return status;
        }
    }
}

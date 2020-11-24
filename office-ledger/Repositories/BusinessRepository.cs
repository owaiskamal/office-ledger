using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Repositories
{
    public class BusinessRepository : IBusinessUnits
    {
        IConfiguration  configuration;

        public BusinessRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public string GetBusinessUnits()
        {
            string result;
            OracleDataAdapter obj_ORCL = new OracleDataAdapter("CROL_DML_BussUnit_ST", this.GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
            obj_ORCL.SelectCommand.Parameters.Add("p_busunit", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_butitle", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_buname", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_user_cd", "");
            //obj_ORCL.SelectCommand.Parameters.Add("p_insdate", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_rowid", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_upduser_cd", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_action", "SA");
            obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable bs_Dt = new DataTable();
            try
            {
                obj_ORCL.Fill(bs_Dt);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(bs_Dt);
            }
            catch (Exception ex)
            {
                result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
            }
            finally
            {
                obj_ORCL.Dispose();
                bs_Dt.Dispose();
            }
            return result;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}

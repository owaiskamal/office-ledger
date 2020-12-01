using Microsoft.Extensions.Configuration;
using office_ledger.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Repositories
{
    public class ChartOfAccountRepository : IChartOfAccount
    {
        IConfiguration configuration;
        
        public ChartOfAccountRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string getChartOfAccount()
        {
            String result;
            result = AllRecord("SA", null);
            return result;
        }

        public String AllRecord(String action , ChartOfAccount chartOfAccount)
        {
            string result;
            if(chartOfAccount == null)
            {
                OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_coamst_st", GetConnection().ConnectionString);
                obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
                obj_ORCL.SelectCommand.BindByName = true;
                obj_ORCL.SelectCommand.Parameters.Add("p_coano", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_acc_code", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_acc_type", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_acc_name", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_user_cd", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_upduser_cd", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_rowid", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_action", action);
                obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                try
                {
                    obj_ORCL.Fill(dt);
                    result = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
                }
                catch (Exception ex)
                {

                    result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
                }
                finally
                {
                    obj_ORCL.Dispose();
                    dt.Dispose();
                }
            }
            else
            {
            OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_coamst_st", GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
                obj_ORCL.SelectCommand.Parameters.Add("p_coano", chartOfAccount.p_coano);
                obj_ORCL.SelectCommand.Parameters.Add("p_acc_code", chartOfAccount.p_acc_code);
                obj_ORCL.SelectCommand.Parameters.Add("p_acc_type", chartOfAccount.p_acc_type);
                obj_ORCL.SelectCommand.Parameters.Add("p_acc_name", chartOfAccount.p_acc_name);
                obj_ORCL.SelectCommand.Parameters.Add("p_user_cd", chartOfAccount.p_user_cd);
                obj_ORCL.SelectCommand.Parameters.Add("p_upduser_cd", chartOfAccount.p_upduser_cd);
                obj_ORCL.SelectCommand.Parameters.Add("p_rowid", chartOfAccount.p_rowid);
                obj_ORCL.SelectCommand.Parameters.Add("p_action", action);
                obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
            try
            {
                obj_ORCL.Fill(dt);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch (Exception ex)
            {

                result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
            }
            finally
            {
                obj_ORCL.Dispose();
                dt.Dispose();
            }

            }

            return result;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }

        public string insertChartOfAccount(ChartOfAccount chartOfAccount)
        {
            String result;
            result = AllRecord("I", chartOfAccount);
            return result;
        }

        public string updateChartOfAccount(ChartOfAccount chartOfAccount)
        {
            String result;
            result = AllRecord("U", chartOfAccount);
            return result;
        }
    }
}

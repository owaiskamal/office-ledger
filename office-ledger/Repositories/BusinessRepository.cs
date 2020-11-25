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
    public class BusinessRepository : IBusinessUnits
    {
        IConfiguration  configuration;

        public BusinessRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public string GetBusinessUnitById(BusinessUnits businessUnits)
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
            obj_ORCL.SelectCommand.Parameters.Add("p_rowid", businessUnits.row_Id);
            obj_ORCL.SelectCommand.Parameters.Add("p_upduser_cd", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_action", "S");
            obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable businessDT = new DataTable();
            try
            {
               
                obj_ORCL.Fill(businessDT);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(businessDT);
            }
            catch (Exception ex)
            {

                result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
            }
            finally
            {
                obj_ORCL.Dispose();
                businessDT.Dispose();
            }
            return result;
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

        public string InsertBusinessUnits(BusinessUnits businessUnits)
        {
            string result;
            OracleDataAdapter obj_ORCL = new OracleDataAdapter("CROL_DML_BussUnit_ST", this.GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
            obj_ORCL.SelectCommand.Parameters.Add("p_busunit", businessUnits.busUnit);
            obj_ORCL.SelectCommand.Parameters.Add("p_butitle", businessUnits.busTitle);
            obj_ORCL.SelectCommand.Parameters.Add("p_buname", businessUnits.busName);
            obj_ORCL.SelectCommand.Parameters.Add("p_user_cd", businessUnits.user_Cd);
            //obj_ORCL.SelectCommand.Parameters.Add("p_insdate", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_rowid", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_upduser_cd","");
            obj_ORCL.SelectCommand.Parameters.Add("p_action", "I");
            obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable ins_Dt = new DataTable();
            try
            {
                obj_ORCL.Fill(ins_Dt);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(ins_Dt);
            }
            catch (Exception ex)
            {

                result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
            }
            finally
            {

                obj_ORCL.Dispose();
                ins_Dt.Dispose();
            }

            return result;

        }

        public string UpdateBusinessUnits(BusinessUnits businessUnits)
        {
            string result;
            OracleDataAdapter obj_ORCL = new OracleDataAdapter("CROL_DML_BussUnit_ST", this.GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
            obj_ORCL.SelectCommand.Parameters.Add("p_rowid", businessUnits.row_Id);
            obj_ORCL.SelectCommand.Parameters.Add("p_busunit", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_user_cd", businessUnits.user_Cd);
            obj_ORCL.SelectCommand.Parameters.Add("p_butitle", businessUnits.busTitle);
            obj_ORCL.SelectCommand.Parameters.Add("p_buname", businessUnits.busName);
            obj_ORCL.SelectCommand.Parameters.Add("p_upduser_cd", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_action", "U");
            obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable up_Dt = new DataTable();
            try
            {
                obj_ORCL.Fill(up_Dt);
             
                if(up_Dt.Rows.Count > 0)
                {
                    result = Newtonsoft.Json.JsonConvert.SerializeObject(up_Dt);

                }
                else
                {
                    result = "not working";
                }


            }
            catch (Exception ex)
            {

                result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message); 
            }
            finally
            {
                obj_ORCL.Dispose();
                up_Dt.Dispose();
            }
            return result;
        }
    }
}

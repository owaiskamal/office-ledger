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
    public class CostCenterRepository : ICostCenter
    {
        IConfiguration configuration;
        public CostCenterRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string GetCostCenters()
        {
            String result;
            OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_costcenter_st", this.GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
            obj_ORCL.SelectCommand.Parameters.Add("p_cost_id" , "" );
            obj_ORCL.SelectCommand.Parameters.Add("p_cost_code", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_cost_name", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_user_cd", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_row_id", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_upduser_cd", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_action", "SA");
            obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable cs_dt = new DataTable();
            try
            {
                obj_ORCL.Fill(cs_dt);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(cs_dt);
            }
            catch (Exception ex)
            {

                result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
            }
            finally
            {
                obj_ORCL.Dispose();
                cs_dt.Dispose();
            }

            return result;
        }

        public string GetCostCentersById(CostCenter costCenter)
        {
            string result;
            OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_costcenter_st", this.GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
            obj_ORCL.SelectCommand.Parameters.Add("p_cost_id", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_cost_code", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_cost_name", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_user_cd", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_row_id", costCenter.row_id);
            obj_ORCL.SelectCommand.Parameters.Add("p_upduser_cd", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_action", "S");
            obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable cs_dt = new DataTable();
            try
            {
                obj_ORCL.Fill(cs_dt);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(cs_dt);

            }
            catch (Exception ex)
            {

                result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);

            }
            finally
            {
                obj_ORCL.Dispose();
                cs_dt.Dispose();
            }
            return result;
        }

        public string InsertCostCenters(CostCenter costCenter)
        {
            String result;
            OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_costcenter_st", this.GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
            obj_ORCL.SelectCommand.Parameters.Add("p_cost_id", costCenter.cost_id);
            obj_ORCL.SelectCommand.Parameters.Add("p_cost_code", costCenter.cost_code);
            obj_ORCL.SelectCommand.Parameters.Add("p_cost_name", costCenter.cost_name);
            obj_ORCL.SelectCommand.Parameters.Add("p_user_cd", costCenter.user_cd);
            obj_ORCL.SelectCommand.Parameters.Add("p_row_id", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_upduser_cd", costCenter.updUser_cd);
            obj_ORCL.SelectCommand.Parameters.Add("p_action", "I");
            obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable cs_dt = new DataTable();
            try
            {
                obj_ORCL.Fill(cs_dt);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(cs_dt);

            }
            catch (Exception ex)
            {

                result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);

            }
            finally
            {
                obj_ORCL.Dispose();
                cs_dt.Dispose();
            }
            return result;
        }

        public string UpdateCostCenter(CostCenter costCenter)
        {
            String result;
            OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_costcenter_st", this.GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
            obj_ORCL.SelectCommand.Parameters.Add("p_cost_id", costCenter.cost_id);
            obj_ORCL.SelectCommand.Parameters.Add("p_cost_code", costCenter.cost_code);
            obj_ORCL.SelectCommand.Parameters.Add("p_cost_name", costCenter.cost_name);
            obj_ORCL.SelectCommand.Parameters.Add("p_user_cd", costCenter.user_cd);
            obj_ORCL.SelectCommand.Parameters.Add("p_row_id", costCenter.row_id);
            obj_ORCL.SelectCommand.Parameters.Add("p_upduser_cd", costCenter.updUser_cd);
            obj_ORCL.SelectCommand.Parameters.Add("p_action", "U");
            obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable cs_dt = new DataTable();
            try
            {
                obj_ORCL.Fill(cs_dt);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(cs_dt);

            }
            catch (Exception ex)
            {

                result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
            }
            finally
            {
                obj_ORCL.Dispose();
                cs_dt.Dispose();
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

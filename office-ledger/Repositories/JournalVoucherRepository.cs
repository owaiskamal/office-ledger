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
    public class JournalVoucherRepository : IJournalVoucher
    {
        IConfiguration configuration;

        public JournalVoucherRepository(IConfiguration _config)
        {
            configuration = _config;
        }
        public string insertJorunalVoucher(string p_xml)
        {
            string result;
            result = AllRecords("I", p_xml , "");
            return result;
        }

        public string AllRecords(string action, string xml, string id)
        {
            string result;

            if (id == "")
            {
            
            OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_vochmst_dtl_st", this.GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
            obj_ORCL.SelectCommand.Parameters.Add("p_action", action);
            obj_ORCL.SelectCommand.Parameters.Add("p_xml", xml);
            obj_ORCL.SelectCommand.Parameters.Add("p_vochno", id);
            obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable bu_dt = new DataTable();
            try
            {
                obj_ORCL.Fill(bu_dt);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(bu_dt);
            }
            catch (Exception ex)
            {

                result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
            }
            finally
            {
                bu_dt.Dispose();
                obj_ORCL.Dispose();
            }
        }

            else
            {

                OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_vochmst_dtl_st", this.GetConnection().ConnectionString);
                obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
                obj_ORCL.SelectCommand.BindByName = true;
                obj_ORCL.SelectCommand.Parameters.Add("p_action", action);
                obj_ORCL.SelectCommand.Parameters.Add("p_xml", xml);
                obj_ORCL.SelectCommand.Parameters.Add("p_vochno", id);
                obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable bu_dt = new DataTable();
                try
                {

                    obj_ORCL.Fill(bu_dt);
                    var res = bu_dt.Rows[0][":B1"];
                    result = res.ToString();
                
                }
                catch (Exception ex)
                {

                    result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
                }
                finally
                {
                    bu_dt.Dispose();
                    obj_ORCL.Dispose();
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

        public string selectJournalVoucherByFile(string id)
        {
            string result;
            result = AllRecords("S", "", id);
            return result;
        }

        public string getJournalVoucher()
        {
            string result;
            result = AllRecords("SA", "", "");
            return result;
        }

        public string getVochChartOfAccount()
        {
            string result;
            result = AllRecords("CAO", null, "");
            return result;

    
        }
    }
}

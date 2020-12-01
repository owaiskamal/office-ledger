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
    public class CustomerMasterRepository : ICustomerMaster
    {
        public IConfiguration configuration;

        public CustomerMasterRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string getCustChartOfAccount()
        {
            string result;
            CustomerMaster customer = new CustomerMaster();
            result = AllRecord("COA", customer);
            return result;
        }

        public string getCustomerMaster()
        {
            string result;
            CustomerMaster customer = new CustomerMaster();
            result = AllRecord("SA", customer);
            return result;
        }

        public String AllRecord(String action , CustomerMaster customer)
        {
            string result;
            OracleDataAdapter obj_ORCL = new OracleDataAdapter("CROL_dml_custmaster_st", GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
            obj_ORCL.SelectCommand.Parameters.Add("p_Cust_Id", customer.p_Cust_Id);
            obj_ORCL.SelectCommand.Parameters.Add("p_cust_name", customer.p_cust_name);
            obj_ORCL.SelectCommand.Parameters.Add("p_contact_person", customer.p_contact_person);
            obj_ORCL.SelectCommand.Parameters.Add("p_contact_no", customer.p_contact_no);
            obj_ORCL.SelectCommand.Parameters.Add("p_email", customer.p_email);
            obj_ORCL.SelectCommand.Parameters.Add("p_user_cd", customer.p_user_cd);
            obj_ORCL.SelectCommand.Parameters.Add("p_COANO", customer.p_COANO);
            obj_ORCL.SelectCommand.Parameters.Add("p_upddate_cd", customer.p_upddate_cd);
            obj_ORCL.SelectCommand.Parameters.Add("p_rowid", customer.p_rowid);
            obj_ORCL.SelectCommand.Parameters.Add("p_action", action);
            obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor ).Direction = ParameterDirection.Output;
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

            return result;
        }

        public string insertCustomerMaster(CustomerMaster customer)
        {
            string result;
            result = AllRecord("I", customer);
            return result;
        }

        public string updateCustomerMaster(CustomerMaster customer)
        {
            string result;
            result = AllRecord("U", customer);
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

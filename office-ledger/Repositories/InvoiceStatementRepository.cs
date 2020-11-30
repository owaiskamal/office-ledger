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
    public class InvoiceStatementRepository : IInvoiceStatement
    {
        IConfiguration configuration;

        public InvoiceStatementRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string getInvBusinessUnits()
        {
            string result;

            //invoiceStatement.
            result = AllStored("BU", null);
            return result;
        }



        public String AllStored(String action, InvoiceStatement invoiceStatement)
        {
            string result;
            if (invoiceStatement == null)
            {
                
                OracleDataAdapter obj_ORCL = new OracleDataAdapter("Crol_dml_inv_st", this.GetConnection().ConnectionString);
                obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
                obj_ORCL.SelectCommand.BindByName = true;
                obj_ORCL.SelectCommand.Parameters.Add("p_custid", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_invoiceno", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_invoicedate", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_crfno", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_orderno", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_invamount", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_gstamount", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_totalamount", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_recamount", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_busunit", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_costid", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_remarks", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_usercd", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_updusercd", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_action", action);
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

            
            OracleDataAdapter obj_ORCL = new OracleDataAdapter("Crol_dml_inv_st", this.GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
            obj_ORCL.SelectCommand.Parameters.Add("p_custid", invoiceStatement.custID);
            obj_ORCL.SelectCommand.Parameters.Add("p_invoiceno", invoiceStatement.invoiceNo);
            obj_ORCL.SelectCommand.Parameters.Add("p_invoicedate", invoiceStatement.invoiceDate);
            obj_ORCL.SelectCommand.Parameters.Add("p_crfno", invoiceStatement.crfNo);
            obj_ORCL.SelectCommand.Parameters.Add("p_orderno", invoiceStatement.orderNo);
            obj_ORCL.SelectCommand.Parameters.Add("p_invamount", invoiceStatement.invoiceAmount);
            obj_ORCL.SelectCommand.Parameters.Add("p_gstamount", invoiceStatement.gstAmount);
            obj_ORCL.SelectCommand.Parameters.Add("p_totalamount", invoiceStatement.totalAmount);
            obj_ORCL.SelectCommand.Parameters.Add("p_recamount", invoiceStatement.recAmount);
            obj_ORCL.SelectCommand.Parameters.Add("p_busunit", invoiceStatement.busUnit);
            obj_ORCL.SelectCommand.Parameters.Add("p_costid", invoiceStatement.costID);
            obj_ORCL.SelectCommand.Parameters.Add("p_remarks", invoiceStatement.remarks);
            obj_ORCL.SelectCommand.Parameters.Add("p_usercd", invoiceStatement.userCD);
            obj_ORCL.SelectCommand.Parameters.Add("p_updusercd", invoiceStatement.upUserCD);
            obj_ORCL.SelectCommand.Parameters.Add("p_action", action);
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
            return result;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }

        public string insertInvoiceStatement(InvoiceStatement invoiceStatement)
        {
            string result;
            result = AllStored("I", invoiceStatement);

            return result;
        }

        public string updateInvoiceStatement(InvoiceStatement invoiceStatement)
        {
            string result;
            result = AllStored("U", invoiceStatement);
            return result;
        }

        public string getInvCustID()
        {
            string result;

            result = AllStored("CID", null);
            return result;
        }

        public string getInvoiceStatement()
        {
            string result;
            result = AllStored("SA", null);
            return result;
        }

        public string getInvCostCenters()
        {
            string result;
            result = AllStored("CC", null);
            return result;
        }
    }

    
}

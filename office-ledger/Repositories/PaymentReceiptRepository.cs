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
    public class PaymentReceiptRepository : IPaymentReceipt
    {
        IConfiguration configuration;

        public PaymentReceiptRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }

       

        public string allRecord(string action , PaymentReceipt paymentReceipt)
        {

            string result;
            if (paymentReceipt == null)
            {

            OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_payment_rec_st", GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
            obj_ORCL.SelectCommand.Parameters.Add("p_recno", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_recdt", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_paymode", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_payref#", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_chequedt", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_totrecamount", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_busunit", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_totwht", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_totnetamount", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_invoiceno", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_invoicedt", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_customerid", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_whtgst", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_user_cd", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_upduser_cd", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_upddate", "");
            obj_ORCL.SelectCommand.Parameters.Add("p_rowid", "");
            obj_ORCL.SelectCommand.Parameters.Add("P_Action", action);
            obj_ORCL.SelectCommand.Parameters.Add("p_dataset", "");
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
                OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_payment_rec_st", GetConnection().ConnectionString);
                obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
                obj_ORCL.SelectCommand.BindByName = true;
                obj_ORCL.SelectCommand.Parameters.Add("p_recno", paymentReceipt.p_recno);
                obj_ORCL.SelectCommand.Parameters.Add("p_recdt", paymentReceipt.p_recdt);
                obj_ORCL.SelectCommand.Parameters.Add("p_paymode", paymentReceipt.p_paymode);
                obj_ORCL.SelectCommand.Parameters.Add("p_payref#", paymentReceipt.p_payref);
                obj_ORCL.SelectCommand.Parameters.Add("p_chequedt", paymentReceipt.p_chequedt);
                obj_ORCL.SelectCommand.Parameters.Add("p_totrecamount", paymentReceipt.p_totrecamount);
                obj_ORCL.SelectCommand.Parameters.Add("p_busunit", paymentReceipt.p_busunit);
                obj_ORCL.SelectCommand.Parameters.Add("p_totwht", paymentReceipt.p_totwht);
                obj_ORCL.SelectCommand.Parameters.Add("p_totnetamount", paymentReceipt.p_totnetamount);
                obj_ORCL.SelectCommand.Parameters.Add("p_invoiceno", paymentReceipt.p_invoiceno);
                obj_ORCL.SelectCommand.Parameters.Add("p_invoicedt", paymentReceipt.p_invoicedt);
                obj_ORCL.SelectCommand.Parameters.Add("p_customerid", paymentReceipt.p_customerid);
                obj_ORCL.SelectCommand.Parameters.Add("p_whtgst", paymentReceipt.p_whtgst);
                obj_ORCL.SelectCommand.Parameters.Add("p_user_cd", paymentReceipt.p_user_cd);
                obj_ORCL.SelectCommand.Parameters.Add("p_upduser_cd", paymentReceipt.p_upduser_cd);
                obj_ORCL.SelectCommand.Parameters.Add("p_upddate", paymentReceipt.p_upddate);
                obj_ORCL.SelectCommand.Parameters.Add("p_rowid", paymentReceipt.p_rowid);
                obj_ORCL.SelectCommand.Parameters.Add("P_Action", action);
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

        
        public string getPayInvoicePayment()
        {
            string result;
            result = allRecord("INV", null);
            return result;
        }

        public string getPaymentReceipt()
        {
            string result;
            result = allRecord("SA", null);
            return result;
        }

        public string insertPaymentReceipt(PaymentReceipt paymentReceipt)
        {
            string result;
            result = allRecord("I", paymentReceipt);
            return result;
        }

        public string updatePaymentReceipt(PaymentReceipt paymentReceipt)
        {
            string result;
            result = allRecord("U", paymentReceipt);
            return result;
        }
    }
}

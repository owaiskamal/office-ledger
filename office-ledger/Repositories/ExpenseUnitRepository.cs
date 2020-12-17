using Microsoft.Extensions.Configuration;
using office_ledger.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace office_ledger.Repositories
{
    public class ExpenseUnitRepository : IExpenseUnit
    {
        IConfiguration configuration;

        public ExpenseUnitRepository(IConfiguration _config)
        {
            configuration = _config;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }


        public String AllRecords(String action, ExpenseUnits expenseUnits)
        {
            string result;
            if (expenseUnits == null)
            {
                OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_EXPENSEMST_TR", GetConnection().ConnectionString);
                obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
                obj_ORCL.SelectCommand.BindByName = true;
                obj_ORCL.SelectCommand.Parameters.Add("p_buunit", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_EXPTRANSNO", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_EXPDATE", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_PARTICULARS", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_AMOUNT", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_VOCHNO", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_CHQREFNO", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_CHQREFDT", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_USER_CD", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_INSDATE", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_UPDDATE", "");
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
                OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_EXPENSEMST_TR", GetConnection().ConnectionString);
                obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
                obj_ORCL.SelectCommand.BindByName = true;
                obj_ORCL.SelectCommand.Parameters.Add("p_buunit", expenseUnits.p_buunit);
                obj_ORCL.SelectCommand.Parameters.Add("p_EXPTRANSNO", expenseUnits.p_EXPTRANSNO);
                obj_ORCL.SelectCommand.Parameters.Add("p_EXPDATE", expenseUnits.p_EXPDATE) ;
                obj_ORCL.SelectCommand.Parameters.Add("p_PARTICULARS", expenseUnits.p_PARTICULARS);
                obj_ORCL.SelectCommand.Parameters.Add("p_AMOUNT", expenseUnits.p_AMOUNT);
                obj_ORCL.SelectCommand.Parameters.Add("p_VOCHNO", expenseUnits.p_VOCHNO);
                obj_ORCL.SelectCommand.Parameters.Add("p_CHQREFNO", expenseUnits.p_CHQREFNO);
                obj_ORCL.SelectCommand.Parameters.Add("p_CHQREFDT", expenseUnits.p_CHQREFDT);
                obj_ORCL.SelectCommand.Parameters.Add("p_USER_CD", expenseUnits.p_USER_CD);
                obj_ORCL.SelectCommand.Parameters.Add("p_INSDATE", expenseUnits.p_INSDATE);
                obj_ORCL.SelectCommand.Parameters.Add("p_UPDDATE", expenseUnits.p_UPDDATE);
                obj_ORCL.SelectCommand.Parameters.Add("p_rowid", expenseUnits.p_rowid);
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



        public string getExpBusinessUnits()
        {
            string result;

            result = AllRecords("BU", null);

            return result;

        }

        public string getExpenseUnits(ExpenseUnits expense)
        {
            string result;

            result = AllRecords("SA", expense);

            return result;
        }

        public string insertExpenseUnit(ExpenseUnits expenseUnits)
        {
            string result;

            XmlSerializer xs = new XmlSerializer(typeof(ExpenseUnits));

            StringWriter textWriter = new StringWriter();
            xs.Serialize(textWriter, expenseUnits);


            var xml = textWriter.ToString();

            result = AllRecords("I", expenseUnits);

            return result;
        }

        
    }
}

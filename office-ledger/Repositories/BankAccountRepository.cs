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
    public class BankAccountRepository: IBankAccount
    {
        IConfiguration configuration;

        public BankAccountRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public String AllRecord(String action, BankAccount bankAccount)
        {
            string result;
            if(bankAccount == null)
            {
                OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_bankaccnt_st", GetConnection().ConnectionString);
                obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
                obj_ORCL.SelectCommand.BindByName = true;
                obj_ORCL.SelectCommand.Parameters.Add("p_bankno", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_bankcode", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_bankname", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_usercd", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_rowid", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_updusercd", "");
                obj_ORCL.SelectCommand.Parameters.Add("p_action", action);
                obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable bank_dt = new DataTable();
                try
                {
                    obj_ORCL.Fill(bank_dt);
                    result = Newtonsoft.Json.JsonConvert.SerializeObject(bank_dt);
                }
                catch (Exception ex)
                {

                    result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
                }
                finally
                {
                    obj_ORCL.Dispose();
                    bank_dt.Dispose();
                }
                return result;
            }
            else
            {
                OracleDataAdapter obj_ORCL = new OracleDataAdapter("crol_dml_bankaccnt_st", GetConnection().ConnectionString);
                obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
                obj_ORCL.SelectCommand.BindByName = true;
                obj_ORCL.SelectCommand.Parameters.Add("p_bankno", bankAccount.bankNo);
                obj_ORCL.SelectCommand.Parameters.Add("p_bankcode", bankAccount.bankCode);
                obj_ORCL.SelectCommand.Parameters.Add("p_bankname", bankAccount.bankName);
                obj_ORCL.SelectCommand.Parameters.Add("p_usercd", bankAccount.userCd);
                obj_ORCL.SelectCommand.Parameters.Add("p_rowid", bankAccount.row_id);
                obj_ORCL.SelectCommand.Parameters.Add("p_updusercd", bankAccount.upUserCd);
                obj_ORCL.SelectCommand.Parameters.Add("p_action", action);
                obj_ORCL.SelectCommand.Parameters.Add("p_dataset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable bank_dt = new DataTable();
                try
                {
                    obj_ORCL.Fill(bank_dt);
                    result = Newtonsoft.Json.JsonConvert.SerializeObject(bank_dt);
                }
                catch (Exception ex)
                {

                    result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
                }
                finally
                {
                    obj_ORCL.Dispose();
                    bank_dt.Dispose();
                }
                return result;
            }
        }
        public string getBankAccounts()
        {
            String result;
            result = AllRecord("SA", null);
            return result;
        }

        public string insertBankAccount(BankAccount bankAccount)
        {
            String result;
            result = AllRecord("I", bankAccount);
            return result;
        }

        public string updateBankAccount(BankAccount bankAccount)
        {
            String result;
            result = AllRecord("U", bankAccount);
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

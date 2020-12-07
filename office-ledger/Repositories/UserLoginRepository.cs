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
    public class UserLoginRepository: IUserLogin
    {
        IConfiguration configuration;

        public UserLoginRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
        public string getUserLogin(UserLogin userLogin)
        {
            string result;
            OracleDataAdapter obj_ORCL = new OracleDataAdapter("GET_LOGIN", GetConnection().ConnectionString);
            obj_ORCL.SelectCommand.CommandType = CommandType.StoredProcedure;
            obj_ORCL.SelectCommand.BindByName = true;
            obj_ORCL.SelectCommand.Parameters.Add("muser_cd", userLogin.user_cd);
            obj_ORCL.SelectCommand.Parameters.Add("mpassword", userLogin.password);
            obj_ORCL.SelectCommand.Parameters.Add("muser_ip", userLogin.user_ip);
            obj_ORCL.SelectCommand.Parameters.Add("p_getdata", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable login_dt = new DataTable();
            try
            {
                obj_ORCL.Fill(login_dt);
                var res = login_dt.Rows[0][":B1"];
                result = res.ToString();
            }
            catch (Exception ex)
            {
                result = Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);

            }
            finally
            {
                obj_ORCL.Dispose();
                login_dt.Dispose();
            }
            return result;
        }

      
    }
}

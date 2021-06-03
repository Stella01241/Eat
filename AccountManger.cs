using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication11.Models;

namespace WebApplication11
{
    public class AccountManger
    {

        public static string GetConnectionString()
        {
            var manage = System.Configuration.ConfigurationManager.ConnectionStrings["systemDataBase"];

            if (manage == null)
                return string.Empty;
            else
                return manage.ConnectionString;
        }
        //抓帳號資料
        public static DataTable GetAccount(string account)
        {
            string connectionString = GetConnectionString();
            string queryString =
                $@" SELECT * FROM UserAccount
                    WHERE UserAccount.Account = @account;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@account", account);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

    }
}
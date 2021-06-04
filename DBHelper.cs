using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public class DBHelper
    {
        public int ExecuteNonQuery(string dbCommand, List<SqlParameter> parameters)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(dbCommand, connection);

                List<SqlParameter> parameters2 = new List<SqlParameter>();
                foreach (var item in parameters)
                {
                    parameters2.Add(new SqlParameter(item.ParameterName, item.Value));

                }
                command.Parameters.AddRange(parameters2.ToArray());

                connection.Open();
                SqlTransaction sqlTransaction = connection.BeginTransaction();
                command.Transaction = sqlTransaction;

                try
                {
                    int totalChange = command.ExecuteNonQuery();
                    sqlTransaction.Commit();

                    return totalChange;

                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();

                    throw;
                }

            }

        }


        public static string GetConnectionString()
        {
            var manage = System.Configuration.ConfigurationManager.ConnectionStrings["systemDataBase"];

            if (manage == null)
                return string.Empty;
            else
                return manage.ConnectionString;
        }
        //方法
        public void Getshop(ref DropDownList dropDownList)
        {
            //取得連線字串
            string connectionstrimg = GetConnectionString();
            string queryString = $@"SELECT * FROM Shop;";
            //連線資料庫
            SqlConnection connection = new SqlConnection(connectionstrimg);
            SqlCommand command = new SqlCommand(queryString,connection);
            connection.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                dropDownList.DataSource = dt;
                //資料的值
                dropDownList.DataValueField = "ShopID";
                dropDownList.DataTextField = "ShopName";
               
                dropDownList.DataBind();
                dropDownList.Items.Insert(0,"請選擇店家");
                dropDownList.SelectedIndex = 0;

            }
            connection.Close();
        }

        public static void InsertGroup(int Group_Shop, int Group_AccountID, string Group_Leader, string Group_status, string Group_Img ,string Group_Name)
        {
            string connectionstrimg = GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connectionstrimg))
            {
                conn.Open();
                string queryString =
               $@"
                INSERT INTO Group
                    (Group_Shop ,Group_AccountID,Group_Leader, Group_status, GroupLeaderAccount,GroupPicture)
                VALUES
                    (@);
                ";

                SqlCommand command = new SqlCommand(queryString, conn);

                try
                {
                    command.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex.Message);
                }
            }
        }
    }
}
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
                dropDownList.DataValueField = "Shop_MenuID";
                dropDownList.DataBind();
                dropDownList.Items.Insert(0,"請選擇店家");
                dropDownList.SelectedIndex = 0;

            }
            connection.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication11.Helper;


namespace WebApplication11
{
    public partial class Create_Group : System.Web.UI.Page
    {
       
       
        //存檔路徑
       

            protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Account"] == null)
            //{
            //    Response.Redirect("HomePage.aspx");

              //如果不是登入狀態，就跳回登入頁
              // Response.Write("<script>alert('請先登入');window.location.href='./Login.aspx'</script>");
            //}

            if (!IsPostBack)
            {
                DBHelper ListHelp = new DBHelper();
                ListHelp.Getshop(ref DropDownList1);

            }

        }

        protected void OK_Click(object sender, EventArgs e)
        {                                     //移除開頭結尾所有空白字元
            string GroupName = this.Group.Text.Trim();
            int ShopID = int.Parse(this.DropDownList1.SelectedValue);
            string Group_Account = Session["Account"].ToString();
            UploadHelper upload = new UploadHelper();
                                               //拿到新的檔案名稱
            string pic1 = upload.GetNewFileName(this.Upload);


            if (string.IsNullOrEmpty(GroupName))
            {
                this.Err_Message.Text = "請輸入團名";
                return;
            }
            string queryString =
              $@"
                INSERT INTO [Group]
                    (Group_Shop , Group_Leader, Group_status, Group_Img,Group_Name)
                VALUES
                     (@Group_Shop , @Group_Leader, @Group_status, @Group_Img, @Group_Name)
                ";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Group_Shop", ShopID),
                new SqlParameter("@Group_Leader",  Group_Account),
                new SqlParameter("@Group_status","未結團"),
                new SqlParameter("@Group_Img",pic1 ),               
                new SqlParameter("@Group_Name", GroupName)
            };
            DBHelper dBHelper = new DBHelper();
            dBHelper.ExecuteNonQuery(queryString, parameters);


        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            this.Group.Text = null;

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}
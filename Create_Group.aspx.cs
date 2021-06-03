using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication11.Helper;

namespace WebApplication11
{
    public partial class Create_Group : System.Web.UI.Page
    {
        private string[] _allowExts ={".jpg" , ".png" , ".bmp" , ".gif" ,".jpeg" };
        private string _saveFolder = "~/Uploadpic/";
        


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LoginHelper.HasLogined())
            {
                //如果不是登入狀態，就跳回登入頁
                Response.Write("<script>alert('請先登入');window.location.href='./Login.aspx'</script>");
            }

            if (!IsPostBack)
            {
                DBHelper ListHelp = new DBHelper();
                ListHelp.Getshop(ref DropDownList1);

            }

        }

        protected void OK_Click(object sender, EventArgs e)
        {
            

        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}
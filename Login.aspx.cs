using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication11.Helper;

namespace WebApplication11
{
    public partial class Login : System.Web.UI.Page
    {
        private const string _sessionKey = "IsLogined";
        protected void Page_Load(object sender, EventArgs e)
 
        {
            bool? val = this.Session[_sessionKey] as bool?;
           if(val.HasValue && val.Value)
            this.ltMessage.Text = "Success";

        }
       
        protected void Loginn_Click(object sender, EventArgs e)
        {
         
            if (string.IsNullOrEmpty(txtAccount.Text)||string.IsNullOrEmpty(txtPassword.Text))
            {
                this.ltMessage.Text = "請輸入帳號密碼";
                this.ltMessage.Visible = true;
                return;
            }
            if (LoginHelper.TryLogin(txtAccount.Text, txtPassword.Text))
            {
                Response.Redirect("HomePage.aspx");

            }
            else
            {
                this.ltMessage.Text = "帳號或密碼錯誤";
                this.ltMessage.Visible = true;
                return;
            }
            
               
        
        }
    }
}
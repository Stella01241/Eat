using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class Create_Group : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string querryString = Request.QueryString["Sid"];
            if (string.IsNullOrEmpty(querryString))
            {
                return;
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
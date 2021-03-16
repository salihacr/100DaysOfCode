using System;

namespace BlogApp.Asp_Net_Web_Forms.MasterPages
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null && Session["Role"].ToString() != "Admin") Response.Redirect("../Auth/Login.aspx");
        }
        protected void Logout_Button_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Auth/Login.aspx");
        }
    }
}
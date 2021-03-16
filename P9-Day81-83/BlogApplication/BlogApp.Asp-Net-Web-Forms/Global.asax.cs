using BlogApp.Asp_Net_Web_Forms.SeedDatabase;
using System;

namespace BlogApp.Asp_Net_Web_Forms
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Seed Database (Users, Categories, Blogs)         
            SeedDb.Seed();
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 80;
            //TimeOut özelliğine aktarılacak değer dakika olarak aktarılmaktadır.
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
using BlogApp.Asp_Net_Web_Forms.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogApp.Asp_Net_Web_Forms.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection connection = MyConnection.GetConnection();
        Helpers.Auth authManager = new Helpers.Auth();
        Helpers.DbManager dbManager = new DbManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Button_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                Response.Write("Already Logged");
                return;
            }
            if (SignIn().Equals("Successfully Login"))
            {
                string route = Session["Role"].ToString() == "Admin" ? "/Admin/Blogs.aspx" : "/App/Welcome.aspx";
                Response.Redirect(route, false); // try catch içinde response false eklenir
            }
        }
        public string SignIn()
        {
            string inputPasswordHash = authManager.CreatePasswordHash(txtPassword.Value.ToString());

            string query = "Select * From Users Where Email=@Email AND Password=@Password";
            try
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@Password", inputPasswordHash);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read() || !reader.HasRows)
                {
                    string role = reader["RoleName"].ToString();
                    Session["UserId"] = reader["UserId"].ToString();
                    Session["Role"] = reader["RoleName"].ToString();
                    Session["Username"] = reader["Username"].ToString();
                    Session["Image"] = reader["Image"].ToString();

                    return "Successfully Login";
                }
                if (!reader["Password"].Equals(inputPasswordHash))
                {
                    return "Wrong Password";
                }
                reader.Close();
                connection.Close();

                return "Email or Password not found.";
            }
            catch (Exception e)
            {
                return e + "Unexpected Error";
            }
        }
    }
}
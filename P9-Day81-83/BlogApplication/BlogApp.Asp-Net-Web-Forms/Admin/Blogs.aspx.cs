using BlogApp.Asp_Net_Web_Forms.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogApp.Asp_Net_Web_Forms.Admin
{
    public partial class Blogs : System.Web.UI.Page
    {
        static SqlConnection connection = MyConnection.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string GetBlogList()
        {
            connection.Open();
            string _data = "";
            string query = "Select * From Blogs";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connection.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                _data = JsonConvert.SerializeObject(ds.Tables[0]);
            }
            return _data;
        }
        [WebMethod]
        public static void Delete(string blogId)
        {
            connection.Open();
            string query = "Delete From Blogs Where BlogId=@blogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@blogId", blogId);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
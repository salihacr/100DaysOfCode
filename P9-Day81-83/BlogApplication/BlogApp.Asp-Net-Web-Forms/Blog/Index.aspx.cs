using BlogApp.Asp_Net_Web_Forms.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogApp.Asp_Net_Web_Forms.Blog
{
    public partial class Index : System.Web.UI.Page
    {
        static SqlConnection connection = MyConnection.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = "Select Blogs.BlogName, Blogs.BlogURL, Blogs.CreationDate, Blogs.BlogContent,Categories.CategoryName, Users.Username From Blogs" +
               " INNER JOIN Categories ON Categories.CategoryId = Blogs.BlogCategoryId" +
               " INNER JOIN Users ON Users.UserId = Blogs.BlogUserId";
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            rptBlogs.DataSource = dataTable;
            rptBlogs.DataBind();
            connection.Close();
        }
    }
}
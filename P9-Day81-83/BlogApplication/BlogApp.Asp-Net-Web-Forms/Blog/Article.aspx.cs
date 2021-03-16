using BlogApp.Asp_Net_Web_Forms.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogApp.Asp_Net_Web_Forms.Blog
{
    public partial class Article : System.Web.UI.Page
    {
        static SqlConnection connection = MyConnection.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string GetBlogByUrl(string url)
        {
            string _data = "";
            string query = "Select Blogs.BlogName, Blogs.BlogURL, Blogs.CreationDate, Blogs.BlogContent,Categories.CategoryName, Users.Username, Comments.CommentText, Comments.Commenter, Comments.IsApproved From Blogs" +
                " INNER JOIN Categories ON Categories.CategoryId = Blogs.BlogCategoryId" +
                " INNER JOIN Users ON Users.UserId = Blogs.BlogUserId" +
                " INNER JOIN Comments ON Comments.BlogId = Blogs.BlogId" +
                " Where BlogURL = @blogUrl";

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@blogUrl", url);



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            connection.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                _data = JsonConvert.SerializeObject(ds.Tables[0]);
            }
            return _data;
        }
        [WebMethod]
        public static void AddComment(string comment, string commenter, string blogUrl)
        {
            string blogId = GetBlogId(blogUrl);
            string query = "Insert Comments(CommentText, Commenter, IsApproved, BlogId) VALUES(@comment, @commenter, @isApproved, @blogId)";
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Connecting)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@comment", comment);
            cmd.Parameters.AddWithValue("@commenter", commenter);
            cmd.Parameters.AddWithValue("@isApproved", false);
            cmd.Parameters.AddWithValue("@blogId", blogId);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static string GetBlogId(string blogUrl)
        {
            string blogId = "";
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Blogs Where BlogUrl=@blogUrl", connection);
            cmd.Parameters.AddWithValue("@blogUrl", blogUrl);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                blogId = reader["BlogId"].ToString();
            }
            connection.Close();
            return blogId;
        }
    }
}
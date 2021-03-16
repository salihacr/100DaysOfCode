using System;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;
using BlogApp.Asp_Net_Web_Forms.Helpers;

namespace BlogApp.Asp_Net_Web_Forms.Admin
{
    public partial class AddBlog : System.Web.UI.Page
    {
        static SqlConnection connection = MyConnection.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }
        public void LoadCategories()
        {
            ddlCategories.Items.Insert(0, new ListItem("Lütfen Seçim Yapınız...", "0"));

            string query = "SELECT * FROM Categories";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListItem list = new ListItem();
                list.Text = dr["CategoryName"].ToString();
                list.Value = dr["CategoryId"] + "";
                ddlCategories.Items.Add(list);
            }
            connection.Close();
        }

        [WebMethod]
        public static void InsertBlog(string blogName, string blogUrl, string blogContent, int blogCategoryId, string blogUserId)
        {
            string blogId = Guid.NewGuid().ToString();

            string query = "Insert Blogs(BlogId, BlogName, BlogUrl, BlogContent, CreationDate,BlogCategoryId, BlogUserId) Values" +
                "(@blogId, @blogName, @blogUrl, @blogContent, @creationDate,@blogCategoryId, @blogUserId)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@blogId", blogId);
            cmd.Parameters.AddWithValue("@blogName", blogName);
            cmd.Parameters.AddWithValue("@blogUrl", blogUrl);
            cmd.Parameters.AddWithValue("@blogContent", blogContent);
            cmd.Parameters.AddWithValue("@creationDate", DateTime.Now.ToShortDateString().ToString());
            cmd.Parameters.AddWithValue("@blogCategoryId", blogCategoryId);
            cmd.Parameters.AddWithValue("@blogUserId", blogUserId);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
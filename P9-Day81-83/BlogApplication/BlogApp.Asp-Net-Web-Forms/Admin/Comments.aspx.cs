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
    public partial class Comments : System.Web.UI.Page
    {
        static SqlConnection connection = MyConnection.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //GetEmpData WebMethod is used to fetch data from the tblEmployee Table.
        [WebMethod]
        public static string GetAll()
        {
            connection.Open();
            string _data = "";

            string query = "Select Comments.CommentId, Comments.CommentText, Comments.Commenter, Comments.IsApproved, Blogs.BlogName From Comments" +
                " INNER JOIN Blogs ON Blogs.BlogId = Comments.BlogId";
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
        //Edit WebMethod is used to Edit data from tblEmployee Table.
        [WebMethod]
        public static string Edit(int commentId)
        {
            string _data = "";
            connection.Open();
            string query = "Select * From Comments where CommentId=@commentId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@commentId", commentId);
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
        //Update WebMethod accept Id, Name, Address, Age values. Based on this Id update data in the tblEmployee Table.
        [WebMethod]
        public static void Update(int commentId, string isApproved)
        {
            bool approve = isApproved.Equals("true") ? false : true;
            connection.Open();
            string query = "Update Comments Set IsApproved=@isApproved WHERE CommentId=@commentId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@commentId", commentId);
            cmd.Parameters.AddWithValue("@isApproved", approve);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //Delete WebMethod is used to delete data from the tblEmployee Table.
        [WebMethod]
        public static void Delete(int commentId)
        {
            connection.Open();
            string query = "Delete FROM Comments Where CommentId=@commentId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CommentId", commentId);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
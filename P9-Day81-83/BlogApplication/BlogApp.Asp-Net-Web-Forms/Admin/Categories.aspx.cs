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
    public partial class Categories : System.Web.UI.Page
    {
        static SqlConnection connection = MyConnection.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static void AddCategory(string categoryName)
        {
            connection.Open();
            string query = "Insert Categories(CategoryName) VALUES(@CategoryName)";
            //SqlCommand cmd = new SqlCommand("SP_Add_Category", connection);
            SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //GetEmpData WebMethod is used to fetch data from the tblEmployee Table.
        [WebMethod]
        public static string GetAll()
        {
            connection.Open();
            string _data = "";
            SqlCommand cmd = new SqlCommand("SP_Get_Categories", connection);
            cmd.CommandType = CommandType.StoredProcedure;
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
        public static string Edit(int categoryId)
        {
            string _data = "";
            connection.Open();
            SqlCommand cmd = new SqlCommand("SP_Edit_Category", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
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
        public static void Update(int categoryId, string categoryName)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SP_Update_Category", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //Delete WebMethod is used to delete data from the tblEmployee Table.
        [WebMethod]
        public static void Delete(int categoryId)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SP_Delete_Category", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
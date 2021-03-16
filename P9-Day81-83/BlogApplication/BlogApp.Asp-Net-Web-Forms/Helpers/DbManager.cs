using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BlogApp.Asp_Net_Web_Forms.Helpers
{
    public class DbManager
    {
        SqlConnection connection = MyConnection.GetConnection();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="customQuery"></param>
        /// <returns></returns>
        public DataTable GetAll(string tableName, string customQuery = "")
        {
            string query = customQuery == "" ? "Select * From " + tableName : customQuery;
            SqlCommand command = new SqlCommand(query);
            //connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                var table = new DataTable();
                table.Load(reader);
                return table;
            }
        }

        public SqlDataReader GetByData<T>(string tableName, string columnName, T data)
        {
            string query = "Select * From " + tableName + " WHERE " + columnName + " = " + data;
            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@" + columnName, data);
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                return reader;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool Add(string tableName, string[] columns, object[] values)
        {
            string parameterText = QueryParametersGenerate(columns);
            try
            {
                string query = "INSERT " + tableName + "(" + GetParameters(columns) + ") VALUES (" + parameterText + ")";
                AddOrEdit(query, columns, values);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <param name="whichColumn"></param>
        /// <param name="columns"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool UpdateData(string tableName, string whichColumn, object data, string[] columns, object[] values)
        {
            string parameterText = QueryParametersGenerate(columns);
            try
            {
                string query = "UPDATE " + tableName + " SET " + parameterText + " where " + whichColumn + "=" + "@" + whichColumn;
                AddOrEdit(query, columns, values, data, whichColumn);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="columns"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        private bool AddOrEdit(string query, string[] columns, object[] values, object data = null, string whichColumn = "")
        {
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    for (int i = 0; i < columns.Length; i++)
                    {
                        command.Parameters.AddWithValue("@" + columns[i], values[i]);
                    }
                    if (whichColumn != "")
                    {
                        command.Parameters.AddWithValue("@" + whichColumn, data);
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public string QueryParametersGenerate(string[] columns)
        {
            string parameterText = "";

            for (int i = 0; i <= columns.Length - 2; i++)
                parameterText += columns[i] + "=@" + columns[i] + ",";

            parameterText += columns[columns.Length - 1] + "=@" + columns[columns.Length - 1];
            return parameterText;
        }

        public string GetParameters(string[] columns)
        {
            string parameters = "";

            for (int i = 0; i <= columns.Length - 2; i++)
                parameters += columns[i] + ",";

            parameters += columns[columns.Length - 1];
            return parameters;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove<T>(string tableName, string columnName, T id)
        {
            try
            {
                string query = "DELETE FROM " + tableName + " WHERE " + columnName + " = " + id;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Exist<T>(string tableName, string columnName, T data)
        {
            try
            {
                string query = "SELECT COUNT( " + columnName + ") FROM " + tableName + " WHERE " + columnName + "=" + data;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //connection.Open();
                    int exist = Convert.ToInt32(command.ExecuteScalar());
                    //connection.Close();
                    return exist <= 0 ? false : true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsNull(string tableName)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM " + tableName;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int exist = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return exist <= 0 ? true : false;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        /// <summary>
        /// This function populate the dropdown list according to your settings.
        /// </summary>
        /// <param name="dropDownList">DropDownList from Web UI</param>
        /// <param name="query">Your custom query</param>
        /// <param name="columnToDisplay">The column name in the database for the text to display in the table.</param>
        /// <param name="valueToId">The id of the text to be displayed in the table is the column name in the database.</param>
        public void FillDropdown(DropDownList dropDownList, string tableName, string columnToDisplay, string columnToValue, string customQuery = "")
        {
            string query = customQuery == "" ? "Select * From " + tableName : customQuery;

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListItem listItem = new ListItem();
                        listItem.Text = reader[columnToDisplay].ToString();
                        listItem.Value = reader[columnToValue].ToString(); // or reader[columnToValue] + "";
                        dropDownList.Items.Add(listItem);
                    }
                }
                connection.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repeater"></param>
        /// <param name="tableName"></param>
        /// <param name="customQuery"></param>
        /// <returns></returns>
        public bool FillRepeater(Repeater repeater, string tableName, string customQuery = "")
        {
            try
            {
                DataTable data = customQuery == "" ? GetAll(tableName) : GetAll(tableName, customQuery);
                connection.Open();
                repeater.DataSource = data;
                repeater.DataBind();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
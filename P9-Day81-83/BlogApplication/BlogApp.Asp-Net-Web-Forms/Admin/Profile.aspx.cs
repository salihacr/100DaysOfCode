using BlogApp.Asp_Net_Web_Forms.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogApp.Asp_Net_Web_Forms.Admin
{
    public partial class Profile : System.Web.UI.Page
    {
        SqlConnection connection = MyConnection.GetConnection();
        Helpers.Auth authManager = new Helpers.Auth();
        DbManager dbManager = new DbManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }
        protected void Update_Profile_Button_Click(object sender, EventArgs e)
        {

            string gender = male.Checked == true ? "male" : female.Checked ? "female" : "";
            string image = CreateImage();
            lblImage.Text = image;
            string[] columns;
            object[] values;
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                columns = new string[] { "FullName", "Email", "Username", "Gender", "Image" };
                values = new object[] { txtName.Text, txtEmail.Value, txtUsername.Value, gender, lblImage.Text };
            }
            else
            {
                columns = new string[] { "FullName", "Email", "Username", "Gender", "Image", "Password" };
                values = new object[] { txtName.Text, txtEmail.Value, txtUsername.Value, gender, lblImage.Text, authManager.CreatePasswordHash(txtPassword.Text) };
            }
            // update ado.net with helper.dbmanager
            dbManager.UpdateData("Users", "UserId", Session["UserId"].ToString(), columns, values);
            Session["Username"] = txtUsername.Value;
            Session["Image"] = lblImage.Text;
        }

        private string CreateImage()
        {
            // get file name of posted image
            string imageName = profileImage.FileName;
            // set the image save path
            string imagePath = "../Images/Profile/" + imageName;

            int imageSize = profileImage.PostedFile.ContentLength;

            if (profileImage.PostedFile != null && profileImage.PostedFile.FileName != "")
            {
                if (imageSize > 10240000)
                {
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('file is too big')", true);
                    return "File is too big";
                }
                else
                {
                    profileImage.SaveAs(Server.MapPath(imagePath));
                    return imagePath;
                }
            }
            else
            {
                return "Image is null";
            }
        }
        private void GetData()
        {
            SqlCommand cmd = new SqlCommand("SELECT * from Users where UserId='" + Session["UserId"].ToString() + "'", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            txtName.Text = dt.Rows[0]["FullName"].ToString();
            txtEmail.Value = dt.Rows[0]["Email"].ToString();
            txtUsername.Value = dt.Rows[0]["Username"].ToString();
            lblImage.Text = dt.Rows[0]["Image"].ToString();

            bool check = dt.Rows[0]["Gender"].ToString().Equals("male") ? true : false;

            male.Checked = check;
            female.Checked = !check;

            Session["Image"] = dt.Rows[0]["Image"].ToString();
            Session["Username"] = dt.Rows[0]["Username"].ToString();
        }
    }
}
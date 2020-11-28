using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace MyImpenetrableSite
{
    public partial class Members : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Get the user id from the query string
                int userId = int.Parse(Request.QueryString["Id"].ToString());

                // SqlConnection object
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MISConnectionString"].ToString());

                string strSelect = "SELECT * FROM Users WHERE ID=" + userId;

                // SqlCommand
                SqlCommand cmdSelect = new SqlCommand(strSelect, conn);
                conn.Open();
                SqlDataReader reader = cmdSelect.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    lblUsername.Text = reader["Username"].ToString();
                    txtFirstName.Text = reader["FirstName"].ToString();
                    txtLastName.Text = reader["LastName"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                }
                reader.Close();
                conn.Close();
            }
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(Request.QueryString["Id"].ToString());
            //SqlConnection
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MISConnectionString"].ToString());

            // UPDATE statement
            string strUpdate = "UPDATE Users SET FirstName='" + txtFirstName.Text.Trim() + "', LastName='" + txtLastName.Text.Trim()
                    + "', Email='" + txtEmail.Text.Trim() + "', Phone='" + txtPhone.Text.Trim() + "' WHERE ID=" + userId;

            // SqlCommand
            SqlCommand cmdUpdate = new SqlCommand(strUpdate, conn);
            conn.Open();
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
    }
}
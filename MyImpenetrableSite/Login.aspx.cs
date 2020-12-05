using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;

namespace MyImpenetrableSite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Create a SQL connection object
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MISConnectionString"].ToString());

            // Create a SQL command object to query username
            string username = txtUsername.Text.Trim();
            string usernameQuery = "SELECT * FROM Users WHERE Username = @username";
            SqlCommand cmd = new SqlCommand(usernameQuery, conn);
            cmd.Parameters.Add(new SqlParameter("@username", username));
            conn.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            if (!sqlDataReader.HasRows)
            {
                lblLoginError.Text = "Incorrect username and/or password. Please try again.";
                conn.Close();
            }
            else
            {
                conn.Close();
                string password = txtPassword.Text.Trim();
                string strQuery = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
                cmd = new SqlCommand(strQuery, conn);
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    lblLoginError.Text = "Incorrect username and/or password. Please try again.";
                }
                else
                {
                    reader.Read();
                    int roleId = int.Parse(reader["RoleId"].ToString());
                    if (roleId == 1)  // Administrator
                    {
                        reader.Close();
                        conn.Close();
                        Session.Clear();
                        Session["roleId"] = roleId; // Set admin role id to session
                        Response.Redirect("Admin.aspx");
                    }
                    else
                    {
                        int statusId = int.Parse(reader["StatusId"].ToString());
                        string userId = reader["ID"].ToString();
                        reader.Close();
                        conn.Close();

                        if (statusId == 2)
                        {
                            lblLoginError.Text = "Your account is inactive. Please contact the administrator to deactivate your account first.";
                        }
                        else
                        {
                            Session.Clear();
                            Session["userId"] = userId; // Set user id to session
                            Response.Redirect("Members.aspx?Id=" + userId);
                        }

                    }
                }
            }
        }
    }
}
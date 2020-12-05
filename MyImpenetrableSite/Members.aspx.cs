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
            try
            {
                // Get the user id from the query string
                int userId = int.Parse(Request.QueryString["Id"].ToString());

                // Validate user query is equal to the user's id
                if (!Page.IsPostBack && (Session["userId"].ToString().Equals(userId.ToString())))
                {
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
                else if (!Page.IsPostBack && !(Session["userId"].ToString().Equals(userId.ToString())))
                    //Redirect unathorizaed page request back to current user
                    Response.Redirect("Members.aspx?Id=" + Session["userId"].ToString());
            }
            catch(System.NullReferenceException)
            {
                //Redirect anonymous page request
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(Request.QueryString["Id"].ToString());
            //SqlConnection
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MISConnectionString"].ToString());

            // UPDATE statement
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string strUpdate = "UPDATE Users SET FirstName = @firstname, LastName = @lastname, Email = @email, Phone = @phone WHERE ID = @userid";

            // SqlCommand
            SqlCommand cmdUpdate = new SqlCommand(strUpdate, conn);
            cmdUpdate.Parameters.Add(new SqlParameter("@firstname", firstName));
            cmdUpdate.Parameters.Add(new SqlParameter("@lastname", lastName));
            cmdUpdate.Parameters.Add(new SqlParameter("@email", email));
            cmdUpdate.Parameters.Add(new SqlParameter("@phone", phone));
            cmdUpdate.Parameters.Add(new SqlParameter("@userid", userId));
            conn.Open();
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
    }
}
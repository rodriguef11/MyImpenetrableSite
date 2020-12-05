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
    public partial class DeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Validate Admin role id
                if (Session["roleId"].ToString().Equals("1"))
                {
                    int userId = int.Parse(Request.QueryString["Id"].ToString());
                    // Create a SqlConnection object
                    SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MISConnectionString"].ToString());

                    // DELETE statement and SqlCommand object
                    // Actually, we don't delete the user. We just deactivate the user.
                    string strDelete = "UPDATE Users SET StatusId = 2 WHERE ID = @userid";
                    SqlCommand cmdDelete = new SqlCommand(strDelete, conn);
                    cmdDelete.Parameters.Add(new SqlParameter("@userid", userId));
                    conn.Open();
                    cmdDelete.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("Admin.aspx");
                }
                else
                    // Redirect if role id does not equal 1
                    Response.Redirect("Login.aspx");
            }
            catch (System.NullReferenceException)
            {
                // Redirect if there is no role id
                Response.Redirect("Login.aspx");
            }
        }
    }
}
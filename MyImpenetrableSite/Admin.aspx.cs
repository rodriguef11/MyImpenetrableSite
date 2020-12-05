﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Text;

namespace MyImpenetrableSite
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Validate Admin role id
                if (Session["roleId"].ToString().Equals("1"))
                {
                    // Create a SqlConnection object
                    SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MISConnectionString"].ToString());

                    // SQL equery and SqlCommand object
                    string strSelect = "SELECT * FROM Users ORDER BY LastName, FirstName ASC";
                    SqlCommand cmd = new SqlCommand(strSelect, conn);

                    // open the database connection
                    conn.Open();

                    // Retrieve the data and create an HTML string
                    SqlDataReader reader = cmd.ExecuteReader();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<div class='row'>");
                    sb.Append("<div class='col-md-12'>");
                    sb.Append("<a href='AddUser.aspx'>Add User</a>");
                    sb.Append("</div>");
                    sb.Append("<div class='col-md-12'>&nbsp;</div>");
                    sb.Append("</div>");
                    sb.Append("<div class='row'>");
                    sb.Append("<div class='col-md-12'>");
                    sb.Append("<table id='tblUsers' class='table table-striped'>");
                    sb.Append("<th>First Name</th>");
                    sb.Append("<th>Last Name</th>");
                    sb.Append("<th>Username</th>");
                    sb.Append("<th>Email</th>");
                    sb.Append("<th>Action</th>");
                    sb.Append("<tbody>");

                    while (reader.Read())
                    {
                        sb.Append("<tr>");

                        sb.Append("<td>");
                        sb.Append(reader["FirstName"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(reader["LastName"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(reader["Username"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(reader["Email"].ToString());
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append("<a href='DeleteUser.aspx?Id=");
                        sb.Append(reader["Id"].ToString());
                        sb.Append("'>Delete</a>&nbsp;<a href='EditUser.aspx?Id=");
                        sb.Append(reader["Id"].ToString());
                        sb.Append("'>Edit</a>");

                        sb.Append("</tr>");
                    }
                    sb.Append("<tbody>");
                    sb.Append("</table>");
                    sb.Append("</div></div>");
                    reader.Close();
                    conn.Close();
                    lblUsersList.Text = sb.ToString();
                }
                else
                    // Redirect if role id does not equal 1
                    Response.Redirect("Login.aspx");
            }
            catch(System.NullReferenceException)
            {
                // Redirect if there is no role id
                Response.Redirect("Login.aspx");
            }
            
        }        
    }
}
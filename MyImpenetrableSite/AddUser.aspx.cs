﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MyImpenetrableSite
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Session["roleId"].ToString().Equals("1"))
                    Response.Redirect("Login.aspx");
            }
            catch (System.NullReferenceException)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            // Create a SqlConnection object
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MISConnectionString"].ToString());

            // Autogenerate a username
            string firstName = Request.Form["txtFirstName"].ToString().Trim();
            string lastName = txtLastName.Text.Trim();
            string username = firstName[0].ToString().ToLower() + lastName.ToLower();
            string password = firstName + "." + lastName;
            string email = txtEmail.Text.Trim();
            string telephone = txtPhone.Text.Trim();
            string lastLoginTime = DateTime.Now.ToString();
            // INSERT statements and SqlCommand
            string strInsert = "INSERT INTO Users (FirstName, LastName, Email, Phone, Username, Password, RoleId, StatusId, LastLoginTime) " +
                "VALUES (@firstname, @lastname, @email, @telephone, @username, @password, 2, 1, @lastlogintime)";

            SqlCommand cmdInsert = new SqlCommand(strInsert, conn);
            cmdInsert.Parameters.Add(new SqlParameter("@firstname", firstName));
            cmdInsert.Parameters.Add(new SqlParameter("@lastname", lastName));
            cmdInsert.Parameters.Add(new SqlParameter("@email", email));
            cmdInsert.Parameters.Add(new SqlParameter("@telephone", telephone));
            cmdInsert.Parameters.Add(new SqlParameter("@username", username));
            cmdInsert.Parameters.Add(new SqlParameter("@password", password));
            cmdInsert.Parameters.Add(new SqlParameter("@lastlogintime", lastLoginTime));
            conn.Open();
            cmdInsert.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Admin.aspx");
        }
    }
}
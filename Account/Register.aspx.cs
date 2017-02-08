using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class Account_Register : System.Web.UI.Page
{
    public bool userExists;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["currentUser"]!=null)
        {
            Response.Redirect("~/Account/MyPage.aspx");
        }
        if(IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            String checkUserQuery = "SELECT COUNT(*) FROM Users WHERE andrewID = '" + andrewID.Text + "'";
            SqlCommand comm = new SqlCommand(checkUserQuery, conn);
            int count = Convert.ToInt32(comm.ExecuteScalar().ToString());
            if(count == 1)
            {
                userExists = true;
            }
            else
            {
                userExists = false;
            }
            conn.Close();
        }
    }
    protected void Submit(object sender, EventArgs e)
    {
        if (andrewID.Text.Length > 30)
        {
            tooLong.Text = "Your Andrew ID is a bit longer than expected.";
        }
        else if (name.Text.Length > 40)
        {
            tooLong.Text = "Wow! That is one long name!";
        }
        else if (password.Text.Length > 40)
        {
            tooLong.Text = "Security is important, but 40 characters for a password!?";
        }
        else if (hometown.Text.Length > 100)
        {
            tooLong.Text = "Please do not exeed the 100 character limit for the hometown text.";
        }
        else
        {
            if (userExists == false)
            {
                IDCheck.Text = "";
                pwCheck.Text = "";
                if (password.Text != password1.Text)
                {
                    pwCheck.Text = "Passwords do not match!";
                }
                else
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    conn.Open();
                    pwCheck.Text = "";
                    String insertQuery = "INSERT INTO [dbo].[Users] (andrewID, name, password, school, photo, class, hometown) VALUES (@andrewID, @name, @password, @school, @photo, @class, @hometown)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
                    insertCommand.Parameters.AddWithValue("@andrewID", andrewID.Text);
                    insertCommand.Parameters.AddWithValue("@name", name.Text);
                    insertCommand.Parameters.AddWithValue("@password", password.Text);
                    insertCommand.Parameters.AddWithValue("@school", schools.SelectedValue);
                    insertCommand.Parameters.AddWithValue("@photo", "false");
                    insertCommand.Parameters.AddWithValue("@class", classYear.SelectedValue);
                    insertCommand.Parameters.AddWithValue("@hometown", hometown.Text);
                    insertCommand.ExecuteNonQuery();
                    conn.Close();
                    Session["currentUser"] = andrewID.Text;
                    Response.Redirect("~/Account/MyPage.aspx");
                }
            }
            else
            {
                IDCheck.Text = "This Andrew ID is already registered, please login or use another ID.";
            }

        }
    }
}
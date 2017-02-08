using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;



public partial class Manager_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        managerPanel.Visible = false;
        if(Session["currentUser"] != null)
        {
            if (Session["currentUser"].ToString() != "lanbos" && Session["currentUser"].ToString() != "zeshengl")
            {
                Response.Redirect("~/");
            }
        }
        else
        {
            Response.Redirect("~/");
        }
        if(Session["currentUser"].ToString() == "lanbos")
        {
            managerPanel.Visible = true;
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        String getUserQuery = "SELECT COUNT(*) FROM Users WHERE photo = 'true'";
        String getTotUserQuery = "SELECT COUNT(*) FROM Users";
        SqlCommand getUserNum = new SqlCommand(getUserQuery, conn);
        SqlCommand getTotUserNum = new SqlCommand(getTotUserQuery, conn);
        conn.Open();
        int photoUsers = Convert.ToInt32(getUserNum.ExecuteScalar());
        int totalUsers = Convert.ToInt32(getTotUserNum.ExecuteScalar());
        conn.Close();
        numUser.Text = "There are " + totalUsers.ToString() + " users in total, and ";
        numUser.Text += photoUsers.ToString() + " of whom have uploaded their photos.";

        SqlDataSource wallData = new SqlDataSource();
        wallData.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        wallData.SelectCommand = "SELECT * FROM Wall ORDER BY Time DESC";
        wallRepeater.DataSource = wallData;
        wallRepeater.DataBind();

    }
    protected void DelPic(object sender, EventArgs e)
    {
        if (theIdNumber.Text != "")
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            int id = Convert.ToInt32(theIdNumber.Text);
            //check if exists
            String checkQuery = "SELECT COUNT(*) FROM Users WHERE Id = @theID ";
            SqlCommand checkCommand = new SqlCommand(checkQuery, conn);
            checkCommand.Parameters.AddWithValue("@theID", id);
            conn.Open();
            int temp = Convert.ToInt32(checkCommand.ExecuteScalar());
            if (temp == 1)
            {
                String updateQuery = "UPDATE Users SET photo = 'false' WHERE Id = @theID";
                SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
                updateCommand.Parameters.AddWithValue("@theID", id);
                updateCommand.ExecuteNonQuery();
                err.Text = "<font color='green'>Succeeded.</font>";
            }
            else
            {
                err.Text = "This person does not exist.";
            }
            conn.Close();
        }
        else
        {
            err.Text = "Enter key";
        }
    }
    protected void DelUser(object sender, EventArgs e)
    {
        if (theIdNumber.Text != "")
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            int id = Convert.ToInt32(theIdNumber.Text);
            //check if exists
            String checkQuery = "SELECT COUNT(*) FROM Users WHERE Id = @theID ";
            SqlCommand checkCommand = new SqlCommand(checkQuery, conn);
            checkCommand.Parameters.AddWithValue("@theID", id);
            conn.Open();
            int temp = Convert.ToInt32(checkCommand.ExecuteScalar());
            if (temp == 1)
            {
                String deleteQuery = "DELETE FROM Users WHERE Id = @theID";
                SqlCommand updateCommand = new SqlCommand(deleteQuery, conn);
                updateCommand.Parameters.AddWithValue("@theID", id);
                updateCommand.ExecuteNonQuery();
                err.Text = "<font color='green'>Succeeded.</font>";
            }
            else
            {
                err.Text = "This person does not exist.";
            }
            conn.Close();
        }
        else
        {
            err.Text = "Enter key";
        }
    }
    protected String getFullName(String andrew)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        String getNameQuery = "SELECT name FROM Users WHERE andrewID = @andrew";
        SqlCommand getName = new SqlCommand(getNameQuery, conn);
        getName.Parameters.AddWithValue("@andrew", andrew);
        conn.Open();
        String fullName;
        if(getName.ExecuteScalar()!=null)
        {
            fullName = getName.ExecuteScalar().ToString();
        }
        else
        {
            return "Nonexistant user";
        }
        conn.Close();
        return fullName;
    }
}
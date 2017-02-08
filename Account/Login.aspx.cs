using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["currentUser"] != null)
        {
            Response.Redirect("~/Account/MyPage.aspx");
        }
    }
    protected void Submit(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        conn.Open();
        String checkUserQuery = "SELECT COUNT(*) FROM Users WHERE andrewID = '" + andrewID.Text + "'";
        SqlCommand comm = new SqlCommand(checkUserQuery, conn);
        int count = Convert.ToInt32(comm.ExecuteScalar().ToString());
        conn.Close();
        checkID.Text = "";
        if(count == 1)
        {
            conn.Open();
            String checkPasswordQuery = "SELECT password FROM Users WHERE andrewID = '" + andrewID.Text + "'";
            SqlCommand checkPassword = new SqlCommand(checkPasswordQuery, conn);
            String myPassword = checkPassword.ExecuteScalar().ToString().Replace(" ","");
            checkPass.Text = "";
            conn.Close();
            if (myPassword == password.Text)
            {
                Session["currentUser"] = andrewID.Text;
                Response.Redirect("~/Account/MyPage.aspx");
            }
            else
            {
                checkPass.Text = "You are supposed to REMEMBER YOUR PASSWORD, so please enter the correct one.";
            }

        }
        else
        {
            checkID.Text = "This Andrew ID does not exist in our database yet, please register or enter a registered ID.";
            checkPass.Text = "";
        }
    }
}
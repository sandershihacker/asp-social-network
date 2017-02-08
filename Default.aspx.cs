using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class Default : System.Web.UI.Page
{
    private String myName;
    private int numUsers;
    private int numPhotoUsers;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["currentUser"]!=null)
        {
            userPanel.Visible = true;
            guestPanel.Visible = false;
            myName = Session["currentUser"].ToString();
        }
        else
        {
            userPanel.Visible = false;
            guestPanel.Visible = true;
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        String photoCountQuery = "SELECT COUNT(*) FROM Users WHERE photo = 'true'";
        String userCountQuery = "SELECT COUNT(*) FROM Users";
        SqlCommand countPhoto = new SqlCommand(photoCountQuery, conn);
        SqlCommand countUser = new SqlCommand(userCountQuery, conn);
        conn.Open();
        numUsers = Convert.ToInt32(countUser.ExecuteScalar());
        numPhotoUsers = Convert.ToInt32(countPhoto.ExecuteScalar());
        conn.Close();
    }
    public String getName()
    {
        return myName;
    }
    public int getPhotoUsers()
    {
        return numPhotoUsers;
    }
    public int getTotUsers()
    {
        return numUsers;
    }

}
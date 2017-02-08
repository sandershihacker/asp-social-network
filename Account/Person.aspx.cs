using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class Account_Person : System.Web.UI.Page
{
    private String myName;
    private String imageUrl;
    private String andrewID;
    private String currentUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["currentUser"] == null)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        String stringID = Request.QueryString["p"];
        if(stringID == null)
        {
            Response.Redirect("~/");
        }
        if(!IsPostBack)
        {
            information.Visible = true;
            wall.Visible = false;
            displayInfo.Visible = false;
            displayWall.Visible = true;
        }
        int theID = Convert.ToInt32(stringID);
        imageUrl = "ProfilePictures/" + stringID + ".jpg";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        String getName = "SELECT name FROM Users WHERE Id = @ID";
        String getIntro = "SELECT intro FROM Users WHERE Id = @ID";
        String getClass = "SELECT class FROM Users WHERE Id = @ID";
        String getContact = "SELECT contact FROM Users WHERE Id = @ID";
        String getAndrew = "SELECT andrewID FROM Users WHERE Id = @ID";
        String getHometown = "SELECT hometown FROM Users WHERE Id = @ID";
        SqlCommand getNameCommand = new SqlCommand(getName, conn);
        SqlCommand getIntroCommand = new SqlCommand(getIntro, conn);
        SqlCommand getClassCommand = new SqlCommand(getClass, conn);
        SqlCommand getContactCommand = new SqlCommand(getContact, conn);
        SqlCommand getAndrewCommand = new SqlCommand(getAndrew, conn);
        SqlCommand getHometownCommand = new SqlCommand(getHometown, conn);
        getNameCommand.Parameters.AddWithValue("@ID", theID);
        getIntroCommand.Parameters.AddWithValue("@ID", theID);
        getClassCommand.Parameters.AddWithValue("@ID", theID);
        getContactCommand.Parameters.AddWithValue("@ID", theID);
        getAndrewCommand.Parameters.AddWithValue("@ID", theID);
        getHometownCommand.Parameters.AddWithValue("@ID", theID);
        conn.Open();
        myName = getNameCommand.ExecuteScalar().ToString();
        andrewID = getAndrewCommand.ExecuteScalar().ToString().Replace(" ","");
        if (getIntroCommand.ExecuteScalar() != null && getIntroCommand.ExecuteScalar().ToString().Replace(" ","")!="")
        {
            selfIntro.Text = getIntroCommand.ExecuteScalar().ToString();
        }
        else
        {
            selfIntro.Text = "This lad wrote nothing here.";
        }
        if (getContactCommand.ExecuteScalar() != null && getContactCommand.ExecuteScalar().ToString().Replace(" ", "") != "")
        {
            contactInfo.Text = getContactCommand.ExecuteScalar().ToString();
        }
        else
        {
            contactInfo.Text = "This guy doesn't want to be disturbed.";
        }
        if (getHometownCommand.ExecuteScalar() != null && getHometownCommand.ExecuteScalar().ToString().Replace(" ", "") != "")
        {
            hometownLabel.Text = getHometownCommand.ExecuteScalar().ToString();
        }
        else
        {
            hometownLabel.Text = "No info here.";
        }
        classYear.Text = "Class of " + getClassCommand.ExecuteScalar().ToString();
        conn.Close();
        Welcome.Text = myName + "'s Page";
        SqlDataSource wallData = new SqlDataSource();
        wallData.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        wallData.SelectCommand = "SELECT * FROM Wall WHERE Receiver = '" + andrewID + "' ORDER BY Time DESC";
        wallRepeater.DataSource = wallData;
        wallRepeater.DataBind();
        currentUser = Session["currentUser"].ToString();
    }
    public String getMyName()
    {
        return myName;
    }
    public String getImageUrl()
    {
        return imageUrl;
    }
    public String getAndrewID()
    {
        return andrewID;
    }
    protected void displayInfo_Click(object sender, EventArgs e)
    {
        information.Visible = true;
        wall.Visible = false;
        displayInfo.Visible = false;
        displayWall.Visible = true;
    }
    protected void displayWall_Click(object sender, EventArgs e)
    {
        wall.Visible = true;
        information.Visible = false;
        displayInfo.Visible = true;
        displayWall.Visible = false;
    }
    protected String getFullName(String andrew)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        String getNameQuery = "SELECT name FROM Users WHERE andrewID = @andrew";
        SqlCommand getName = new SqlCommand(getNameQuery, conn);
        getName.Parameters.AddWithValue("@andrew", andrew);
        conn.Open();
        String fullName;
        if (getName.ExecuteScalar() != null)
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
    protected void postComment_Click(object sender, EventArgs e)
    {
        String comment = commentBox.Text;
        if(comment.Replace(" ","") == "")
        {
            contentError.Text = "You wrote nothing.";
        }
        else if(comment.Length>500)
        {
            contentError.Text = "There is a 500 character limit.";
        }
        else
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            String insertQuery = "INSERT INTO Wall (Sender, Receiver, Content, Time) VALUES(@Sender, @Receiver, @Content, @Time)";
            SqlCommand insertComment = new SqlCommand(insertQuery, conn);
            insertComment.Parameters.AddWithValue("@Sender", currentUser);
            insertComment.Parameters.AddWithValue("@Receiver", andrewID);
            insertComment.Parameters.AddWithValue("@Content", comment);
            insertComment.Parameters.AddWithValue("@Time", DateTime.Now);
            conn.Open();
            insertComment.ExecuteNonQuery();
            conn.Close();
            contentError.Text = "<font color='green'>You have posted the comment.</font>";
            commentBox.Text = "";
        }
    }
}
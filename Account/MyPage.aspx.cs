using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Account_MyPage : System.Web.UI.Page
{
    private String myName;
    public String imageUrl;
    private String myID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["currentUser"]==null)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        else
        {
            String currentUser = Session["currentUser"].ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            String getNameQuery = "SELECT name FROM Users WHERE andrewID = '" + currentUser + "'";
            String getIdQuery = "SELECT Id FROM Users WHERE andrewID = '" + currentUser + "'";
            String getIsPhotoQuery = "SELECT photo FROM Users WHERE andrewID = '" + currentUser + "'";
            String getIntroQuery = "SELECT intro FROM Users WHERE andrewID = '" + currentUser + "'";
            String getContactQuery = "SELECT contact FROM Users WHERE andrewID = '" + currentUser + "'";
            SqlCommand getName = new SqlCommand(getNameQuery, conn);
            SqlCommand getId = new SqlCommand(getIdQuery, conn);
            SqlCommand getIsPhoto = new SqlCommand(getIsPhotoQuery, conn);
            SqlCommand getIntro = new SqlCommand(getIntroQuery, conn);
            SqlCommand getContact = new SqlCommand(getContactQuery, conn);
            conn.Open();
            myName = getName.ExecuteScalar().ToString();
            myID = getId.ExecuteScalar().ToString();
            String isPhoto = getIsPhoto.ExecuteScalar().ToString().Replace(" ","");
            if(getIntro.ExecuteScalar().ToString()!="")
            {
                if (!IsPostBack)
                {
                    textbox.Text = getIntro.ExecuteScalar().ToString();
                }
            }
            if (getContact.ExecuteScalar().ToString() != "")
            {
                if (!IsPostBack)
                {
                    contactInfo.Text = getContact.ExecuteScalar().ToString();
                }
            }
            conn.Close();
            Welcome.Text = myName + "'s Page";
            if(currentUser == "lanbos" || currentUser == "zeshengl")
            {
                managerPage.Visible = true;
            }
            else
            {
                managerPage.Visible = false;
            }
            if(isPhoto == "true")
            {
                imageUrl = "ProfilePictures/";
                conn.Open();
                imageUrl += getId.ExecuteScalar().ToString();
                imageUrl += ".jpg";
                conn.Close();
                photoFalse.Visible = false;
                photoTrue.Visible = true;
            }
            else
            {
                photoFalse.Visible = true;
                photoTrue.Visible = false;
            }
        }
    }
    public String getMyName()
    {
        return myName;
    }
    protected void uploadPicture_Click(object sender, EventArgs e)
    {
        if(loadPicture.HasFile)
        {
            if(loadPicture.PostedFile.ContentType=="image/jpeg")
            {
                if(Convert.ToInt64(loadPicture.PostedFile.ContentLength)<2000000)
                {
                    String myPath = Server.MapPath("~/Account/ProfilePictures/");
                    String photoFolder = Path.Combine(myPath, User.Identity.Name);
                    if(!Directory.Exists(photoFolder))
                    {
                        Directory.CreateDirectory(photoFolder);
                    }
                    String extention = ".jpg";
                    String fileName = myID;
                    loadPicture.SaveAs(Path.Combine(photoFolder, fileName + extention));
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    String updateQuery = "UPDATE Users SET photo = 'true' WHERE andrewId=@andrew";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
                    updateCommand.Parameters.AddWithValue("@andrew", Session["currentUser"].ToString());
                    conn.Open();
                    updateCommand.ExecuteNonQuery();
                    conn.Close();
                    errorMessage.Text = "<font color='green'>Upload succeed, please refresh the page.</font>";

                }
                else
                {
                    errorMessage.Text = "Please select a file smaller than 500 KB in size.";
                }
            }
            else
            {
                errorMessage.Text = "Please select a file with a jpg extention.";
            }
        }
        else
        {
            errorMessage.Text = "Please select a file.";
        }
    }
    protected void uploadNewPicture_Click(object sender, EventArgs e)
    {
        if (loadNewPicture.HasFile)
        {
            if (loadNewPicture.PostedFile.ContentType == "image/jpeg")
            {
                if (Convert.ToInt64(loadNewPicture.PostedFile.ContentLength) < 2000000)
                {
                    String myPath = Server.MapPath("~/Account/ProfilePictures/");
                    String photoFolder = Path.Combine(myPath, User.Identity.Name);
                    if (!Directory.Exists(photoFolder))
                    {
                        Directory.CreateDirectory(photoFolder);
                    }
                    String extention = ".jpg";
                    String fileName = myID;
                    loadNewPicture.SaveAs(Path.Combine(photoFolder, fileName + extention));
                    errorMessage.Text = "<font color='green'>Upload succeeded, please refresh the page.</font>";

                }
                else
                {
                    errorMessage.Text = "Please select a file smaller than 500 KB in size.";
                }
            }
            else
            {
                errorMessage.Text = "Please select a file with a jpg extention.";
            }
        }
        else
        {
            errorMessage.Text = "Please select a file.";
        }
    }
    protected void goManage(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/");
    }
    protected void Save_Intro(object sender, EventArgs e)
    {
        String introText = textbox.Text;
        if (introText.Length > 4000)
        {
            textAreaError.Text = "Sorry for the inconvenience, but there is a 4000 character limit!";
        }
        else
        {
            if (introText != "")
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                String writeQuery = "UPDATE Users SET intro=@intro WHERE Id=@myID";
                int intID = Convert.ToInt32(myID);
                SqlCommand writeCommand = new SqlCommand(writeQuery, conn);
                writeCommand.Parameters.AddWithValue("@myID", intID);
                writeCommand.Parameters.AddWithValue("@intro", introText.Replace("<", ""));
                conn.Open();
                writeCommand.ExecuteNonQuery();
                conn.Close();
                textAreaError.Text = "<font color='green'>Introduction updated.</font>";
            }
            else
            {
                textAreaError.Text = "You didn't write anything.";
            }
        }
    }
    protected void Save_Info(object sender, EventArgs e)
    {
        String contactText = contactInfo.Text;
        if (contactText.Length > 500)
        {
            textAreaError.Text = "Please don't exceed the 500 character limit.";
        }
        else
        {
            if (contactText != "")
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                String writeQuery = "UPDATE Users SET contact=@contact WHERE Id=@myID";
                int intID = Convert.ToInt32(myID);
                SqlCommand writeCommand = new SqlCommand(writeQuery, conn);
                writeCommand.Parameters.AddWithValue("@myID", intID);
                writeCommand.Parameters.AddWithValue("@contact", contactText.Replace("<", "(").Replace(">", ")"));
                conn.Open();
                writeCommand.ExecuteNonQuery();
                conn.Close();
                contactError.Text = "<font color='green'>Information updated.</font>";
            }
            else
            {
                contactError.Text = "You didn't write anything.";
            }
        }
    }
    protected void Update_Name(object sender, EventArgs e)
    {
        String myNewName = newName.Text;
        if(myNewName.Length>40)
        {
            nameError.Text = "Name is too long.";
        }
        else
        {
            if(myNewName.Replace(" ","")!="")
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                String writeQuery = "UPDATE Users SET name=@name WHERE Id=@myID";
                int intID = Convert.ToInt32(myID);
                SqlCommand writeCommand = new SqlCommand(writeQuery, conn);
                writeCommand.Parameters.AddWithValue("@myID", intID);
                writeCommand.Parameters.AddWithValue("@name", myNewName.Replace("<", ""));
                conn.Open();
                writeCommand.ExecuteNonQuery();
                conn.Close();
                nameError.Text = "<font color='green'>Name updated.</font>";
            }
            else
            {
                nameError.Text = "You didn't write anything.";
            }
        }
    }
    protected void Update_Pass(object sender, EventArgs e)
    {
        String oldPassword = oldPass.Text;
        String newPassword = newPass1.Text;
        int intID = Convert.ToInt32(myID);
        if (checkPass(oldPassword, intID))
        {
            if (newPassword.Replace(" ", "") != "")
            {
                if (newPassword == newPass2.Text)
                {
                    if (newPassword.Length <= 40)
                    {
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        String writeQuery = "UPDATE Users SET password=@password WHERE Id=@myID";

                        SqlCommand writeCommand = new SqlCommand(writeQuery, conn);
                        writeCommand.Parameters.AddWithValue("@myID", intID);
                        writeCommand.Parameters.AddWithValue("@password", newPassword);
                        conn.Open();
                        writeCommand.ExecuteNonQuery();
                        conn.Close();
                        passError.Text = "<font color='green'>Password updated.</font>";
                    }
                    else
                    {
                        passError.Text = "Your password is a bit long, don't you think?";
                    }
                }
                else
                {
                    passError.Text = "You entered two different passwords.";
                }
            }
            else
            {
                passError.Text = "You didn't enter a password.";
            }
        }
        else
        {
            passError.Text = "The old password is not correct.";
        }
    }
    protected bool checkPass(String pass, int key)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        String checkQuery = "SELECT password FROM Users Where Id = " + key;
        SqlCommand checkCommand = new SqlCommand(checkQuery, conn);
        conn.Open();
        String password = checkCommand.ExecuteScalar().ToString().Replace(" ","");
        conn.Close();
        if (password == pass)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void hometownButton_Click(object sender, EventArgs e)
    {
        String hometown = hometownTextBox.Text;
        int intID = Convert.ToInt32(myID);
        if(hometown.Replace(" ","")!="")
        {
            if(hometown.Length<=100)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                String updateHometownQuery = "UPDATE Users SET hometown=@hometown WHERE Id=@Id";
                SqlCommand updateHometown = new SqlCommand(updateHometownQuery, conn);
                updateHometown.Parameters.AddWithValue("@hometown", hometown);
                updateHometown.Parameters.AddWithValue("@Id", intID);
                conn.Open();
                updateHometown.ExecuteNonQuery();
                conn.Close();
                hometownError.Text = "<font color='green'>Updated.</font>";
            }
            else
            {
                hometownError.Text = "There is a 100 character limit.";
            }
        }
        else
        {
            hometownError.Text = "You typed nothing.";
        }
    }
}

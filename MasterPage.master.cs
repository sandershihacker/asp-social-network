using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["currentUser"]!=null)
        {
            guestPanel.Visible = false;
            userPanel.Visible = true;
            
        }
        else
        {
            guestPanel.Visible = true;
            userPanel.Visible = false;
            
        }
    }
    public void logoff_Click(object sender, EventArgs e)
    {
        Session["currentUser"] = null;
        Response.Redirect("~/");
    }
}

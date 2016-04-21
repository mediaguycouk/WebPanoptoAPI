using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoUserManagement;

namespace WebPanoptoAPI
{
    public partial class page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((string)Session["loggedin"] != "loggedin")
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("Login.aspx");
            }
            
            lblApiSystemRole.Text = Session["apiRole"].ToString();
            lblApiUsername.Text = (string) Session["apiUsername"];
            lblVersion.Text = (string) Session["version"];
            lblServername.Text = (string) Session["server"];

        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoUserManagement;
using WebPanoptoAPI.PanoptoSessionManagement;

namespace WebPanoptoAPI
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitFqdn_Click(object sender, EventArgs e)
        {
            IUserManagement userMgr = new UserManagementClient();

            PanoptoUserManagement.AuthenticationInfo userAuthenticationInfo = new PanoptoUserManagement.AuthenticationInfo()
            {
                UserKey = txtApiUsername.Text,
                Password = txtApiPassword.Text
            };

            try
            {
                User apiUser = userMgr.GetUserByKey(userAuthenticationInfo, userAuthenticationInfo.UserKey);
                
                if (!apiUser.UserSettingsUrl.Contains(txtFqdn.Text))
                {
                    lblErrorStep1.Text = "<p>The Web.config file is not set to that server. " +
                                         "You'll need to confirm that you are pointing at " +
                                         "the correct server.</p>";
                }
                else
                {
                    Session["lastPage"] = "page1";

                    Session["server"] = txtFqdn.Text;
                    Session["apiUsername"] = txtApiUsername.Text;
                    Session["apiPassword"] = txtApiPassword.Text;
                    Session["apiRole"] = apiUser.SystemRole;
                    
                    Server.Transfer("page2.aspx");
                }
            }
            catch (Exception)
            {
                lblErrorStep1.Text = "<p>The username and password for your API user " +
                                    "was not valid</p>";
            }
            


        }
    }
}

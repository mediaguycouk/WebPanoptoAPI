using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoAuth;
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
            IUserManagement userMgr = new UserManagementClient("BasicHttpBinding_IUserManagement", "https://" + txtFqdn.Text + "/Panopto/PublicAPISSL/4.6/UserManagement.svc");
            IAuth auth = new AuthClient("BasicHttpBinding_IAuth", "https://" + txtFqdn.Text + "/Panopto/PublicAPISSL/4.6/Auth.svc");

            PanoptoUserManagement.AuthenticationInfo userAuthenticationInfo = new PanoptoUserManagement.AuthenticationInfo()
            {
                UserKey = txtApiUsername.Text,
                Password = txtApiPassword.Text
            };

            try
            {
                User apiUser = userMgr.GetUserByKey(userAuthenticationInfo, userAuthenticationInfo.UserKey);
                
                if (String.IsNullOrWhiteSpace(txtFqdn.Text) || !apiUser.UserSettingsUrl.Contains(txtFqdn.Text))
                {
                    lblErrorStep1.Text = "<p>The Web.config file is not set to that server. " +
                                         "You'll need to confirm that you are pointing at " +
                                         "the correct server.</p>";
                }
                else if (apiUser.SystemRole != SystemRole.Admin)
                {
                    lblErrorStep1.Text = "<p>You must be an administrator to use the superadmin page</p>";
                }
                else
                {
                    Session["loggedin"] = "loggedin";

                    Session["server"] = txtFqdn.Text;
                    Session["version"] = auth.GetServerVersion();
                    Session["apiUsername"] = txtApiUsername.Text;
                    Session["apiPassword"] = txtApiPassword.Text;
                    Session["apiRole"] = apiUser.SystemRole;
                    
                    Server.Transfer("Default.aspx");
                }
            }
            catch (Exception exception)
            {
                lblErrorStep1.Text = "<p>The username and password for your API user " +
                                    "was not valid</p>";
                lblException.Text = "<!--" + Server.HtmlEncode(exception.ToString()) + "-->";
            }

        }
    }
}

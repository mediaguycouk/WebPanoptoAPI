using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoAccessManagement;
using WebPanoptoAPI.PanoptoUserManagement;
using WebPanoptoAPI.PanoptoSessionManagement;

namespace WebPanoptoAPI
{
    public partial class MakeAssessmentSessions : System.Web.UI.Page
    {
        private PanoptoAccessManagement.AuthenticationInfo accessAuthenticationInfo;
        private PanoptoUserManagement.AuthenticationInfo userAuthenticationInfo;
        private PanoptoSessionManagement.AuthenticationInfo sessionAuthenticationInfo;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((string)Session["loggedin"] != "loggedin")
                {
                    Response.Redirect("Login.aspx");
                }
                string currentServer = Session["server"].ToString();
                if (!currentServer.Contains("soton.ac.uk"))
                {
                    Response.Redirect("SouthamptonOnly.aspx", false);
                }
            }
            catch (Exception)
            {
                Response.Redirect("Default.aspx");
            }

            MultiView1.SetActiveView(View1);
        }

        protected void btnMakeFoldersSubmit_Click(object sender, EventArgs e)
        {
            bool lastPage = false;
            int resultsPerPage = 50;
            int page = 0;

            sessionAuthenticationInfo = new PanoptoSessionManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            accessAuthenticationInfo = new PanoptoAccessManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };
            
            userAuthenticationInfo = new PanoptoUserManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            ISessionManagement sessionMgr = new SessionManagementClient("BasicHttpBinding_ISessionManagement", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/SessionManagement.svc");
            IAccessManagement accessMgr = new AccessManagementClient("BasicHttpBinding_IAccessManagement", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/AccessManagement.svc");
            IUserManagement userMgr = new UserManagementClient("BasicHttpBinding_IUserManagement", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/UserManagement.svc");

            String MembershipProvider = txtCheckInter.Text.Trim();
            
            User checkUser = userMgr.GetUserByKey(userAuthenticationInfo, MembershipProvider + @"\" + txtCheckUser.Text);
            Guid checkUserGuid = checkUser.UserId;

            if (checkUserGuid.Equals(Guid.Empty))
            {
                lblErrors.Text = "The user used to check membership failed. To be safe we've stopped";
                MultiView1.SetActiveView(View2);
                return;
            }

            //
            //
            // // THE ASSESSMENTS FOLDER IS HARD CODED BELOW
            //
            //

            Folder assessmentFolder = sessionMgr.AddFolder(sessionAuthenticationInfo, txtAssessmentName.Text,
                new Guid("9cfb8caf-5086-48b3-a480-17152a638ed0"), false);

            //
            //
            // // THE ASSESSMENTS FOLDER IS HARD CODED ABOVE
            //
            //

            string[] lines = txtUsers.Text.Trim().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (String line in lines)
            {
                string[] columns = line.Split(',');

                if (!columns.Length.Equals(4))
                {
                    throw new SystemException("A line does not contain 4 elements");
                    break;
                }

                String userName = columns[0];
                String firstName = columns[2];
                String lastName = columns[1];
                String studentName = lastName + ", " + firstName;
                String sessionName = columns[3];

                Session studentSession;

                try
                {
                    studentSession = sessionMgr.AddSession(sessionAuthenticationInfo, sessionName, assessmentFolder.Id, false);
                }
                catch (Exception)
                {
                    lblErrors.Text += studentName + "'s session couldn't be created<br/>\r\n";
                    throw;
                }

                User studentUser = userMgr.GetUserByKey(userAuthenticationInfo, MembershipProvider + @"\" + userName);
                Guid studentGuid = studentUser.UserId;

                try
                {
                    if (studentGuid.Equals(Guid.Empty))
                    {
                        PanoptoUserManagement.User generatedUser = new User()
                        {
                            UserKey = MembershipProvider + @"\" + userName,
                            FirstName = firstName,
                            LastName = lastName,
                            SystemRole = PanoptoUserManagement.SystemRole.None,
                            UserBio = String.Empty,
                            Email = userName + "@soton.ac.uk",
                            EmailSessionNotifications = false
                        };

                        Guid generatedUserGuid = userMgr.CreateUser(userAuthenticationInfo, generatedUser, String.Empty);
                        lblSuccess.Text += userName + " added to Panopto users<br/>\r\n";
                        studentGuid = generatedUserGuid;
                    }

                    accessMgr.GrantUsersViewerAccessToSession(accessAuthenticationInfo, studentSession.Id, new Guid[] { studentGuid });
                    lblSuccess.Text += sessionName + " created with rights for " + userName + "<br/>\r\n";

                }
                catch (Exception)
                {
                    lblErrors.Text += studentName + " cannot be created or added to the session.<br/>\r\n";
                    throw;
                }
                
                

               
            }

            MultiView1.SetActiveView(View2);
        }
    }
}
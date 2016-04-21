using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoUserManagement;

namespace WebPanoptoAPI
{
    public partial class FillInternalGroupFromAdGroup : System.Web.UI.Page
    {
        private PanoptoUserManagement.AuthenticationInfo userAuthenticationInfo;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((string)Session["lastPage"] != "page2")
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("Default.aspx");
            }

            userAuthenticationInfo = new PanoptoUserManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            MultiView1.SetActiveView(View1);


        }

        protected void btnSubmitAdGroupName_Click(object sender, EventArgs e)
        {
            bool lastPage = false;
            int resultsPerPage = 50;
            int page = 0;
            bool found = false;

            while (!lastPage)
            {
                PanoptoUserManagement.Pagination pagination =
                    new PanoptoUserManagement.Pagination { MaxNumberResults = resultsPerPage, PageNumber = page };

                IUserManagement userMgr = new UserManagementClient();

                PanoptoUserManagement.ListGroupsResponse response = userMgr.ListGroups(userAuthenticationInfo,
                    pagination);

                if (resultsPerPage * (page + 1) >= response.TotalResultCount)
                {
                    lastPage = true;
                }

                if (response.PagedResults.Length > 0)
                {
                    foreach (Group group in response.PagedResults)
                    {
                        if (group.GroupType == GroupType.Internal && group.Name.ToLower().EndsWith(txtAdGroupName.Text.ToLower()))
                        {
                            ddlInternalGroups.Items.Add(new ListItem(group.Name, group.Id.ToString()));
                            found = true;
                        }
                    }
                }
                else
                {
                    ddlInternalGroups.Items.Add("No results found");
                    ddlInternalGroups.Enabled = false;
                }

                page++;

            }

            if (found)
            {
                MultiView1.SetActiveView(View2);
            }
            else
            {
                lblAdGroupNameError.Text = "<p>No groups found</p>";
            }
        }

        protected void btnSubmitAdGroupList_Click(object sender, EventArgs e)
        {
            bool view2Success = true;
            
            // set up domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

            // find the group in question
            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, txtAdGroupName.Text);

            // if found....
            if (group != null)
            {
                lblAdCheck.Text = "AD Check success";

                // iterate over members
                foreach (Principal p in group.GetMembers())
                {
                    txtAdUserCheck.Text += p.Name + " (" + p.DisplayName + ")\r\n";
                }
                
            }
            else
            {
                lblAdCheck.Text = "AD Check fail: group does not exist";
                txtAdUserCheck.Visible = false;
                btnAdCheckUserConfirm.Enabled = false;
                view2Success = false;
            }

            IUserManagement userMgr = new UserManagementClient();
            User panUser = userMgr.GetUserByKey(userAuthenticationInfo, txtMembershipProvider.Text + @"\" +  txtMembershipUserToCheck.Text);

            if (panUser == null || panUser.UserId.Equals(Guid.Empty))
            {
                view2Success = false;
                lblMembershipProviderError.Text = "Couldn't find a user called " + txtMembershipProvider.Text + @"\" + txtMembershipUserToCheck.Text;
            }

            if (view2Success)
            {
                MultiView1.SetActiveView(View3);
            }
            else
            {
                MultiView1.SetActiveView(View2);
            }
           
        }

        protected void checkConfirmAdUsers_CheckedChanged(object sender, EventArgs e)
        {
            btnAdCheckUserConfirm.Enabled = checkConfirmAdUsers.Checked;
            MultiView1.SetActiveView(View3);
        }

        protected void btnAdCheckUserConfirm_Click(object sender, EventArgs e)
        {
            // set up domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

            // find the group in question
            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, txtAdGroupName.Text);

            IUserManagement userMgr = new UserManagementClient();

            List<Guid> userList = new List<Guid>();

            // if found....
            if (group != null)
            {
                // iterate over members
                foreach (Principal p in group.GetMembers())
                {
                    if (p.StructuralObjectClass == "user")
                    {
                        // do whatever you need to do to those members
                        UserPrincipal theUser = p as UserPrincipal;

                        if (theUser != null)
                        {
                            User panUser = userMgr.GetUserByKey(userAuthenticationInfo, txtMembershipProvider.Text + @"\" + p.Name);
                            if (panUser != null && !panUser.UserId.Equals(Guid.Empty))
                            {
                                Console.WriteLine("User {0} exists in Panopto as {1}", p.Name, panUser.UserId);
                                lblAdSyncExistingUserProgress.Text += p.Name + " exists in Panopto already<br/>\r\n";
                                userList.Add(panUser.UserId);
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(theUser.GivenName) || String.IsNullOrEmpty(theUser.Surname) ||
                                    String.IsNullOrEmpty(theUser.EmailAddress))
                                {
                                    lblAdSyncFailedUserProgress.Text += p.Name + " doesn't have enough details to make a user account<br/>\r\n";
                                }
                                else
                                {
                                    PanoptoUserManagement.User generatedUser = new User()
                                    {
                                        UserKey = txtMembershipProvider.Text + @"\" + p.Name,
                                        FirstName = theUser.GivenName,
                                        LastName = theUser.Surname,
                                        SystemRole = SystemRole.None,
                                        UserBio = String.Empty,
                                        //DEBUG
                                        Email = "panopto." + p.Name + "@mediaguy.co.uk",
                                        //Email = theUser.EmailAddress,
                                        EmailSessionNotifications = false
                                    };

                                    Guid generatedUserGuid = userMgr.CreateUser(userAuthenticationInfo, generatedUser, String.Empty);
                                    panUser = generatedUser;
                                    userList.Add(generatedUserGuid);

                                    lblAdSyncNewUserProgress.Text += txtMembershipProvider.Text + @"\" + p.Name +
                                                                     " added to Panopto<br/>\r\n";
                                }
                            }

                        }
                    }
                }
                
                // Does the Panopto group exist?
                try
                {
                    Guid panGroupGuid = new Guid(ddlInternalGroups.SelectedValue);
                    Group panGroup = userMgr.GetGroup(userAuthenticationInfo, panGroupGuid);

                    //userMgr.RemoveMembersFromInternalGroup(userAuthenticationInfo, panGroupGuid);

                    userMgr.AddMembersToInternalGroup(userAuthenticationInfo, panGroup.Id, userList.ToArray());
                    lblAdSyncGroupProgress.Text += panGroup.Name + " was updated (id:" + panGroup.Id + ")<br/>\r\n";
                }
                catch (Exception)
                {
                    // WARNING: There is currently an issue that causes internal groups to not show
                    // within the Panopto UI, unless made within the Panopto UI
                    //
                    // Because of this you need to create the group in the UI first and then use
                    // this API to fill in the users of that group
                    // http://support.panopto.com/documentation/video-management/internal-groups
                    //
                    //panGroup = userMgr.CreateInternalGroup(userAuth, panAdGroupName, userList.ToArray());

                    lblAdSyncGroupProgress.Text =
                        "Nothing was updated. You must create the group within the Panopto UI first!";
                }
            }
            MultiView1.SetActiveView(View4);
        }
    }
}
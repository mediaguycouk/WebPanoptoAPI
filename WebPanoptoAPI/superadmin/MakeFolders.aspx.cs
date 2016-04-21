using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoAccessManagement;
using WebPanoptoAPI.PanoptoUserManagement;
using WebPanoptoAPI.PanoptoSessionManagement;

namespace WebPanoptoAPI
{
    public partial class MakeFolders : System.Web.UI.Page
    {
        private PanoptoAccessManagement.AuthenticationInfo accessAuthenticationInfo;
        private PanoptoUserManagement.AuthenticationInfo userAuthenticationInfo;
        private PanoptoSessionManagement.AuthenticationInfo sessionAuthenticationInfo;
        
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

            bool lastPage = false;
            int resultsPerPage = 50;
            int page = 0;
            bool found = false;

            userAuthenticationInfo = new PanoptoUserManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            IUserManagement userMgr = new UserManagementClient();

            while (!lastPage)
            {
                PanoptoUserManagement.Pagination pagination =
                    new PanoptoUserManagement.Pagination { MaxNumberResults = resultsPerPage, PageNumber = page };

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
                        ddlCreators.Items.Add(new ListItem(group.Name, group.Id.ToString()));
                        ddlViewers.Items.Add(new ListItem(group.Name, group.Id.ToString()));
                        found = true;
                    }
                }
                else
                {
                    ddlCreators.Items.Add("No results found");
                    ddlViewers.Items.Add("No results found");
                    btnMakeFoldersSubmit.Enabled = false;
                }

                page++;

            }

            MultiView1.SetActiveView(View1);
        }

        protected void btnMakeFoldersSubmit_Click(object sender, EventArgs e)
        {
            bool lastPage = false;
            int resultsPerPage = 50;
            int page = 0;
            List<String> existingFolderNames = new List<string>();

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

            ISessionManagement sessionMgr = new SessionManagementClient();
            IAccessManagement accessMgr = new AccessManagementClient();
            IUserManagement userMgr = new UserManagementClient();

            while (!lastPage)
            {
                PanoptoSessionManagement.Pagination pagination = new PanoptoSessionManagement.Pagination { MaxNumberResults = resultsPerPage, PageNumber = page };
                ListFoldersResponse response = sessionMgr.GetFoldersList(sessionAuthenticationInfo, new ListFoldersRequest { Pagination = pagination, SortIncreasing = true }, null);

                if (resultsPerPage * (page + 1) >= response.TotalNumberResults)
                {
                    lastPage = true;
                }

                if (response.Results.Length > 0)
                {
                    foreach (Folder folder in response.Results)
                    {
                        existingFolderNames.Add(folder.Name);
                    }
                }

                page++;
            }
            
            string[] stringFolderNames = System.Text.RegularExpressions.Regex.Split(txtFolderNames.Text, "\r\n");

            foreach (string folderName in stringFolderNames)
            {
                string trimmedFolderName = folderName.Trim();

                if (String.IsNullOrWhiteSpace(trimmedFolderName))
                {
                    lblFoldersNotCreated.Text += "Folder not created, line was blank<br />\r\n";
                }
                else if (existingFolderNames.Contains(trimmedFolderName))
                {
                    lblFoldersNotCreated.Text += trimmedFolderName + " not created, it already exists<br />\r\n";
                }
                else
                {
                    Folder newFolder = sessionMgr.AddFolder(sessionAuthenticationInfo, trimmedFolderName, null, false);
                    
                    if (ddlCreators.SelectedValue != "0")
                    {
                        accessMgr.GrantGroupAccessToFolder(accessAuthenticationInfo, newFolder.Id, new Guid(ddlCreators.SelectedValue), AccessRole.Creator);
                    }
                    if (ddlViewers.SelectedValue != "0")
                    {
                        accessMgr.GrantGroupAccessToFolder(accessAuthenticationInfo, newFolder.Id, new Guid(ddlViewers.SelectedValue), AccessRole.Viewer);
                    }

                    lblFoldersCreated.Text += trimmedFolderName + " created with selected permissions<br />\r\n";

                    if (checkRemoveApiUser.Checked)
                    {
                        User apiUser = userMgr.GetUserByKey(userAuthenticationInfo, userAuthenticationInfo.UserKey);
                        accessMgr.RevokeUsersAccessFromFolder(accessAuthenticationInfo, newFolder.Id, new Guid[1] { apiUser.UserId }, AccessRole.Creator);
                    }
                }

            }

            MultiView1.SetActiveView(View2);
        }
    }
}
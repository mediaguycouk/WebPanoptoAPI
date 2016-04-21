using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoSessionManagement;

namespace WebPanoptoAPI
{
    public partial class UpdateFolderParent : System.Web.UI.Page
    {
        private PanoptoSessionManagement.AuthenticationInfo sessionAuthenticationInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((string)Session["loggedin"] != "loggedin")
                {
                    Response.Redirect("~/superadmin/Login.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/superadmin/Default.aspx");
            }

            if (ddlFolderToMove.Items.Count == 0)
            {
                bool lastPage = false;
                int resultsPerPage = 100;
                int page = 0;

                sessionAuthenticationInfo = new PanoptoSessionManagement.AuthenticationInfo()
                {
                    UserKey = (string)Session["apiUsername"],
                    Password = (string)Session["apiPassword"]
                };

                while (!lastPage)
                {
                    PanoptoSessionManagement.Pagination pagination = new PanoptoSessionManagement.Pagination
                    {
                        MaxNumberResults = resultsPerPage,
                        PageNumber = page
                    };
                    ISessionManagement sessionMgr = new SessionManagementClient("BasicHttpBinding_ISessionManagement", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/SessionManagement.svc");
                    ListFoldersResponse response = sessionMgr.GetFoldersList(sessionAuthenticationInfo,
                        new ListFoldersRequest { Pagination = pagination, SortIncreasing = true }, null);

                    if (resultsPerPage * (page + 1) >= response.TotalNumberResults)
                    {
                        lastPage = true;
                    }

                    if (response.Results.Length > 0)
                    {
                        foreach (Folder folder in response.Results)
                        {
                            string folderName = folder.Name;

                            if (folderName.Length > 42)
                            {
                                folderName = folderName.Substring(0, 42) + "...";
                            }

                            ddlFolderToMove.Items.Add(new ListItem(folderName, folder.Id.ToString()));
                            ddlParentFolder.Items.Add(new ListItem(folderName, folder.Id.ToString()));
                        }
                    }

                    page++;

                }
            }
        }

        protected void btnUpdateFolder_Click(object sender, EventArgs e)
        {
            sessionAuthenticationInfo = new PanoptoSessionManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            ISessionManagement sessionMgr = new SessionManagementClient("BasicHttpBinding_ISessionManagement", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/SessionManagement.svc");
            sessionMgr.UpdateFolderParent(sessionAuthenticationInfo, 
                new Guid(ddlFolderToMove.SelectedValue), new Guid(ddlParentFolder.SelectedValue));

            btnUpdateFolder.Enabled = false;
            btnUpdateFolder.Text = "Folder updated";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoAccessManagement;
using WebPanoptoAPI.PanoptoSessionManagement;
using WebPanoptoAPI.PanoptoUserManagement;

namespace WebPanoptoAPI
{
    public partial class ListVideoEmbedHTML : System.Web.UI.Page
    {
        private PanoptoSessionManagement.AuthenticationInfo sessionAuthenticationInfo;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((string)Session["loggedin"] != "loggedin")
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("Login.aspx");
            }

            if (ddlFolder.Items.Count == 0)

            {
                bool lastPage = false;
                int resultsPerPage = 100;
                int page = 0;

                sessionAuthenticationInfo = new PanoptoSessionManagement.AuthenticationInfo()
                {
                    UserKey = (string) Session["apiUsername"],
                    Password = (string) Session["apiPassword"]
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
                        new ListFoldersRequest {Pagination = pagination, SortIncreasing = true}, null);

                    if (resultsPerPage*(page + 1) >= response.TotalNumberResults)
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

                            ddlFolder.Items.Add(new ListItem(folderName, folder.Id.ToString()));
                        }
                    }

                    page++;

                }
            }

            MultiView1.SetActiveView(View1);
        }

        protected void btnSelectFolders_Click(object sender, EventArgs e)
        {
            bool lastPage = false;
            int resultsPerPage = 100;
            int page = 0;

            sessionAuthenticationInfo = new PanoptoSessionManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            ISessionManagement sessionMgr = new SessionManagementClient("BasicHttpBinding_ISessionManagement", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/SessionManagement.svc");
            
            Folder[] toFolder = sessionMgr.GetFoldersById(sessionAuthenticationInfo, new Guid[1]{new Guid(ddlFolder.SelectedValue)});

            while (!lastPage)
            {
                PanoptoSessionManagement.Pagination pagination =
                    new PanoptoSessionManagement.Pagination { MaxNumberResults = resultsPerPage, PageNumber = page };
                PanoptoSessionManagement.ListSessionsRequest request =
                    new PanoptoSessionManagement.ListSessionsRequest { Pagination = pagination, FolderId = new Guid(ddlFolder.SelectedValue)};
                
                ListSessionsResponse response = sessionMgr.GetSessionsList(sessionAuthenticationInfo, request, null);

                if (resultsPerPage*(page + 1) >= response.TotalNumberResults)
                {
                    lastPage = true;
                }

                if (response.Results.Length > 0)
                {
                    foreach (Session session in response.Results)
                    {
                        
                        TextBox1.Text += session.Name + " | " + session.ViewerUrl + "\r\n";
                    }
                }

                page++;

            }
            MultiView1.SetActiveView(View2);
        }

       
    }
}
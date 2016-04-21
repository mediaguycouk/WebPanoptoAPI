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
    public partial class MakeVideosInternal : System.Web.UI.Page
    {
        private PanoptoSessionManagement.AuthenticationInfo sessionAuthenticationInfo;
        private PanoptoAccessManagement.AuthenticationInfo accessAuthenticationInfo;

        // Pre-Prod
        //Guid allUsersGroupGuid = new Guid("EEF90286-3749-4100-B974-82A4F62416C1");
        // Prod
        Guid allUsersGroupGuid = new Guid("2DB689B5-0C02-4801-A4E5-735C6B273304");
        
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

            accessAuthenticationInfo = new PanoptoAccessManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            ISessionManagement sessionMgr = new SessionManagementClient("BasicHttpBinding_ISessionManagement", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/SessionManagement.svc");
            //IAccessManagement accessMgr = new AccessManagementClient("BasicHttpBinding_IAccessManagement", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/AccessManagement.svc");

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
                        //lblSessionList.Text += "<li>" +session.Name + " on " + session.StartTime.ToString() + "</li>\r\n";
                        //sessionToMoveList.Add(session.Id);

                        ListItem sessionItem = new ListItem(session.Name + " on " + session.StartTime.ToString(), session.Id.ToString());

                        chklistSessions.Items.Add(sessionItem);
                    }
                }

                page++;

            }
            MultiView1.SetActiveView(View2);
        }

        protected void btnConfirmMove_Click(object sender, EventArgs e)
        {
            bool lastPage = false;
            int resultsPerPage = 100;
            int page = 0;
            int sessionsChanged = 0;

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

            //ISessionManagement sessionMgr = new SessionManagementClient("BasicHttpBinding_ISessionManagement", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/SessionManagement.svc");
            IAccessManagement accessMgr = new AccessManagementClient("BasicHttpBinding_IAccessManagement", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/AccessManagement.svc");

            foreach (ListItem item in chklistSessions.Items)
            {
                //accessMgr.UpdateSessionIsPublic(accessAuthenticationInfo, new Guid(item.Value), item.Selected);
                if (item.Selected)
                {
                    accessMgr.GrantGroupViewerAccessToSession(accessAuthenticationInfo, new Guid(item.Value),
                        allUsersGroupGuid);
                    sessionsChanged++;
                }
            }

            //sessionMgr.MoveSessions(sessionAuthenticationInfo, sessionToMakePublicList.ToArray(),
            //    new Guid(ddlMoveTo.SelectedValue));

            lblMoveConfirmation.Text = sessionsChanged.ToString() + " sessions updated";

            MultiView1.SetActiveView(View3);
        }
    }
}
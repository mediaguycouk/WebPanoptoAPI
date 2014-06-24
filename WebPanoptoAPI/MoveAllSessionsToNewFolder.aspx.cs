using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoSessionManagement;

namespace WebPanoptoAPI
{
    public partial class MoveAllSessionsToNewFolder : System.Web.UI.Page
    {
        private PanoptoSessionManagement.AuthenticationInfo sessionAuthenticationInfo;
        private List<Guid> sessionToMoveList = new List<Guid>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((string)Session["lastPage"] != "page2")
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("Default.aspx");
            }
            
            bool lastPage = false;
            int resultsPerPage = 50;
            int page = 0;

            sessionAuthenticationInfo = new PanoptoSessionManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            while (!lastPage)
            {
                PanoptoSessionManagement.Pagination pagination = new PanoptoSessionManagement.Pagination { MaxNumberResults = resultsPerPage, PageNumber = page };
                ISessionManagement sessionMgr = new SessionManagementClient();
                ListFoldersResponse response = sessionMgr.GetFoldersList(sessionAuthenticationInfo, new ListFoldersRequest { Pagination = pagination, SortIncreasing = true }, null);

                if (resultsPerPage * (page + 1) >= response.TotalNumberResults)
                {
                    lastPage = true;
                }

                if (response.Results.Length > 0)
                {
                    foreach (Folder folder in response.Results)
                    {
                        ddlMoveFrom.Items.Add(new ListItem(folder.Name, folder.Id.ToString()));
                        ddlMoveTo.Items.Add(new ListItem(folder.Name, folder.Id.ToString()));
                    }
                }

                page++;

            }

            MultiView1.SetActiveView(View1);
        }

        protected void btnSelectFolders_Click(object sender, EventArgs e)
        {
            bool lastPage = false;
            int resultsPerPage = 50;
            int page = 0;

            sessionAuthenticationInfo = new PanoptoSessionManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            ISessionManagement sessionMgr = new SessionManagementClient();

            Folder[] toFolder = sessionMgr.GetFoldersById(sessionAuthenticationInfo, new Guid[1]{new Guid(ddlMoveTo.SelectedValue)});
            lblToFolder.Text = toFolder[0].Name;
            lblToFolderUrl.Text = "<a href=\""+toFolder[0].SettingsUrl +"\" target=\"_blank\">here</a>";

            while (!lastPage)
            {
                PanoptoSessionManagement.Pagination pagination =
                    new PanoptoSessionManagement.Pagination { MaxNumberResults = resultsPerPage, PageNumber = page };
                PanoptoSessionManagement.ListSessionsRequest request =
                    new PanoptoSessionManagement.ListSessionsRequest { Pagination = pagination, FolderId = new Guid(ddlMoveFrom.SelectedValue)};
                
                ListSessionsResponse response = sessionMgr.GetSessionsList(sessionAuthenticationInfo, request, null);

                if (resultsPerPage*(page + 1) >= response.TotalNumberResults)
                {
                    lastPage = true;
                }

                if (response.Results.Length > 0)
                {
                    foreach (Session session in response.Results)
                    {
                        lblSessionList.Text += "<li>" +session.Name + " on " + session.StartTime.ToString() + "</li>\r\n";
                        sessionToMoveList.Add(session.Id);
                    }
                }

                page++;

            }
            MultiView1.SetActiveView(View2);
        }

        protected void btnConfirmMove_Click(object sender, EventArgs e)
        {
            bool lastPage = false;
            int resultsPerPage = 50;
            int page = 0;

            sessionAuthenticationInfo = new PanoptoSessionManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            ISessionManagement sessionMgr = new SessionManagementClient();

            while (!lastPage)
            {
                PanoptoSessionManagement.Pagination pagination =
                    new PanoptoSessionManagement.Pagination { MaxNumberResults = resultsPerPage, PageNumber = page };
                PanoptoSessionManagement.ListSessionsRequest request =
                    new PanoptoSessionManagement.ListSessionsRequest { Pagination = pagination, FolderId = new Guid(ddlMoveFrom.SelectedValue) };

                ListSessionsResponse response = sessionMgr.GetSessionsList(sessionAuthenticationInfo, request, null);

                if (resultsPerPage * (page + 1) >= response.TotalNumberResults)
                {
                    lastPage = true;
                }

                if (response.Results.Length > 0)
                {
                    foreach (Session session in response.Results)
                    {
                        sessionToMoveList.Add(session.Id);
                    }
                }

                page++;

            }

            sessionMgr.MoveSessions(sessionAuthenticationInfo, sessionToMoveList.ToArray(),
                new Guid(ddlMoveTo.SelectedValue));

            lblMoveConfirmation.Text = sessionToMoveList.Count + " sessions moved";

            MultiView1.SetActiveView(View3);
        }
    }
}
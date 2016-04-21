using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoAccessManagement;
using WebPanoptoAPI.PanoptoSessionManagement;

namespace WebPanoptoAPI.superadmin
{
    public partial class UpdateUploadedFlashMetadata : System.Web.UI.Page
    {
        private PanoptoSessionManagement.AuthenticationInfo sessionAuthenticationInfo;
        private PanoptoAccessManagement.AuthenticationInfo accessAuthenticationInfo;
        
        // Pre-Prod
        /*
        Guid unprocessedFolderGuid = new Guid("dc5d4ab4-7e80-4f2a-9685-c6893a5a7dcf");
        Guid processedFolderGuid = new Guid("ba5ff904-067d-4df0-8092-738820674ed5");
        Guid allUsersGroupGuid = new Guid("EEF90286-3749-4100-B974-82A4F62416C1");
        */
        // Prod
        
        Guid unprocessedFolderGuid = new Guid("2b3139d2-720f-4f0f-a9b8-a4e43f0a4b9e");
        Guid processedFolderGuid = new Guid("89436797-e05d-4ebf-8d4f-d549aa10dbe8");
        Guid allUsersGroupGuid = new Guid("2DB689B5-0C02-4801-A4E5-735C6B273304");
        

        private List<Guid> sessionsToMoveList = new List<Guid>();

        FlashData flashData = new FlashData();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((string)Session["loggedin"] != "loggedin")
                {
                    Response.Redirect("Login.aspx", false);
                }
                string currentServer = Session["server"].ToString();
                if (!currentServer.Contains("soton.ac.uk"))
                {
                    Response.Redirect("SouthamptonOnly.aspx", false);
                }
            }
            catch (Exception)
            {
                Response.Redirect("Login.aspx");
            }

            flashData.InitaliseFromFile();

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
            IAccessManagement accessMgr = new AccessManagementClient("BasicHttpBinding_IAccessManagement", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/AccessManagement.svc");

            Folder[] toFolder = sessionMgr.GetFoldersById(sessionAuthenticationInfo, new Guid[1] { processedFolderGuid });

            PanoptoSessionManagement.Pagination pagination =
                new PanoptoSessionManagement.Pagination { MaxNumberResults = resultsPerPage, PageNumber = page };
            PanoptoSessionManagement.ListSessionsRequest request =
                new PanoptoSessionManagement.ListSessionsRequest { Pagination = pagination, FolderId = unprocessedFolderGuid };

            ListSessionsResponse response = sessionMgr.GetSessionsList(sessionAuthenticationInfo, request, null);

            if (resultsPerPage * (page + 1) >= response.TotalNumberResults)
            {
                lastPage = true;
            }

            if (response.Results.Length > 0)
            {
                foreach (Session session in response.Results)
                {
                    if (flashData.findFromURL(session.Name))
                    {
                        sessionMgr.UpdateSessionName(sessionAuthenticationInfo, session.Id, flashData.title);
                        sessionMgr.UpdateSessionDescription(sessionAuthenticationInfo, session.Id, flashData.descritpion);
                        accessMgr.UpdateSessionIsPublic(accessAuthenticationInfo, session.Id, flashData.isPublic);
                        accessMgr.GrantGroupViewerAccessToSession(accessAuthenticationInfo, session.Id, allUsersGroupGuid);
                        lblUpdated.Text += session.Name + " is now " + flashData.title + "<br />\r\n";
                        sessionsToMoveList.Add(session.Id);
                    }
                    else
                    {
                        lblNotUpdated.Text += session.Name + "<br />\r\n";
                    }

                }
            }

            sessionMgr.MoveSessions(sessionAuthenticationInfo, sessionsToMoveList.ToArray(), processedFolderGuid);

            if (lastPage)
                btnReload.Visible = false;

        }
    }
}
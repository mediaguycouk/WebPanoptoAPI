using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoSessionManagement;

namespace WebPanoptoAPI.superadmin
{
    public partial class MakeLiveBackupLink : System.Web.UI.Page
    {
        private PanoptoSessionManagement.AuthenticationInfo sessionAuthenticationInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((string) Session["lastPage"] != "page2")
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("Login.aspx");
            }

            if (ddlFolderToUnlock.Items.Count == 0)
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
                    ISessionManagement sessionMgr = new SessionManagementClient();
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
                            ddlFolderToUnlock.Items.Add(new ListItem(folder.Name, folder.Id.ToString()));
                        }
                    }

                    page++;
                }
            }

            MultiView1.SetActiveView(View1);
        }

        protected void btnMakeLink_Click(object sender, EventArgs e)
        {
            string payload = ddlFolderToUnlock.SelectedValue + txtDay.Text + "/" + txtMonth.Text +
                "/" + txtYear.Text + WebPanoptoAPI.PasswordsNotToBePublished.LiveLinkSalt();

            var data = Encoding.ASCII.GetBytes(payload);
            var hashData = new System.Security.Cryptography.SHA1Managed().ComputeHash(data);

            var hash = string.Empty;

            foreach (var b in hashData)
                hash += b.ToString("X2");

            txtBackupLink.Text = "https://coursecast.soton.ac.uk/api/live/?folder=" + ddlFolderToUnlock.SelectedValue +
                                 "&date=" + txtDay.Text + "/" + txtMonth.Text + "/" + txtYear.Text + "&password=" +
                                 hash.Substring(0, 6);

            MultiView1.SetActiveView(View2);
        }

    }
}
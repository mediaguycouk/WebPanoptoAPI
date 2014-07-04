using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoSessionManagement;

namespace WebPanoptoAPI.live
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                lblError.Text += "<p>This page only works when you have been sent a long link from a member " +
                    " of staff. It will look like this:</p>\r\n";
                lblError.Text += "<p>https://coursecast.soton.ac.uk/api/live/?folder=36478214-67aa-854e-a2da-4d1b17017cdc&date=04/07/2014&password=84FAE4</p>\r\n";
                return;
            }
            if (Request["folder"] == null)
            {
                lblError.Text += "<p>The URL is invalid. It should include a folder parameter.</p>\r\n";
                return;
            }
            if (Request["date"] == null)
            {
                lblError.Text += "<p>The URL is invalid. It should include a date parameter.</p>\r\n";
                return;
            }
            if (Request["password"] == null)
            {
                lblError.Text += "<p>The URL is invalid. It should include a password parameter.</p>\r\n";
                return;
            }

            Guid folderGuid;
            DateTime unlockDateTime;
            if (!Guid.TryParse(Request["folder"], out folderGuid))
            {
                lblError.Text += "<p>The folder id is invalid.</p>\r\n";
                return;
            }

            if (!DateTime.TryParse(Request["date"], out unlockDateTime))
            {
                lblError.Text += "<p>The date parameter invalid.</p>\r\n";
                return;
            }
            if (!unlockDateTime.Equals(DateTime.Today))
            {
                lblError.Text += "<p>This link is only valid on " + unlockDateTime.ToShortDateString() + "</p>\r\n";
                return;
            }
            if (!checkSixDigitHash(folderGuid, unlockDateTime, Request["password"]))
            {
                lblError.Text += "<p>The password is not correct.</p>\r\n";
                return;
            }
            
            MultiView1.SetActiveView(viewShowLinks);

            // PUT YOUR AUTHENTICATION DETAILS HERE

            PanoptoSessionManagement.AuthenticationInfo sessionAuthInfo = new PanoptoSessionManagement.AuthenticationInfo()
            {
                UserKey = "liveapi",
                Password = WebPanoptoAPI.PasswordsNotToBePublished.LiveApiPassword()
            };

            // END OF AUTHENTICATION DETAILS

            // START WRITING CODE HERE

            bool lastPage = false;
            int resultsPerPage = 50;
            int page = 0;
            SessionState[] sessionStates = new SessionState[1] { SessionState.Broadcasting };
            PlaceHolder1.Controls.Clear();

            while (!lastPage)
            {
                PanoptoSessionManagement.Pagination pagination =
                    new PanoptoSessionManagement.Pagination { MaxNumberResults = resultsPerPage, PageNumber = page };
                PanoptoSessionManagement.ListSessionsRequest request =
                    new PanoptoSessionManagement.ListSessionsRequest { Pagination = pagination, States = sessionStates };
                ISessionManagement sessionMgr = new SessionManagementClient();
                ListSessionsResponse response = sessionMgr.GetSessionsList(sessionAuthInfo, request, null);

                if (resultsPerPage*(page + 1) >= response.TotalNumberResults)
                {
                    lastPage = true;
                }

                if (response.Results.Length > 0)
                {
                    foreach (Session session in response.Results)
                    {
                        Label placeholderLabel = new Label();
                        placeholderLabel.Text = "<p class=\"larger\"><a href=\"" + session.ViewerUrl + "\">" + session.Name + "</a></p>\r\n";
                        PlaceHolder1.Controls.Add(placeholderLabel);
                        lblFollowingRecordings.Visible = true;
                    }
                }
                else
                {
                    Label placeholderLabel = new Label();
                    placeholderLabel.Text =
                        "<p>There are no live streams currently broadcasting in this folder. Try refreshing in a minute.<p>";
                    PlaceHolder1.Controls.Add(placeholderLabel);
                    lblFollowingRecordings.Visible = false;
                }

                page++;

            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }

        internal bool checkSixDigitHash(Guid guid, DateTime date, String password)
        {
            string payload = guid.ToString() + date.ToShortDateString() + WebPanoptoAPI.PasswordsNotToBePublished.LiveLinkSalt();

            var data = Encoding.ASCII.GetBytes(payload);
            var hashData = new System.Security.Cryptography.SHA1Managed().ComputeHash(data);

            var hash = string.Empty;

            foreach (var b in hashData)
                hash += b.ToString("X2");

            return hash.Substring(0, 6).Equals(password.ToUpper());
        }
    }
}
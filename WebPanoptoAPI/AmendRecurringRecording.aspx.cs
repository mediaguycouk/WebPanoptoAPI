﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoRemoteRecorderManagement;
using WebPanoptoAPI.PanoptoSessionManagement;

namespace WebPanoptoAPI
{
    public partial class AmendRecurringRecording : System.Web.UI.Page
    {
        private PanoptoRemoteRecorderManagement.AuthenticationInfo remoteAuthInfo;
        private PanoptoSessionManagement.AuthenticationInfo sessionAuthenticationInfo;

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
                        ddlFolders.Items.Add(new ListItem(folder.Name, folder.Id.ToString()));
                    }
                }

                page++;

            }

            MultiView1.SetActiveView(View1);
        }

        protected void btnScheduledFolder_Click(object sender, EventArgs e)
        {
            sessionAuthenticationInfo = new PanoptoSessionManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            remoteAuthInfo = new PanoptoRemoteRecorderManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            IRemoteRecorderManagement remoteMgr = new RemoteRecorderManagementClient();
            ISessionManagement sessionMgr = new SessionManagementClient();

            bool lastPage = false;
            int resultsPerPage = 5;
            int page = 0;

            while (!lastPage)
            {
                PanoptoSessionManagement.Pagination pagination =
                    new PanoptoSessionManagement.Pagination { MaxNumberResults = resultsPerPage, PageNumber = page };
                SessionState[] stateScheduled = new SessionState[1] { SessionState.Scheduled };
                PanoptoSessionManagement.ListSessionsRequest request =
                    new PanoptoSessionManagement.ListSessionsRequest { Pagination = pagination, States = stateScheduled, FolderId = new Guid(ddlFolders.SelectedValue) };

                ListSessionsResponse response = sessionMgr.GetSessionsList(sessionAuthenticationInfo, request, null);

                if (resultsPerPage * (page + 1) >= response.TotalNumberResults)
                {
                    lastPage = true;
                }

                if (response.Results.Length > 0)
                {
                    foreach (Session session in response.Results)
                    {
                        ddlScheduledSessionList.Items.Add(new ListItem(session.Name + " (" + session.StartTime.ToString() + ")", session.Id.ToString()));
                    }
                }
                else
                {
                    Console.WriteLine("No sessions found");
                }

                page++;

            }

            MultiView1.SetActiveView(View2);
        }

    }
}
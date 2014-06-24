using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoAccessManagement;
using WebPanoptoAPI.PanoptoSessionManagement;

namespace WebPanoptoAPI
{
    public partial class CreateFolderStructureFromRootFolders : System.Web.UI.Page
    {
        private PanoptoSessionManagement.AuthenticationInfo sessionAuthInfo;
        private PanoptoAccessManagement.AuthenticationInfo accessAuthInfo;
        
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

            MultiView1.SetActiveView(View1);
        }

        protected void btnSubmitView1_Click(object sender, EventArgs e)
        {
            // PUT YOUR AUTHENTICATION DETAILS HERE
            PanoptoSessionManagement.AuthenticationInfo sessionAuthInfo = new PanoptoSessionManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            PanoptoAccessManagement.AuthenticationInfo accessAuthInfo = new PanoptoAccessManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            bool lastPage = false;
            int resultsPerPage = 100;
            int page = 0;

            Dictionary<Guid, string> allRootFoldersDictionary = new Dictionary<Guid, string>();
            Dictionary<Guid, string> subjectFoldersDictionary = new Dictionary<Guid, string>();
            Dictionary<Guid, string> courseFoldersDictionary = new Dictionary<Guid, string>();
            Dictionary<Guid, string> notRootFoldersDictionary = new Dictionary<Guid, string>();

            ISessionManagement sessionMgr = new SessionManagementClient();
            //IAccessManagement accessMgr = new AccessManagementClient();

            while (!lastPage)
            {
                PanoptoSessionManagement.Pagination pagination = new PanoptoSessionManagement.Pagination { MaxNumberResults = resultsPerPage, PageNumber = page };
                ListFoldersResponse response = sessionMgr.GetFoldersList(sessionAuthInfo, new ListFoldersRequest { Pagination = pagination, SortIncreasing = true }, null);

                if (resultsPerPage * (page + 1) >= response.TotalNumberResults)
                {
                    lastPage = true;
                }

                if (response.Results.Length > 0)
                {
                    foreach (Folder folder in response.Results)
                    {
                        if (Regex.IsMatch(folder.Name, "^[A-Z]{4}$"))
                        {
                            subjectFoldersDictionary.Add(folder.Id, folder.Name);
                        }
                        else if (Regex.IsMatch(folder.Name, "^[A-Z]{4}[0-9]{4}$"))
                        {
                            courseFoldersDictionary.Add(folder.Id, folder.Name);
                        }
                        else if (Regex.IsMatch(folder.Name, "[A-Z]{4}[0-9]{4}.+$") && folder.ParentFolder.Equals(null))
                        {
                            allRootFoldersDictionary.Add(folder.Id, folder.Name);
                        }
                        else
                        {
                            notRootFoldersDictionary.Add(folder.Id, folder.Name);
                        }
                    }
                }

                page++;
            }

            string lastSubject = "";
            string lastCourse = "";

            foreach (var key in allRootFoldersDictionary.Keys)
            {
                if (allRootFoldersDictionary[key].Length > 8)
                {
                    string subject = allRootFoldersDictionary[key].Substring(0, 4);
                    string course = allRootFoldersDictionary[key].Substring(0, 8);
                    Guid subjectFolder = Guid.Empty;
                    Guid courseFolder = Guid.Empty;

                    //FolderAccessDetails folderAccessDetails = accessMgr.GetFolderAccessDetails(accessAuthInfo, key);

                    if (subjectFoldersDictionary.ContainsValue(subject))
                    {
                        if (!lastSubject.Equals(subject))
                        {
                            lblFolderStructure.Text += "<p class=\"existlevel1\">" + subject + "</p>\r\n";
                        }
                    }
                    else
                    {
                        if (!lastSubject.Equals(subject))
                        {
                            lblFolderStructure.Text += "<p class=\"newlevel1\">" + subject + "</p>\r\n";
                        }
                    }

                    lastSubject = subject;


                    if (courseFoldersDictionary.ContainsValue(course))
                    {
                        if (!lastCourse.Equals(course))
                        {
                            lblFolderStructure.Text += "<p class=\"existlevel2\">" + allRootFoldersDictionary[key] + "</p>\r\n";
                        }
                    }
                    else
                    {
                        if (!lastCourse.Equals(course))
                        {
                            lblFolderStructure.Text += "<p class=\"newlevel2\">" + course + "</p>\r\n";
                        }

                    }
                    lastCourse = course;

                    lblFolderStructure.Text += "<p class=\"existlevel3\">" + allRootFoldersDictionary[key] + "</p>\r\n";

                }
            }

            foreach (var key in notRootFoldersDictionary.Keys)
            {
                lblIgnoredFolders.Text += "<p class=\"existlevel1\">" + notRootFoldersDictionary[key] + "</p>\r\n";
            }

            MultiView1.SetActiveView(View2);
        }

    }
}
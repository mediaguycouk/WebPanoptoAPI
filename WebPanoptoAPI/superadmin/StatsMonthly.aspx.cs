using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoSessionManagement;
using WebPanoptoAPI.PanoptoUsageManagement;

namespace WebPanoptoAPI.superadmin
{
    public partial class MonthlyStats : System.Web.UI.Page
    {
        private DateTime currentMonth;
        private DateTime activeMonth;
        private PanoptoUsageManagement.AuthenticationInfo usageAuthenticationInfo;
        
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

            currentMonth = !IsPostBack ? DateTime.Now : DateTime.Parse(hiddenDate.Value);
            currentMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);

            lblCurrentMonth.Text = currentMonth.ToString("MMMM yyyy");

            hiddenDate.Value = currentMonth.AddMonths(-1).ToLongDateString();

            usageAuthenticationInfo = new PanoptoUsageManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            IUsageReporting usageMgr = new UsageReportingClient("BasicHttpBinding_IUsageReporting", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/UsageReporting.svc");

            DateTime nextMonth = currentMonth.AddMonths(1);

            SummaryUsageResponseItem[] usageResponseItems = usageMgr.GetSystemSummaryUsage(usageAuthenticationInfo,
                currentMonth, nextMonth, UsageGranularity.Weekly);

            int views = 0;
            int uniqueUsers = 0;
            double minutes = 0;
            double hours = 0;

            foreach (SummaryUsageResponseItem item in usageResponseItems)
            {
                views += item.Views;
                uniqueUsers += item.UniqueUsers;
                minutes += item.MinutesViewed;
            }

            hours = minutes/60;

            lblViews.Text = views.ToString();
            lblUniqueUsers.Text = uniqueUsers.ToString();
            lblMinutesViewed.Text = Math.Round(minutes).ToString();
            lblHoursViewed.Text = Math.Round(hours).ToString();

        }
    }
}
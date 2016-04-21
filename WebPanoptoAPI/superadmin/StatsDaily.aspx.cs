using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPanoptoAPI.PanoptoSessionManagement;
using WebPanoptoAPI.PanoptoUsageManagement;

namespace WebPanoptoAPI.superadmin
{
    public partial class WeeklyStats : System.Web.UI.Page
    {
        private DateTime currentMonth;
        private DateTime activeMonth;
        private PanoptoUsageManagement.AuthenticationInfo usageAuthenticationInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                currentMonth = DateTime.Now;
                currentMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
                LoadStats();
            }
        }


        
        protected void LoadStats()
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

            //currentMonth = !IsPostBack ? DateTime.Now : activeMonth;

            //currentMonth = !IsPostBack ? DateTime.Now : DateTime.Parse(hiddenDate.Value);
            currentMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);

            hiddenPreviousYear.Value = currentMonth.AddMonths(-12).ToLongDateString();
            hiddenPreviousMonth.Value = currentMonth.AddMonths(-1).ToLongDateString();
            hiddenNextMonth.Value = currentMonth.AddMonths(1).ToLongDateString();
            hiddenNextYear.Value = currentMonth.AddMonths(12).ToLongDateString();

            usageAuthenticationInfo = new PanoptoUsageManagement.AuthenticationInfo()
            {
                UserKey = (string)Session["apiUsername"],
                Password = (string)Session["apiPassword"]
            };

            IUsageReporting usageMgr = new UsageReportingClient("BasicHttpBinding_IUsageReporting", "https://" + Session["server"] + "/Panopto/PublicAPISSL/4.6/UsageReporting.svc");

            DateTime nextMonth = currentMonth.AddMonths(1);

            SummaryUsageResponseItem[] usageResponseItems = usageMgr.GetSystemSummaryUsage(usageAuthenticationInfo,
                currentMonth, nextMonth, UsageGranularity.Daily);

            double minutes = 0;
            double hours = 0;

            TableRow headRowRow = new TableRow();
            tblStats.Rows.Add(headRowRow);

            TableCell headDate = new TableCell();
            TableCell headViews = new TableCell();
            TableCell headUnique = new TableCell();
            TableCell headHours = new TableCell();

            headDate.Text = "Date";
            headViews.Text = "Views";
            headUnique.Text = "Unique views";
            headHours.Text = "Hours viewed";

            headRowRow.Cells.Add(headDate);
            headRowRow.Cells.Add(headViews);
            headRowRow.Cells.Add(headUnique);
            headRowRow.Cells.Add(headHours);

            foreach (SummaryUsageResponseItem item in usageResponseItems)
            {
                TableRow tRow = new TableRow();
                tblStats.Rows.Add(tRow);

                TableCell cellDate = new TableCell();
                TableCell cellViews = new TableCell();
                TableCell cellUnique = new TableCell();
                TableCell cellHours = new TableCell();

                cellDate.Text = item.Time.ToShortDateString();
                cellViews.Text = item.Views.ToString();
                cellUnique.Text = item.UniqueUsers.ToString();
                minutes =  item.MinutesViewed;
                hours = Math.Round(minutes/60);
                cellHours.Text = hours.ToString();

                tRow.Cells.Add(cellDate);
                tRow.Cells.Add(cellViews);
                tRow.Cells.Add(cellUnique);
                tRow.Cells.Add(cellHours);
            }

        }

        protected void btnPreviousYear_Click(object sender, EventArgs e)
        {
            currentMonth = DateTime.Parse(hiddenPreviousYear.Value);
            LoadStats();
        }

        protected void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            currentMonth = DateTime.Parse(hiddenPreviousMonth.Value);
            LoadStats();
        }

        protected void btnNextMonth_Click(object sender, EventArgs e)
        {
            currentMonth = DateTime.Parse(hiddenNextMonth.Value);
            LoadStats();
        }

        protected void btnNextYear_Click(object sender, EventArgs e)
        {
            currentMonth = DateTime.Parse(hiddenNextYear.Value);
            LoadStats();
        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }
    }
}
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatsMonthly.aspx.cs" Inherits="WebPanoptoAPI.superadmin.MonthlyStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        The following statistics are for the month of
        </p>
<table>
  <tr>
    <td>&nbsp;</td>
    <td>Minutes viewed</td>
    <td>Hours viewed</td>
    <td>Views</td>
    <td>Unique users</td>
  </tr>
  <tr>
    <td>
        <asp:Label ID="lblCurrentMonth" runat="server"></asp:Label>
      </td>
    <td>
        <asp:Label ID="lblMinutesViewed" runat="server" Text="Label"></asp:Label>
      </td>
    <td>
        <asp:Label ID="lblHoursViewed" runat="server" Text="Label"></asp:Label>
      </td>
    <td>
        <asp:Label ID="lblViews" runat="server" Text="Label"></asp:Label>
      </td>
    <td>
        <asp:Label ID="lblUniqueUsers" runat="server" Text="Label"></asp:Label>
      </td>
  </tr>
</table>
    <p>
        <asp:Button ID="btnPreviousMonth" runat="server" Text="Previous Month" />
        <asp:HiddenField ID="hiddenDate" runat="server" />
</p>
</asp:Content>

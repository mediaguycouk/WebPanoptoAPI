<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatsDaily.aspx.cs" Inherits="WebPanoptoAPI.superadmin.WeeklyStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        The following statistics are for the month of
        </p>
    <asp:table id="tblStats" runat="server">

    </asp:table>
    
    <p>
        <asp:Button ID="btnPreviousYear" runat="server" Text="Previous Year" OnClick="btnPreviousYear_Click" />
        <asp:Button ID="btnPreviousMonth" runat="server" Text="Previous Month" OnClick="btnPreviousMonth_Click" />
        <asp:Button ID="btnNextMonth" runat="server" Text="Next Month" OnClick="btnNextMonth_Click" />
        <asp:Button ID="btnNextYear" runat="server" Text="Next Year" OnClick="btnNextYear_Click" />
        <asp:HiddenField ID="hiddenPreviousYear" runat="server" />
        <asp:HiddenField ID="hiddenPreviousMonth" runat="server" />
        <asp:HiddenField ID="hiddenNextMonth" runat="server" />
        <asp:HiddenField ID="hiddenNextYear" runat="server" />
</p>
</asp:Content>

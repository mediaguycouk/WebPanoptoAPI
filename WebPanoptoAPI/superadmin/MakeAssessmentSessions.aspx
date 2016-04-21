<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MakeAssessmentSessions.aspx.cs" Inherits="WebPanoptoAPI.MakeAssessmentSessions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <p>
                Warning: The assessment folder is hard coded to production. Do not run this against any site that isn&#39;t production.</p>
            <p>
                Enter the contents of a CSV with student details in the format</p>
            <p>
                username,Lastname,Firstname,NameOfSession<br /> gra,Robinson,Graham,Graham Robinson 1719009 Presentation<br /> pdj1k06,Jones,Peter, Graham Robinson 1726554 Presentation</p>
            <p>
                <asp:TextBox ID="txtUsers" runat="server" Columns="50" Rows="10" TextMode="MultiLine"></asp:TextBox>
            </p>
            <p>
                Choose a name for the assessment (include the course name)</p>
            <p>
                <asp:TextBox ID="txtAssessmentName" runat="server" Width="409px"></asp:TextBox>
            </p>
            <p>
                Please enter a valid Panopto username (in the format Blackboard \ username) for Panopto to check that the intergration name is correct</p>
            <p>
                <asp:TextBox ID="txtCheckInter" runat="server"></asp:TextBox>
                \<asp:TextBox ID="txtCheckUser" runat="server"></asp:TextBox>
                &nbsp;e.g. Blackboard\gra</p>
            <p>
                <asp:Button ID="btnMakeFoldersSubmit" runat="server" Text="Submit" OnClick="btnMakeFoldersSubmit_Click" />
            </p>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <h4>Next</h4>
            <p>
                You need to
                <br />
                a) Set the availability on the new folder<br /> b) Assign the tutor (or helpers) to be creators on the folders<br /> c) Check for errors below</p>
            <h4>Errors</h4>
            <p>
                <asp:Label ID="lblErrors" runat="server"></asp:Label>
            </p>
            <h4>Successes</h4>
            <p>
                <asp:Label ID="lblSuccess" runat="server"></asp:Label>
            </p>
        </asp:View>
    </asp:MultiView>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebPanoptoAPI.page2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        What do you want to do?</h2>
    <p>
        You are using the user &quot;<asp:Label ID="lblApiUsername" 
            runat="server" Text="[Username]"></asp:Label>&quot; with the role <asp:Label ID="lblApiSystemRole" runat="server" Text="Admin|Videographer|Creator|User"></asp:Label>
        .</p>
<p>
        You are connected to
        <asp:Label ID="lblServername" runat="server" Text="x.x.com"></asp:Label>
        , which is running version
        <asp:Label ID="lblVersion" runat="server" Text="x.x.x"></asp:Label>
</p>
    <h3>
        Reports</h3>
    <p>
        <a href="StatsMonthly.aspx">Monthly report values</a></p>
    <p>
        <a href="StatsDaily.aspx">Daily report values</a></p>
    <h3>
        Work with folders</h3>
    <p>
        <a href="CreateFolderStructureFromRootFolders.aspx">Create folder hierarchy from folder names</a></p>
    <p>
        <a href="UpdateFolderParent.aspx">Update parent folder</a></p>
    <p>
        <a href="MoveAllSessionsToNewFolder.aspx">Move all sessions from one folder to another</a></p>
<p>
        <a href="MakeVideosPublic.aspx">Make sessions in a folder public</a></p>
    <p>
        <a href="MakeVideosInternal.aspx">Make sessions in a folder internal</a></p>
    <p>
        <a href="MakeFolders.aspx">Make folders from a list</a></p>
    <h3>
        Work with sessions</h3>
    <p>
        <a href="ListVideoURLs.aspx">Ouput a list of URLs of all sessions in a folder</a></p>
    <p>
        <a href="UpdateUploadedFlashMetadata.aspx">Update MetaData for processed 
        streaming.soton files</a></p>
    <h3>
        Working with remote recorders</h3>
    <p>
        <a href="AmendRecurringRecording.aspx">Amend a recurring recorrding</a></p>
    <h3>
        Work with users</h3>
    <p>
        <a href="FillInternalGroupFromAdGroup.aspx">Fill an internal Panopto group with 
        users from an AD group</a></p>
    <p>
        <a href="MakeAssessmentSessions.aspx">Create a student assessment folder</a></p>
</asp:Content>

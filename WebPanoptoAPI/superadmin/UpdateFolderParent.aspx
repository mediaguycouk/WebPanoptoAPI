<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateFolderParent.aspx.cs" Inherits="WebPanoptoAPI.UpdateFolderParent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <strong>This page was created for testing. Caution should be used.</strong></p>
    <p>
        Folder to move</p>
    <p>
        <asp:DropDownList ID="ddlFolderToMove" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Parent folder</p>
    <p>
        <asp:DropDownList ID="ddlParentFolder" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="btnUpdateFolder" runat="server" onclick="btnUpdateFolder_Click" 
            Text="Update Parent Folder" />
    </p>
</asp:Content>

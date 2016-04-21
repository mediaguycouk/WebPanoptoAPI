<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateUploadedFlashMetadata.aspx.cs" Inherits="WebPanoptoAPI.superadmin.UpdateUploadedFlashMetadata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    The following videos have been updated and moved</p>
<p>
    <asp:Label ID="lblUpdated" runat="server"></asp:Label>
</p>
<p>
    The following videos were not found</p>
<p>
    <asp:Label ID="lblNotUpdated" runat="server"></asp:Label>
</p>
<p>
    <asp:Button ID="btnReload" runat="server" Text="Re-Run on next 100 videos" />
</p>
</asp:Content>

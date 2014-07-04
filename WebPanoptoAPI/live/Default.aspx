<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebPanoptoAPI.live.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:HiddenField ID="hidFolder" runat="server" />
    <asp:HiddenField ID="hidDate" runat="server" />
    <h1>Panopto Live Link</h1>
    <asp:Label ID="lblError" runat="server" CssClass="failureNotification"></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewShowLinks" runat="server">
            <asp:Label ID="lblFollowingRecordings" runat="server" 
                Text="<p>The following live recordings are available:</p>"></asp:Label>
            <p>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </p>
            <p>
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh List" 
                    onclick="btnRefresh_Click" />
            </p>
        </asp:View>
    </asp:MultiView>
</asp:Content>

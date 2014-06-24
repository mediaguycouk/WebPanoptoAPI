<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AmendRecurringRecording.aspx.cs" Inherits="WebPanoptoAPI.AmendRecurringRecording" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <p>
                Which folder contains the recordings to amend?</p>
            <p>
                <asp:DropDownList ID="ddlFolders" runat="server">
                </asp:DropDownList>
            </p>
            <p>
                <asp:Button ID="btnScheduledFolder" runat="server" OnClick="btnScheduledFolder_Click" Text="Button" />
            </p>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <p>
                Select the first session you wish to amend (sessions scheduled before this will not be changed)</p>
            <p>
                <asp:DropDownList ID="ddlScheduledSessionList" runat="server">
                </asp:DropDownList>
            </p>
        </asp:View>
    </asp:MultiView>
</asp:Content>

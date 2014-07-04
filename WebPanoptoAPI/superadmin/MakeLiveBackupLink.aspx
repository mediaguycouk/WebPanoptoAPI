<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MakeLiveBackupLink.aspx.cs" Inherits="WebPanoptoAPI.superadmin.MakeLiveBackupLink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <p>
                Which folder will the live stream stream from?</p>
            <p>
                <asp:DropDownList ID="ddlFolderToUnlock" runat="server">
                </asp:DropDownList>
            </p>
            <p>
                What date should the backup link work on?</p>
            <p>
                <asp:TextBox ID="txtDay" runat="server">dd</asp:TextBox>
                /<asp:TextBox ID="txtMonth" runat="server">mm</asp:TextBox>
                /<asp:TextBox ID="txtYear" runat="server">yyyy</asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnMakeLink" runat="server" onclick="btnMakeLink_Click" 
                    Text="Make Link" />
            </p>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <p>
                Here is your backup link</p>
            <p>
                <asp:TextBox ID="txtBackupLink" runat="server" Columns="100"></asp:TextBox>
            </p>
        </asp:View>
    </asp:MultiView>
</asp:Content>

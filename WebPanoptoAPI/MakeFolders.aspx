<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MakeFolders.aspx.cs" Inherits="WebPanoptoAPI.MakeFolders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <p>
                On each line, enter the names of the folders you wish to create</p>
            <p>
                <asp:TextBox ID="txtFolderNames" runat="server" Columns="50" Rows="10" TextMode="MultiLine"></asp:TextBox>
            </p>
            <p>
                Select a group assigned as creators</p>
            <p>
                <asp:DropDownList ID="ddlCreators" runat="server">
                    <asp:ListItem Value="0">Do not add a creator group</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                Select a group assigned as viewers</p>
            <p>
                <asp:DropDownList ID="ddlViewers" runat="server">
                    <asp:ListItem Value="0">Do not add a viewer group</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:CheckBox ID="checkRemoveApiUser" runat="server" Text="Remove the API user from the folder's creators list" />
            </p>
            <p>
                <asp:Button ID="btnMakeFoldersSubmit" runat="server" Text="Submit" OnClick="btnMakeFoldersSubmit_Click" />
            </p>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <h4>Folders created</h4>
            <p>
                <asp:Label ID="lblFoldersCreated" runat="server"></asp:Label>
            </p>
            <h4>Folders not created</h4>
            <p>
                <asp:Label ID="lblFoldersNotCreated" runat="server"></asp:Label>
            </p>
        </asp:View>
    </asp:MultiView>
</asp:Content>

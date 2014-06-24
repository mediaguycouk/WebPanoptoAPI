<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MoveAllSessionsToNewFolder.aspx.cs" Inherits="WebPanoptoAPI.MoveAllSessionsToNewFolder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <p class="help">Choose the folder to move the sessions from and the folder to move it to. You will be given
            the oppotunity to check the folder is correct on the next page.</p>
            <table cellspacing="10">
                <tr>
                    <th>
                        Move sessions from</th>
                    <th>
                        Move sessions to</th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlMoveFrom" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMoveTo" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <p>
                <asp:Button ID="btnSelectFolders" runat="server" 
                    onclick="btnSelectFolders_Click" Text="Submit" />
            </p>
        </asp:View> 
        <asp:View ID="View2" runat="server">
            <p>
                The following sessions will be moved into the folder
                <asp:Label ID="lblToFolder" runat="server" Text="Label"></asp:Label>
                . You can check if this is the right destination folder by clicking
                <asp:Label ID="lblToFolderUrl" runat="server" Text="here"></asp:Label>
                .</p>
            <ul>
                <asp:Label ID="lblSessionList" runat="server"></asp:Label>
            </ul>
            <p>
                <asp:Button ID="btnConfirmMove" runat="server" onclick="btnConfirmMove_Click" 
                    Text="Confirm and move" />
            </p>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <asp:Label ID="lblMoveConfirmation" runat="server"></asp:Label>
        </asp:View>
    </asp:MultiView>
</asp:Content>

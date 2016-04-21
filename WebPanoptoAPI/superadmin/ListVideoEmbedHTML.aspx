<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListVideoEmbedHTML.aspx.cs" Inherits="WebPanoptoAPI.ListVideoEmbedHTML" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <p>Choose a folder to list URLs</p>
            <table cellspacing="10">
                <tr>
                    <th>
                        Folder</th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlFolder" runat="server">
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
                Copy and paste the following<br />
                <asp:TextBox ID="TextBox1" runat="server" Height="250px" TextMode="MultiLine" Width="500px"></asp:TextBox>
            </p>
            
        </asp:View>
        <asp:View ID="View3" runat="server">
            <asp:Label ID="lblMoveConfirmation" runat="server"></asp:Label>
        </asp:View>
    </asp:MultiView>
</asp:Content>

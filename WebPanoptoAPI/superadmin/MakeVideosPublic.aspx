<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MakeVideosPublic.aspx.cs" Inherits="WebPanoptoAPI.MakeVideosPublic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <p>Choose the folder to move the sessions from and the folder to move it to. You will be given
            the oppotunity to check the folder is correct on the next page.</p>
            <table cellspacing="10">
                <tr>
                    <th>
                        Make videos in this folder public</th>
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
                The following sessions will be made public. <span class="publicTrue">Sessions that are already public are 
                highlighted green</span>. <span class="publicFalse">Sessions that are not public are highlighted red</span>.</p>
            <p>
                <asp:CheckBoxList ID="chklistSessions" runat="server">
                </asp:CheckBoxList>
            </p>
            <p>
                <asp:Button ID="btnConfirmUpdate" runat="server" onclick="btnConfirmMove_Click" 
                    Text="Confirm and update" />
            </p>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <asp:Label ID="lblMoveConfirmation" runat="server"></asp:Label>
        </asp:View>
    </asp:MultiView>
</asp:Content>

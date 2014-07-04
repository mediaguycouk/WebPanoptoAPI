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
                <asp:Button ID="btnScheduledFolder" runat="server" OnClick="btnScheduledFolder_Click" Text="Submit" />
            </p>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <p>
                Select the sessions you wish to amend and the amedments to make</p>
            <p>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </p>
            <p>
                <asp:CheckBox ID="checkDuration" runat="server" Text="Change duration to " />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                &nbsp;minutes</p>
            <p>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Change remote recorder to " />
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </p>
            <p>
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Change recording day to " />
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem Enabled="False">Monday</asp:ListItem>
                    <asp:ListItem>Tuesday</asp:ListItem>
                    <asp:ListItem>Wednesday</asp:ListItem>
                    <asp:ListItem>Thursday</asp:ListItem>
                    <asp:ListItem>Friday</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:CheckBox ID="CheckBox3" runat="server" Text="Change start time to" />
                &nbsp;<asp:DropDownList ID="DropDownList3" runat="server">
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList4" runat="server">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Button ID="btnFirstSessionList" runat="server" Text="Submit" OnClick="btnFirstSessionList_Click" />
            </p>
        </asp:View>
        <asp:View ID="View3" runat="server"></asp:View>
    </asp:MultiView>
</asp:Content>

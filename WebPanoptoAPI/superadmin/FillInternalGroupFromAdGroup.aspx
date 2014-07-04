<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FillInternalGroupFromAdGroup.aspx.cs" Inherits="WebPanoptoAPI.FillInternalGroupFromAdGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Fill an internal Panopto group with users from an AD group
    </h2>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
           <p class="help">
                An AD group of the name AdSync-ADGroupName should exist on the server. Make it manually in the UI if it doesn&#39;t exist.</p>
           <p>
            What is the name of the AD group to sync</p> 
            <asp:Label ID="lblAdGroupNameError" runat="server" CssClass="failureNotification"></asp:Label>  
            <p>
                <asp:TextBox ID="txtAdGroupName" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnSubmitAdGroupSearch" runat="server" 
                    onclick="btnSubmitAdGroupName_Click" Text="Submit" />
            </p>
        </asp:View>   
        <asp:View ID="View2" runat="server">
            <p class="help">
                The Panopto API doesn&#39;t return who owns a group so there may be multiple rows with the same name and different IDs. Take care.</p>
            <p>
                Choose an Internal group to fill</p>
        <p>
        <asp:DropDownList ID="ddlInternalGroups" runat="server">
        </asp:DropDownList>
        </p>
            <asp:Label ID="lblMembershipProviderError" runat="server" CssClass="failureNotification"></asp:Label>
            <p>
                Which membership provider should the users below to? Please also provide a username of a user using that membership provider to confirm it is correct. If you want to use internal groups then leave the first box blank.</p>
            <p>
                <asp:TextBox ID="txtMembershipProvider" runat="server"></asp:TextBox>
                \<asp:TextBox ID="txtMembershipUserToCheck" runat="server"></asp:TextBox>
                &nbsp;(e.g. Blackboard\david)</p>
            <p>
                <asp:Button ID="btnSubmitAdGroupList" runat="server" Text="Submit" OnClick="btnSubmitAdGroupList_Click" />
            </p>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <p class="help">
                Clicking sync group will remove all users from the internal group then add all members from the AD group.<br />
                <br />
                If the users do not exist they will be created with the information in Active Directory.</p>
            <p>
                <asp:Label ID="lblAdCheck" runat="server" Text="AD Check success / fail"></asp:Label>
            </p>
            <p>
                <asp:TextBox ID="txtAdUserCheck" runat="server" ReadOnly="True" Rows="10" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </p>
            <p>
                <asp:CheckBox ID="checkConfirmAdUsers" runat="server" AutoPostBack="True" OnCheckedChanged="checkConfirmAdUsers_CheckedChanged" Text="I confirm that this group is correct." />
            </p>
            <p>
                <asp:Button ID="btnAdCheckUserConfirm" runat="server" Enabled="False" Text="Sync Group" OnClick="btnAdCheckUserConfirm_Click" />
            </p>
        </asp:View>
        <asp:View ID="View4" runat="server">
            <h2>Syncing </h2>
            <p>
                All {#} users removed from group</p>
            <h4>Users added to Panopto</h4>
            <p>
                <asp:Label ID="lblAdSyncNewUserProgress" runat="server"></asp:Label>
            </p>
            <h4>Users not added to Panopto</h4>
            <p>
                Due to a lack of details in AD the following users were not added</p>
            <p>
                <asp:Label ID="lblAdSyncFailedUserProgress" runat="server"></asp:Label>
            </p>
            <h4>Users already in Panopto</h4>
            <p>
                <asp:Label ID="lblAdSyncExistingUserProgress" runat="server"></asp:Label>
            </p>
            <h4>Users added to group</h4>
            <p>
                <asp:Label ID="lblAdSyncGroupProgress" runat="server"></asp:Label>
            </p>
        </asp:View>
    </asp:MultiView>


</asp:Content>

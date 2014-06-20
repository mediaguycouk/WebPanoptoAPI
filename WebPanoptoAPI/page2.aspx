﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="page2.aspx.cs" Inherits="WebPanoptoAPI.page2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        What do you want to do?</h2>
    <p>
        You are using the user &quot;<asp:Label ID="lblApiUsername" 
            runat="server" Text="Label"></asp:Label>&quot; with the role <asp:Label ID="lblApiSystemRole" runat="server" Text="Label"></asp:Label>. Some of these actions require admin 
        rights.</p>
    <h3>
        Work with folders</h3>
    <p>
        Create folder hierarchy from folder names</p>
    <p>
        Move all sessions from one folder to another</p>
    <h3>
        Work with sessions</h3>
    <p>
        &nbsp;</p>
    <h3>
        Work with users</h3>
    <p>
        <a href="FillInternalGroupFromAdGroup.aspx">Fill an internal Panopto group with 
        users from an AD group</a></p>
</asp:Content>

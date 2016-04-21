<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="WebPanoptoAPI._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>
        Step 1</h2>
    <p>
        Please enter your server details</p>
    <asp:Label ID="lblErrorStep1" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
    <p>
        https://<asp:TextBox ID="txtFqdn" runat="server" Width="300px"></asp:TextBox>/Panopto/...
    </p>
    <p>
        Enter your API users username and password.</p>
    <p>
        Username<br />
        <asp:TextBox ID="txtApiUsername" runat="server"></asp:TextBox>
    </p>
    <p>
        Password<br />
        <asp:TextBox ID="txtApiPassword" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSubmitFqdn" runat="server" onclick="btnSubmitFqdn_Click" 
            Text="Submit" />
    </p>

</asp:Content>

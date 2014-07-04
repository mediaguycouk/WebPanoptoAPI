<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFolderStructureFromRootFolders.aspx.cs" Inherits="WebPanoptoAPI.CreateFolderStructureFromRootFolders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <p>
                This application will go through all the root folders on your server and create parent folders based on the name, up to two layers deep.</p>
            <p>
                Once created the application will put the user access list of the folder into the parent folders. If your course is based on years, this allows you to have a place where sessions do not need to be &quot;rolled over&quot; into another year to stay secure.</p>
            <p>
                The example folders &quot;EXAM1001-12345-12-13&quot;, &quot;EXAM1001-12345-13-14&quot;,&nbsp; &quot;EXAM1002-23456-12-13&quot; and &quot;EXAM1002-23456-13-14&quot; would make the following structure.</p>
            <p class="newlevel1">
                EXAM</p>
            <p class="newlevel2">
                EXAM1001</p>
            <p class="existlevel3">
                EXAM1001-12345-12-13</p>
            <p class="existlevel3">
                EXAM1001-12345-13-14</p>
            <p class="newlevel2">
                EXAM1002</p>
            <p class="existlevel3">
                EXAM1002-23456-12-13</p>
            <p class="existlevel3">
                EXAM1002-23456-13-14</p>
            <p>
                Click submit to view how this will look with your server.</p>
            <!-- If you've moved this code to your own server it is very unlikely that your courses
                have the same naming convetion as the University of Southampton. You'll have to change
                both the Regex to to check what is a subject and a course

                if (Regex.IsMatch(folder.Name, "^[A-Z]{4}$"))
                else if (Regex.IsMatch(folder.Name, "^[A-Z]{4}[0-9]{4}$"))
                else if (Regex.IsMatch(folder.Name, "^[A-Z]{4}[0-9]{4}.+$") && folder.ParentFolder.Equals(null))

                And how which characters to take off the name of the folder, which should match the Regex above
                Folder newFolder = sessionMgr.AddFolder(sessionAuthInfo,
                            allRootFoldersDictionary[key].Substring(0, 4), null, false);
                Folder newFolder = sessionMgr.AddFolder(sessionAuthInfo,
                            allRootFoldersDictionary[key].Substring(0, 8), subjectFolder, false);
                -->
            <p>
                <asp:Button ID="btnSubmitView1" runat="server" OnClick="btnSubmitView1_Click" Text="Submit" />
            </p>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <p>
                This is how your new folder structure will look, but note that we only look at root folders (i.e. folders that have not been organised already). Ignored folders are shown at the end of the page.</p>
            <asp:Label ID="lblFolderStructure" runat="server"></asp:Label>
            <h4>Ignored folders</h4>
            <p>
                <asp:Label ID="lblIgnoredFolders" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btnCommitChanges" runat="server" 
                    onclick="btnCommitChanges_Click" Text="Commit changes" />
            </p>
        </asp:View>
        <asp:View ID="View3" runat="server">Changes committed</asp:View>
    </asp:MultiView>
</asp:Content>

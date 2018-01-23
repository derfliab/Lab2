<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Project.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table id="projectinfo" style="width:200%">
        <tr>
            
            <td>
                Project Name:
            </td>
        </tr>
        <tr>
            <td>
                <input id="projectName" type="text" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Project Description:
            </td>
        </tr>
        <tr>
            <td>
                <input id="projectDescription" type="text" runat="server" />
            </td>
        </tr>
        
     </table>
          <br />
          <asp:Button ID="Clear" runat="server" style="margin-right:20px" OnClick="ClearBtn_Click" Text="Clear" />
          <asp:Button ID="ProjectCommit" runat="server" style="margin-right:20px" OnClick="ProjectCommitBtn_Click" Text="Project Commit" />
          

</asp:Content>


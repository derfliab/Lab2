<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Project.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Andrea Derflinger</title>
    <style type="text/css">
        #projectID {
            width: 150px;
        }
        #projectName {
            width: 150px;
        }
        #projectDescription {
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Project Form:</h1>
         <ul>
            <li><a href="Main.aspx">Return to Main</a></li>
            <li><a href="Employee.aspx">Add Employee</a></li>
            <li><a href="Skill.aspx">Add Skill</a></li>
        </ul>
    <div>
     <table id="projectinfo" style="width:200%">
        <tr>
            
            <td>
                Project ID:
            </td>
        </tr>
        <tr>
            <td>
                <input id="projectID" type="text" runat="server" />
            </td>
        </tr>
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
          <asp:Button ID="ProjectCommit" runat="server" style="margin-right:20px" OnClick="ProjectBtn_Click" Text="Skill Commit" />

    </div>
    </form>
 
    </body>
</html>

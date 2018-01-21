<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Skill.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #skillID {
            width: 150px;
        }
        #skillName {
            width: 150px;
        }
        #skillDescription {
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Skill Form:</h1>
        <ul>
            <li><a href="Main.aspx">Return to Main</a></li>
            <li><a href="Employee.aspx">Add Employee</a></li>
            <li><a href="Project.aspx">Add Project</a></li>
        </ul>
    <div>
    <table id="skillinfo" style="width:200%">
        <tr>
            
            <td>
                Skill ID:
            </td>
        </tr>
        <tr>
            <td>
                <input id="skillID" type="text" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Skill Name:
            </td>
        </tr>
        <tr>
            <td>
                <input id="skillName" type="text" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Skill Description:
            </td>
        </tr>
        <tr>
            <td>
                <input id="skillDescription" type="text" runat="server" />
            </td>
        </tr>
        
     </table>
          <br />
          <asp:Button ID="SkillCommit" runat="server" style="margin-right:20px" OnClick="SkillBtn_Click" Text="Skill Commit" />

    </div>
    </form>
</body>
</html>

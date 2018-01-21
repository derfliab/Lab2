﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="_Default" %>

<!--
 * CIS 484-Lab 1
 * Author: Andrea Derflinger 
 * Date: 1/19/2018
 * Honor Pledge: This work and I comply with the JMU Honor Code.
-->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Andrea Derflinger</title>
    <style>
        tr.spaceUnder>td {
        padding-bottom: 3em;
        }
        tr{
            padding: 12%;
        }
 
        .auto-style1 {
            width: 16%;
        }

    
 
        #txtEmployeeID {
            margin-left: 0px;
        }

        
 
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <h1>Employee Form:</h1>
         <ul>
            <li><a href="Main.aspx">Return to Main</a></li>
            <li><a href="Skill.aspx">Add Skill</a></li>
            <li><a href="Project.aspx">Add Project</a></li>
        </ul>
    <div> 
        <table id="employeeinfo" style="width:200%"  >
           
            <tr>
                <td class="auto-style1">
                    First Name:
                </td>
                <td>
                    House Number:
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <input type="text" id="txtFirstName" required="" runat="server" maxlength ="20"  />
                     
                </td>
                <td>
                    <input type="text" id="txtHouseNumber" required="" runat="server" maxlength="10"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Last Name:
                </td>
                <td>
                    Street:
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <input id="txtLastName" type="text" required="" runat="server" maxlength="30"/>
                </td>
                <td>
                    <input id="txtStreet" type="text" required="" runat="server" maxlength="20"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    MI*:
                </td>
                <td>
                    City/County:
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <input id="txtMI" type="text" runat="server" maxlength="1"/>
                </td>
                <td>
                    <input id="txtCity" type="text" required="" runat="server" maxlength="25"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Date-Of-Birth:
                </td>
                <td>
                    State*:
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <input id="txtDOB" type="text" required="" runat="server" placeholder="YYYY-MM-DD"/>
                    
                </td>
                <td>
                    <input id ="txtState" type="text" runat="server" maxlength="2" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Employee ID:</td>
                <td>
                    Country:
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <input id="txtEmployeeID" type="text" required="" runat="server"/></td>
                <td>
                    <input id="txtCountry" type="text"   required="" runat="server" maxlength="2"/>
                </td>
            </tr>
            <tr >
                <td class="auto-style1">

                    Skills:</td>
                <td>
                    ZipCode:
                </td>
            </tr>
            <tr>
                <td class="auto-style1">

                    <asp:DropDownList ID="DropDownSkill" required="" runat="server" Width="127px"></asp:DropDownList>

                </td>
                <td>
                     <input id="txtZip" type="text" required="" runat="server" maxlength="5"/>
                </td>
            </tr>
            <tr class="spaceUnder">
                <!-- Empty Row -->
                <td class="auto-style1">

                </td>
                <td>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Hire Date:
                </td>
                <td>
                    Termination Date*:
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                     
                    <input id="txtHire" runat="server" type="text" placeholder="YYYY-MM-DD"/>
                     
                </td>
                <td>
                    <input id="txtTerm" runat="server" type="text" placeholder="YYYY-MM-DD"/>
                     
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Manager ID*:
                </td>
                <td>
                    Salary:
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <input id="txtManager" type="text" runat="server"/>
                </td>
                <td>
                    <input id="txtSalary" required="" type="text" runat="server"/>
                </td>
            </tr>
             <tr>
                <!-- Empty Row -->
                <td class="auto-style1">

                </td>
                <td>

                </td>
            </tr>
                
   
        
        </table>
           <p>
        &nbsp*Fields may be left empty.
    </p>  
         
        
        <asp:Button ID="InsertBtn" runat="server" style="margin-right:20px" OnClick="InsertBtn_Click" Text="Insert" />
        <asp:Button ID="ClearBtn" runat="server" style="margin-right:20px" OnClick="ClearBtn_Click" Text="Clear" />
        <asp:Button ID="EmployeeCommittBtn" runat="server" style="margin-right:20px" OnClick="EmployeeCommitBtn_Click" Text="Employee Commit" />
        <asp:Button ID="ExitBtn" runat="server" style="margin-right:20px" OnClick="ExitBtn_Click" Text="Exit" formnovalidate="" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label" runat="server" />
    </div>
    </form>
    
</body>
</html>



﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
     
    
    protected void Page_Load(object sender, EventArgs e)
    {
        selectSkills();
        selectProjects();
        clearLabel();
  
    }

    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        txtFirstName.Value = "";
        txtLastName.Value = "";
        txtMI.Value = "";
        txtDOB.Value = "";
        txtHouseNumber.Value = "";
        txtStreet.Value = "";
        txtCity.Value = "";
        txtState.Value = "";
        txtCountry.Value = "";
        txtZip.Value = "";
        txtHire.Value = "";
        txtTerm.Value = "";
        txtSalary.Value = "";
        txtManager.Value = "";
    }



    protected void EmployeeCommitBtn_Click(object sender, EventArgs e)
    {
        DateTime currentDate = DateTime.Now;
        DateTime check = DateTime.Parse(txtDOB.Value).AddYears(18);
        DateTime oldcheck = DateTime.Parse(txtDOB.Value).AddYears(65);
        bool working = true;
        string country = txtCountry.Value;
        // Checks Validation for the following if statements. If any of them return false, the employee will not be added to the array.

        //Checks if the termination date has nothing in it
        if (txtTerm.Value != "")
        {


            if (compareDates(DateTime.Parse(txtHire.Value), DateTime.Parse(txtTerm.Value)) == false)
            {
                working = false;
                Label.Text += "Termination Date exceeds Hire Date";

            }
        }

        // Checks if the birthdate is over 18
        if (check.Date >= currentDate.Date)
        {
            working = false;
            Label.Text += "Invalid Birth Day- Please make sure you are over 18.";

        }

        // Checks if the birthdate is under 65
        if (oldAge(DateTime.Parse(txtDOB.Value)) >= 65)
        {
            working = false;
            Label.Text += "Invalid Birth Day- You must be younger than 65";
        }

        // Compare if the Name or EmployeeID have been inserted
        if (compareName(txtFirstName.Value, txtLastName.Value) == false)
        {
            working = false;
            Label.Text += "Name already exist in the database";
        }

        //// Checks if Manager ID exists
        //if (txtManager.Value != "")
        //{
        //    if (findManagerID(int.Parse(txtManager.Value)) == false)
        //    {
        //        working = false;
        //        Label.Text += "Manager ID does not exist";
        //    }
        //}

        // Checks if State is a valid state
        if (txtState.Value != "")
        {
            if (findState(txtState.Value) == false)
            {
                working = false;
                Label.Text += "Enter a valid state";
            }
        }

        // Checks if country is set to US
        if (country.ToUpper() != "US")
        {
            working = false;
            Label.Text += "Please make the country US";
        }

        if (working == true)
        {
            string MI;
            string State;
            DateTime Term;
            int managerID;


            if (txtMI.Value == "")
            {
                MI = "NULL";
            }
            else
            {
                MI = txtMI.Value;
            }

            if (txtState.Value == "")
            {
                State = "NULL";
            }
            else
            {
                State = txtState.Value;
            }

            if (txtTerm.Value == "")
            {
                Term = DateTime.MinValue;

            }
            else
            {
                Term = DateTime.Parse(txtTerm.Value);
            }

            if (String.IsNullOrEmpty(txtManager.Value))
            {
                managerID = -1;
            }
            else
            {
                managerID = int.Parse(txtManager.Value);
            }
             
                string name = "Andrea Derflinger";
                Employee newEmployee = new Employee(txtFirstName.Value, txtLastName.Value, MI, DateTime.Parse(txtDOB.Value), txtHouseNumber.Value, txtStreet.Value, txtCity.Value,
                                      State, txtCountry.Value, txtZip.Value, DateTime.Parse(txtHire.Value), Term, managerID, double.Parse(txtSalary.Value), name, DateTime.Now);


                CommitToDB(newEmployee);
            
        }
    }
    private void CommitToDB(Employee e)
    {

        try
        {

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";

            sc.Open();

            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;


            insert.CommandText += "insert into [dbo].[EMPLOYEE] values ('" + e.FName + "', '" + e.LName;
            if (e.MI == "NULL")
            {
                insert.CommandText += "', " + e.MI + ", '";
            }
            else
            {
                insert.CommandText += "', '" + e.MI + "', '";
            }
            insert.CommandText += e.HouseNum + "', '" + e.Street + "', '" + e.CityCountry;
            if (e.State == "NULL")
            {
                insert.CommandText += "', " + e.State + ", '";
            }
            else
            {
                insert.CommandText += "', '" + e.State + "', '";
            }
            insert.CommandText += e.Country + "', '" + e.Zip + "', '" + e.DOB + "', '" + e.HireDate;
            if (e.TermDate == DateTime.MinValue)
            {
                insert.CommandText += "', NULL, ";
            }
            else
            {
                insert.CommandText += "', '" + e.TermDate + "', ";
            }
            insert.CommandText += e.Salary;
            if (e.ManagerID == -1)
            {
                insert.CommandText += ", NULL, '";
            }
            else
            {
                insert.CommandText += ", " + e.ManagerID + ", '";
            }
            insert.CommandText += e.LastUpdatedBy + "', '" + e.LastUpdated + "')";


            Label.Text += "Employee has been added to the database!";
            insert.ExecuteNonQuery();
            sc.Close();


        }
        catch (Exception a)
        {
            Label.Text += "Error";
            Label.Text += a.Message;
        }
    }

    private void clearLabel()
    {
        Label.Text = "";
    }

    private void selectSkills()
    {

        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.CommandText = "select SkillName from [dbo].[SKILL]";
            insert.Connection = sc;
            sc.Open();
            DropDownSkill.DataSource = insert.ExecuteReader();
            DropDownSkill.DataTextField = "SkillName";
            DropDownProject.Items.Add("No Skill");
            DropDownSkill.DataBind();
            sc.Close();
        }
        catch (Exception s)
        {
            Label.Text += "Skill Error";
            Label.Text += s.Message;
        }
    }

    private void selectProjects()
    {

        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.CommandText = "select ProjectName from [dbo].[PROJECT]";
            insert.Connection = sc;
            sc.Open();
            DropDownProject.DataSource = insert.ExecuteReader();
            DropDownProject.DataTextField = "ProjectName";
            DropDownProject.Items.Add("No Project");
            DropDownProject.DataBind();
            
            sc.Close();
        }
        catch (Exception s)
        {
            Label.Text += "Project Error";
            Label.Text += s.Message;
        }
    }

    protected void ShowDataBtn_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.CommandText = "select * from [dbo].[Employee]";
        insert.Connection = sc;
        sc.Open();
        SqlDataReader rdr = insert.ExecuteReader();
        EmployeeData.DataSource = rdr;
        EmployeeData.DataBind();
        sc.Close();
         

    }

    // Find the state in an array
    private bool findState(string state)
    {
        string[] states = new string[] {"AK","ak","AL","al","AR","ar","AS","as","AZ","az","CA","ca","CO","co","CT","ct",
                      "DC","dc","DE","de","FL","fl","GA","ga","GU","gu","HI","hi","IA","ia","ID","id","IL","il","IN","in","KS","ks","KY","ky",
                      "LA","la","MA","ma","MD","md","ME","me","MI","mi","MN","mn","MO","mo","MS","ms","MT","mt","NC","nc","ND","nd","NE","ne",
                      "NH","nh","NJ","nj","NM","nm","NV","nv","NY","ny","OH","oh","OK","ok","OR","or","PA","pa","PR","pr","RI","ri","SC","sc",
                      "SD","sd","TN","tn","TX","tx","UT","ut","VA","va","VI","vi","VT","vt","WA","wa","WI","wi","WV","wv","WY","wy"};
        bool fstate = false;
        for (int i = 0; i < states.Length; i++)
        {

            string array = states[i];

            if (state == array)
            {
                fstate = true;
                return fstate;
            }

        }
        return fstate;
    }

    private bool compareDates(DateTime hiredate, DateTime termdate)
    {
        bool dateCompare = false;
        if (termdate > hiredate)
        {

            dateCompare = true;
            return dateCompare;
        }

        return dateCompare;
    }

    //Find if the employee is older than 65
    private int oldAge(DateTime dob)
    {
        int age = 0;
        age = (DateTime.Today.Year - dob.Year);
        return age;
    }
    private bool compareName(string firstName, string lastName)
    {
         
            bool comparename = true;
            int result = 0;
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;
            sc.Open();
            insert.CommandText = "select Count(*) FROM [dbo].[Employee] WHERE UPPER(FirstName) LIKE '"
             + firstName.ToUpper() + "' AND UPPER(LastName) LIKE '" + lastName.ToUpper() + "'";
            result = (int)insert.ExecuteScalar();
            sc.Close();
            if (result > 0)
            {
                comparename = false;
                return comparename;
            }

            else
            {
                return comparename;
            }
            
        




        }

    private bool compareOne(string item, string table, string field)
    {
        int result = 0;
        bool compareOne = true;
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;
        sc.Open();
        insert.CommandText = "select Count(*) FROM [dbo].[" + table + "] WHERE UPPER(" + field + ") LIKE '" + item.ToUpper() + "'";
        result = (int)insert.ExecuteScalar();
        sc.Close();
        if (result > 0)
        {
            compareOne = false;
            return compareOne;
        }

        else
        {
            return compareOne;
        }

    }

    private int findMax()
    {
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;
            sc.Open();
            insert.CommandText = "SELECT MAX(EmployeeID) FROM [dbo].[EMPLOYEE]";
            int i = (int)insert.ExecuteScalar();
            if (i == null)
            {
                return -1;
            }
            sc.Close();
            return i;

        }
        catch(Exception u)
        {
            return -1;
        }
    }

    private void insertEmployeeSkill()
    {
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;
            sc.Open();
            insert.CommandText = "insert into [dbo].[EMPLOYEESKILL] values(" + findMax() +;
            sc.Close();
        }

        catch(Exception t)
        {
            Label.Text += "Data was not inserted into EmployeeSkill table.";
        }
    }

}
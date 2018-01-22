using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

/**
 * CIS 484-Lab 1
 * Author: Andrea Derflinger 
 * Date: 1/19/2018
 * Honor Pledge: This work and I comply with the JMU Honor Code.
**/


public partial class _Default : System.Web.UI.Page
{
     
   
    public static int employeeID;
    public static string firstName;
    public static string lastName;
    public static string middleI;
    public static string houseNum;
    public static string street;
    public static string cityCounty;
    public static string state;
    public static string country;
    public static string zip;
    public static DateTime DOB;
    public static DateTime hireDate;
    public static DateTime termDate;
    public static double salary;
    public static int managerID;
    public static string lastUpdatedBy;
    public static DateTime lastUpdated;




    protected void Page_Load(object sender, EventArgs e)
    {
        selectSkills();
        clearLabel();
        employeeID = int.Parse(txtEmployeeID.Value);
        firstName = txtFirstName.Value;
        lastName = txtLastName.Value;
        middleI = txtMI.Value;
        houseNum = txtHouseNumber.Value;
        street = txtStreet.Value;
        cityCounty = txtCity.Value;
        state = txtState.Value;
        country = txtCountry.Value;
        zip = txtZip.Value;
        DOB = DateTime.Parse(txtDOB.Value);
        hireDate = DateTime.Parse(txtHire.Value);
        termDate = DateTime.Parse(txtTerm.Value);
        salary = double.Parse(txtSalary.Value);
        managerID = int.Parse(txtManager.Value);
        lastUpdatedBy = "Andrea Derflinger";
        lastUpdated = DateTime.Now;
        


        
  
        
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

    // Compare Termination  and Hire Date
    private bool compareDates(DateTime hiredate, DateTime termdate)
    {
        bool dateCompare = false;
        if(termdate > hiredate)
        {
            
            dateCompare = true;
            return dateCompare;
        }

        return dateCompare;
    }
 
 

    private void clearLabel()
    {
        Label.Text = "";
    }

    // Compare the first name and last name entered to the names entered in the array
    private bool compareName(string firstName, string lastName)
    {

        bool nameValidate = true;

        for (int i=0; i < next; i++)
        {
            
            string fullName = firstName.ToUpper() + lastName.ToUpper();
            string array = addEmployee[i].FName.ToUpper() + addEmployee[i].LName.ToUpper();
            
            if (fullName == array )
            {
                nameValidate = false;
                return nameValidate;
                 
                 
            }

             
        }
        return nameValidate;
       
    }

    // Compare the ManagerID given to the EmployeeIDs in the array
    private bool findManagerID(int managerID)
    {
        bool findManager = false; 
        for (int i=0; i<next; i++)
        {
            int array = addEmployee[i].EmployeeID;
            int currentID = managerID;

            if (array == currentID)
            {
                findManager = true;
                return findManager;
            }

        }
        return findManager;
    }

    // Compare EmployeeID given to EmployeeID in the array
    private bool compareID(string employeeID)
    {

        bool idValidate = true;

        for (int i = 0; i < next; i++)
        {

            int insertID = int.Parse(txtEmployeeID.Value);
            int array = addEmployee[i].EmployeeID;

            if (insertID == array)
            {
                idValidate = false;
                return idValidate;


            }


        }
        return idValidate;

    }

    //Find if the employee is older than 65
    private int oldAge (DateTime dob)
    {
        int age = 0;
        age = (DateTime.Today.Year - dob.Year);
        return age;
    }

    // Clear Button
    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        txtEmployeeID.Value = "";
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

    //Employee Commit Button
 

    //Employee Commit Insert
    protected void EmployeeCommitBtn_Click (object sender, EventArgs e)
    {
        
        try
        {
            
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";

            sc.Open();

            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;


            insert.CommandText += "insert into [dbo].[EMPLOYEE] values (" + e.EmployeeID + ", '" + e.FName + "', '" + e.LName;
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
            

            Label.Text += "Employees have been committed!";
            insert.ExecuteNonQuery();
            sc.Close();

            
        }
        catch (Exception a)
        {
            Label.Text += "Error";
            Label.Text += a.Message;
        }
    }

    // Delete all data in the Database
    private void deleteAll()
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;
        sc.Open();
        insert.CommandText = "DELETE FROM [dbo].[EMPLOYEE]";
        SqlDataReader data = insert.ExecuteReader();
        sc.Close();


    }

    //Upload skills from the databse into the skills dropdown
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
            DropDownSkill.DataBind();
            sc.Close();
        }
        catch (Exception s)
        {
            Label.Text += "Skill Error";
            Label.Text += s.Message;
        }
            

        
         
    }
    
    //Exit Button
    protected void ExitBtn_Click(object sender, EventArgs e)
    {
        
        Environment.Exit(0);
         
    }

}
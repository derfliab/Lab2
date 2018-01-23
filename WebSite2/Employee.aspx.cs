using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
     
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
        Employee newEmployee = new Employee(firstName, lastName, middleI, DOB, houseNum, street, cityCounty, state, country, zip, hireDate, termDate, managerID, salary, lastUpdatedBy, lastUpdated);
        CommitToDB(newEmployee);
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
            DropDownSkill.DataBind();
            sc.Close();
        }
        catch (Exception s)
        {
            Label.Text += "Skill Error";
            Label.Text += s.Message;
        }
    }

    }
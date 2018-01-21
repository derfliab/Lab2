﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 

/**
* CIS 484-Lab 1
* Author: Andrea Derflinger 
* Date: 1/19/2018
* Honor Pledge: This work and I comply with the JMU Honor Code.
**/
public class Employee
{
    public string fName;
    string lName;
    string mi;
    DateTime dateOfBirth;
    string houseNumber;
    string street;
    string cityCounty;
    string state;
    string country;
    string zip;
    DateTime hireDate;
    DateTime termDate;
    int managerID;
    int employeeID;
    double salary;
    String lastUpdateBy;
    DateTime lastUpdated;

    public Employee(int employeeID, string fName, string lName, string mi, DateTime dateOfBirth, string houseNumber, string street,
        string cityCountry, string state, string country, string zip, DateTime hireDate, DateTime termDate, int managerID, double salary, string lastUpdateBy, DateTime lastUpdated)
    {
        EmployeeID = employeeID;
        FName = fName;
        LName = lName;
        MI = mi;
        DOB = dateOfBirth;
        HouseNum = houseNumber;
        Street = street;
        CityCountry = cityCountry;
        State = state;
        Country = country;
        Zip = zip;
        HireDate = hireDate;
        TermDate = termDate;
        ManagerID = managerID;
        Salary = salary;
        LastUpdated = lastUpdated;
        LastUpdatedBy = lastUpdateBy;

    }

    // Getter and Setters
    public int EmployeeID
    {
        get { return employeeID; }
        private set { employeeID = value; }
    }
    public string FName
    {
        get { return fName; }
        private set { fName = value; }
    }

    public string LName
    {
        get { return lName; }
        private set { lName = value; }
    }

    public string MI
    {
        get { return mi; }
        private set { mi = value; }
    }

    public DateTime DOB
    {
        get { return dateOfBirth; }
        private set { dateOfBirth = value; }
    }

    public string HouseNum
    {
        get { return houseNumber; }
        private set { houseNumber = value; }
    }

    public string Street
    {
        get { return street; }
        private set { street = value; }
    }

    public string CityCountry
    {
        get { return cityCounty; }
        private set { cityCounty = value; }

    }

    public string State
    {
        get { return state; }
        private set { state = value; }
    }

    public string Country
    {
        get { return country; }
        private set { country = value; }
    }

    public string Zip
    {
        get { return zip; }
        private set { zip = value; }
    }

    public DateTime HireDate
    {
        get { return hireDate; }
        private set { hireDate = value; }
    }

    public DateTime TermDate
    {
        get
        { return termDate; }
        private set { termDate = value; }
    }

    public int ManagerID
    {
        get { return managerID; }
        private set { managerID = value; }

    }

    public double Salary
    {
        get { return salary; }
        private set { salary = value; }
    }

    public string LastUpdatedBy
    {
        get { return lastUpdateBy; }
        private set { lastUpdateBy = value; }
    }

    public DateTime
        LastUpdated
    {
        get { return lastUpdated; }
        private set { lastUpdated = value; }
    }
}
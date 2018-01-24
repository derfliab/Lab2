using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    
    protected void ProjectCommitBtn_Click(object sender, EventArgs e)
    {
        try
        {

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";

            sc.Open();

            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;


            insert.CommandText += "insert into [dbo].[PROJECT] values ('" + txtprojectName.Value + "', '" + txtprojectDescription.Value + "', 'Andrea Derflinger', '" + DateTime.Now + "')";


            Label.Text += "Project has been added to database!";
            insert.ExecuteNonQuery();
            sc.Close();


        }
        catch (Exception a)
        {
            Label.Text += "Error";
            Label.Text += a.Message;
        }
    }

    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        txtprojectName.Value = "";
        txtprojectDescription.Value = "";
    }
}
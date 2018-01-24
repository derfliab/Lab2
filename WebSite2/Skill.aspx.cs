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

    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        txtskillName.Value = "";
        txtskillDescription.Value = "";
    }
 
    protected void SkillBtn_Click(object sender, EventArgs e)
    {
         
        try
        {

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab2;Trusted_Connection=Yes;";

            sc.Open();

            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;


            insert.CommandText += "insert into [dbo].[SKILL] values ('" + txtskillName.Value + "', '" + txtskillDescription.Value + "', 'Andrea Derflinger', '" + DateTime.Now + "')";



            Label.Text += "Skill has been added to database!";
            insert.ExecuteNonQuery();
            sc.Close();


        }
        catch (Exception a)
        {
            Label.Text += "Error";
            Label.Text += a.Message;
        }
    }

}
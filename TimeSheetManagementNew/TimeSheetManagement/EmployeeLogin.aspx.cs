using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TimeSheetManagement
{
    public partial class EmployeeLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(HomePage.connectString);
            conn.Open();
            try
            {
                SqlCommand sqlComm = new SqlCommand("EmployeeLogin", conn);
                sqlComm.Parameters.AddWithValue("@mail", TextBox1.Text);
                sqlComm.Parameters.AddWithValue("@password", TextBox2.Text);
                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = sqlComm.ExecuteReader();
                if (sdr.Read())
                {
                    Session["UserName"] = TextBox1.Text;
                    //Response.Redirect("Employeepanel.aspx");
                    Response.Redirect("EmployeePanel?email=" + TextBox1.Text);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid username or password')", true);
                }
            }
            catch (Exception)
            {
            }


        }
    }
}
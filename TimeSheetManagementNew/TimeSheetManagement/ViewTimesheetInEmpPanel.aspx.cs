using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeSheetManagement
{
    public partial class ViewTimesheetInEmpPanel : System.Web.UI.Page
    {
        
        void showTimesheetSync()
        {
            // string email = Request.QueryString["mail"];

            SqlConnection conn = new SqlConnection(HomePage.connectString);
            conn.Open();
            if (String.Equals(TextBox1.Text, ""))
            {
                SqlCommand sqlComm = new SqlCommand("AllTimesheetShowInEmpPanel", conn);
                sqlComm.Parameters.AddWithValue("@mail", EmployeePanelMaster.email);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlComm);
                DataSet ds = new DataSet();
                dataAdp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                
            }
            else
            {
                SqlCommand sqlComm = new SqlCommand("TimesheetShowInEmpPanel", conn);
                sqlComm.Parameters.AddWithValue("@mail", EmployeePanelMaster.email);
                sqlComm.Parameters.AddWithValue("@Date", DateTime.Parse(TextBox1.Text));
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlComm);
                DataSet ds = new DataSet();
                dataAdp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                conn.Close();
            }
            conn.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmpUserName"] == null)
            {
                Response.Redirect("EmployeeLogin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            showTimesheetSync();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string mailID = EmployeePanelMaster.email;
            string projectName = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values["Project_Name"]);
            string taskID = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values["Task_ID"]);

            SqlConnection conn = new SqlConnection(HomePage.connectString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteTimesheet", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mail", mailID);
            cmd.Parameters.AddWithValue("@projectName", projectName);
            cmd.Parameters.AddWithValue("@taskID", taskID);
           
            cmd.ExecuteNonQuery();

            conn.Close();
            showTimesheetSync();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            showTimesheetSync();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;

            showTimesheetSync();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string mailID = EmployeePanelMaster.email;
            string projectName = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values["Project_Name"]);
            string taskID = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values["Task_ID"]);
            string taskDesciption = (GridView1.Rows[e.RowIndex].FindControl("TextBoxTaskDesc") as TextBox).Text;
            float efforts = float.Parse((GridView1.Rows[e.RowIndex].FindControl("TextBoxEfforts") as TextBox).Text);
            SqlConnection conn = new SqlConnection(HomePage.connectString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateTimesheet", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mail", mailID);
            cmd.Parameters.AddWithValue("@projectName", projectName);
            cmd.Parameters.AddWithValue("@taskID", taskID);
            cmd.Parameters.AddWithValue("@taskDesc", taskDesciption);
            cmd.Parameters.AddWithValue("@efforts", efforts);


            cmd.ExecuteNonQuery();
            conn.Close();
            GridView1.EditIndex = -1;
            showTimesheetSync();
        }
    }
}
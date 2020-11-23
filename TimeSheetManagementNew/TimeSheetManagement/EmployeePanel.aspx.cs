﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeSheetManagement
{
    public partial class EmployeePanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeePanelMaster.email = Request.QueryString["email"];
            if (Session["EmpUserName"] == null)
            {
                Response.Redirect("EmployeeLogin.aspx");
            }
        }
    }
}
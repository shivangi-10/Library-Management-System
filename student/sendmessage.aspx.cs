﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace library_ms.student
{
    public partial class send_message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["student"] == null)
            {
                Response.Redirect("student_login.aspx");
            }
        }
    }
}
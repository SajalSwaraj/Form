﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class FetchData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Fname= FnameTextBox.Text;
            string Lname= LnameTextBox.Text;


                FetchDetails f = new FetchDetails();
                f.GetData(Fname, Lname);
                HttpContext.Current.Response.Write("Success");

        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Derma_Admin_MakePayments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var idSession = Request.QueryString.Get("idSession");
        var idMedication = Request.QueryString.Get("idMedication");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dermatologica.Web;

public partial class Derma_Admin_PrivateInfomation : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var idPerson = Request.QueryString.Get("id");
            if (!string.IsNullOrEmpty(idPerson))
            {
                LoadPrivateInformation(new Guid(idPerson));
            }
        }
    }

    private void LoadPrivateInformation(Guid id)
    {
        
    }
}
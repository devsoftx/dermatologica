using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;

public partial class Derma_Admin_StaffInformation : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var idPerson = Request.QueryString.Get("id");
            if (!string.IsNullOrEmpty(idPerson))
            {
                LoadStaffInformation(new Guid(idPerson));
            }
        }
    }

    private void LoadStaffInformation(Guid? idPerson)
    {
        var employee = BussinessFactory.GetStaffInformationService().Get(idPerson);
        if (employee != null)
        {
            //Update
        }
        else
        {
            //Save
        }
    }
}
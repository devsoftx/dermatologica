using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using CostCenter = Dermatologic.Domain.CostCenter;
using Dermatologic.Domain;
using Dermatologic.Services;
public partial class Derma_Admin_EditCostCenter : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetCostCenter();
        }
    }
    private void SetCostCenter()
    {
        var action = Request.QueryString.Get("action");
        string id = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                break;
            case "edit":
                LoadCostCenter(new Guid(id));
                break;
        }
    }
    void LoadCostCenter(Guid id)
    {
        var response = BussinessFactory.GetCostCenterService().Get(id);
        if (response.OperationResult == OperationResult.Success)
        {
            var costCenter = response.Entity;
            txtName.Text = costCenter.Name;
            txtDescription.Text = costCenter.Description;   
        }
    }

    private void Save()
    {
        var CostCenter = new CostCenter
        {
            Id = Guid.NewGuid(),
            Name = txtName.Text.Trim(),
            Description = txtDescription.Text.Trim(),
            IsActive = true,
            LastModified = LastModified,
            CreationDate = CreationDate,
            ModifiedBy = ModifiedBy,
            CreatedBy = CreatedBy
        };

        try
        {
            var response = BussinessFactory.GetCostCenterService().Save(CostCenter);

            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListCostCenters.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo crear El Centro de Costo");
            }
        }
        catch (Exception e)
        {
            throw e;
        }

    }
    private void Update()
    {
        var Id = Request.QueryString.Get("id");
        var responseCostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(Id));
        if (responseCostCenter.OperationResult == OperationResult.Success)
        {
            var costCenter = responseCostCenter.Entity;
            costCenter.Name = txtName.Text.Trim();
            costCenter.Description = txtDescription.Text.Trim();
            costCenter.LastModified = LastModified;
            costCenter.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetCostCenterService().Update(costCenter);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListCostCenters.aspx", false);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo actualizar el Centro de Costo");
            }
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        var action = Request.QueryString.Get("action");
        switch (action)
        {
            case "new":
                Save();
                break;
            case "edit":
                Update();
                break;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/ListCostCenters.aspx", true);
    }
}
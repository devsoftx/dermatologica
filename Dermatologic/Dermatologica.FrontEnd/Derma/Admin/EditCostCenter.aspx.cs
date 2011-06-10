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
        var CostCenter = BussinessFactory.GetCostCenterService().Get(id);
        txtName.Text = CostCenter.Name;
        txtDescription.Text = CostCenter.Description;
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
        var CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(Id));
        if (CostCenter != null)
        {
            CostCenter.Name = txtName.Text.Trim();
            CostCenter.Description = txtDescription.Text.Trim();
            CostCenter.IsActive = true;
            CostCenter.LastModified = LastModified;
            CostCenter.ModifiedBy = ModifiedBy;

            var response = BussinessFactory.GetCostCenterService().Update(CostCenter);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListCostCenters.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo actualizar el Tipo de Persona");
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
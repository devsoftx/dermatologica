using System;
using ASP.App_Code;
using Dermatologic.Domain;
using Service = Dermatologic.Domain.Service;
using Dermatologic.Services;


public partial class Derma_Admin_EditService : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCostCenter();
            SetService();
           
        }
    }
    private void LoadCostCenter()
    {
        var types = BussinessFactory.GetCostCenterService().GetAll(p => p.IsActive);
        BindControl<CostCenter>.BindDropDownList(ddlCostCenter, types);
    }
    private void SetService()
    {
        var action = Request.QueryString.Get("action");
        string id = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                break;
            case "edit":
                LoadService(new Guid(id));
                break;
        }
    }

    private void LoadService(Guid id)
    {
        var service = BussinessFactory.GetServiceService().Get(id);
        txtName.Text = service.Name;
        txtDescription.Text = service.Description;
        txtPrice.Text = service.Price.ToString();
        ddlCurrency.SelectedValue = service.Currency;
        ddlCostCenter.SelectedValue = service.CostCenter.Name;
    }

    private void Save()
    {
        var Service = new Service
        {
            Id = Guid.NewGuid(),
            Name = txtName.Text.Trim(),
            Description = txtDescription.Text.Trim(),
            Price = Convert.ToDecimal(txtPrice.Text.Trim()),
            Currency = ddlCurrency.SelectedValue,
            IsActive = true,
            LastModified = LastModified,
            CreationDate = CreationDate,
            ModifiedBy = ModifiedBy,
            CreatedBy = CreatedBy,
            CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(ddlCostCenter.SelectedValue))
        };
        //Service.CostCenter = costcenter;
        try
        {
            var response = BussinessFactory.GetServiceService().Save(Service);

            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListServices.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se pudo crear El Servicio");
            }
        }
        catch (Exception e)
        {
            throw e;
        }

    }

    private void Update()
    {
        var id = Request.QueryString.Get("id");
        var service = BussinessFactory.GetServiceService().Get(new Guid(id));
       

        if (service != null)
        {
            service.Name = txtName.Text.Trim();
            service.Description = txtDescription.Text.Trim();
            service.IsActive = true;
            service.LastModified = LastModified;
            service.ModifiedBy = ModifiedBy;
            service.Price = Convert.ToDecimal(txtPrice.Text.Trim());
            service.Currency = ddlCurrency.SelectedValue;
            service.CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(ddlCostCenter.SelectedValue));

            var response = BussinessFactory.GetServiceService().Update(service);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListServices.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo actualizar el tipo de tratamiento");
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
        Response.Redirect("~/Derma/Admin/ListServices.aspx", true);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Medication = Dermatologic.Domain.Medication;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_EditMedication : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadServices();
            SetMedication();
        }
        btnAceptar.Enabled = false;
    }

    private void SetMedication()
    {
        var action = Request.QueryString.Get("action");
        var id = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                Session["personSelected"] = null;
                break;
            case "edit":
                LoadMedication(new Guid(id));
                LoadSessions(new Guid(id));
                break;
        }
    }

    private void LoadServices()
    {
        var services = BussinessFactory.GetServiceService().GetAll().OrderBy(p => p.Name).ToList();
        BindControl<Service>.BindDropDownList(dwService, services);
        txtPrice.Text = services.FirstOrDefault().Price.ToString();
        lblCurrency.Text = services.FirstOrDefault().Currency;
    }

    private void LoadMedication(Guid id)
    {
        var medication = BussinessFactory.GetMedicationService().Get(id);
        txtDescription.Text = medication.Description;
        txtNumberSessions.Text = Convert.ToString(medication.NumberSessions);
        txtPacient.Text = string.Format("{0} {1} {2}", medication.Patient.FirstName, medication.Patient.LastNameP, medication.Patient.LastNameM);
        lblCurrency.Text = medication.Service.Currency;
        txtPriceT.Text = medication.Price.ToString();
        txtDiscountT.Text = medication.DiscountT.ToString();
        txtDni.Value = medication.Patient.DocumentNumber;
        if (medication.Service.Id.HasValue)
        {
            dwService.SelectedValue = medication.Service.Id.Value.ToString();
            txtPrice.Text = medication.Service.Price.ToString();
        }
    }

    private void Save()
    {
        var patientResponse = BussinessFactory.GetPersonService().GetPersonByDni(txtDni.Value.Trim());
        var patient = patientResponse.Person;
        var medication = new Medication
                             {
                                 Id = Guid.NewGuid(),
                                 Description = txtDescription.Text.Trim(),
                                 NumberSessions = Convert.ToInt32(txtNumberSessions.Text.Trim()),
                                 Currency=lblCurrency.Text,
                                 Price = Convert.ToDecimal(txtPriceT.Text),
                                 DiscountT = Convert.ToDecimal(txtDiscountT.Text),
                                 IsCompleted = false,
                                 Unpaid=chkUnpaid.Checked,
                                 IsActive = true,
                                 LastModified = LastModified,
                                 CreationDate = CreationDate,
                                 ModifiedBy = ModifiedBy,
                                 CreatedBy = CreatedBy,
                                 Patient = patient,
                                 Service = BussinessFactory.GetServiceService().Get(new Guid(dwService.SelectedValue))
                             };
        try
        {
            foreach (GridViewRow row in gvSessions.Rows)
            {
                if (((CheckBox)row.FindControl("chkIsPaid")).Checked == false)
                { 

                }
                var session = new Session
                                  {
                                      RowId = Convert.ToInt32(row.Cells[0].Text),
                                      Id = new Guid(gvSessions.DataKeys[row.RowIndex][0].ToString()),
                                      Currency = lblCurrency.Text.Trim().ToUpper(),
                                      Price = Convert.ToDecimal(row.Cells[2].Text),
                                      Account = Convert.ToDecimal(row.Cells[3].Text),
                                      Residue = Convert.ToDecimal(row.Cells[4].Text),
                                      IsCompleted = ((CheckBox) row.FindControl("chkIsCompleted")).Checked,
                                      Unpaid = ((CheckBox) row.FindControl("chkUnpaid")).Checked,
                                      IsPaid = ((CheckBox) row.FindControl("chkIsPaid")).Checked,
                                      IsActive = true,
                                      LastModified = LastModified,
                                      CreatedBy = CreatedBy,
                                      CreationDate = CreationDate,
                                      ModifiedBy = ModifiedBy,
                                      Medication = medication
                                  };
                medication.Sessions.Add(session);
            }
            var response = BussinessFactory.GetMedicationService().Save(medication);

            if (response.OperationResult == OperationResult.Success)
            {   
                Response.Redirect("~/Derma/Admin/ListMedications.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se pudo crear El tratamiento");
            }
        }
        catch (Exception e)
        {
            litMensaje.Text = string.Format("Error: No se puedo crear El tratamiento {0}", e.Message);
            throw e;
        }

    }

    private void Update()
    {
        var Id = Request.QueryString.Get("id");
        var Medication = BussinessFactory.GetMedicationService().Get(new Guid(Id));
        if (Medication != null)
        {
            Medication.Description = txtDescription.Text.Trim();
            Medication.NumberSessions = Convert.ToInt32(txtNumberSessions.Text.Trim());
            Medication.IsActive = true;
            Medication.LastModified = LastModified;
            Medication.ModifiedBy = ModifiedBy;

            Medication.Service = BussinessFactory.GetServiceService().Get(new Guid(dwService.SelectedValue));

            var response = BussinessFactory.GetMedicationService().Update(Medication);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListMedications.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo actualizar el tratamiento");
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
        Response.Redirect("~/Derma/Admin/ListMedications.aspx", true);
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        const string javascript = "openRadWindow('SearchPersons.aspx?personType=9B64DDB9-1C00-4A8B-99E5-FDCD96B3FF68','rw1');";
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "OpenSearchPersons", javascript, true);
    }

    protected void btnDoPostBack_Click(object sender, EventArgs e)
    {
        var id = Session["personSelected"];
        var response = BussinessFactory.GetPersonService().Get(new Guid(id.ToString()));
        txtPacient.Text = string.Format("{0} {1} {2}", response.FirstName,response.LastNameP, response.LastNameM);
        txtDni.Value = response.DocumentNumber;
    }

    protected void btnAddSessions_Click(object sender, EventArgs e)
    {
        var intSession = Convert.ToInt32(txtNumberSessions.Value);
        if (txtDiscountT.Text == "")
        {
            txtDiscountT.Text = "0";
        }
        var discount = Convert.ToDecimal(txtDiscountT.Text.Trim());
        decimal priceService = chkUnpaid.Checked == true ? 0 : Convert.ToDecimal(txtPrice.Text.Trim());
        decimal price = ((priceService * intSession) - discount);
        IList<Session> sessions = new List<Session>();
        for (var i = 0; i < intSession; i++)
        {
            var session = new Session
                              {
                                  RowId = i + 1,
                                  Id = Guid.NewGuid(),
                                  Currency = lblCurrency.Text.Trim().ToUpper(),
                                  Price = price / intSession,
                                  Residue = price / intSession,
                                  IsCompleted = false,
                                  Unpaid = false,
                                  IsPaid = false,
                                  IsActive = true,
                                  LastModified = LastModified,
                                  CreatedBy = CreatedBy,
                                  CreationDate = CreationDate,
                                  ModifiedBy = ModifiedBy
                              };
            if (chkUnpaid.Checked == true)
            {
                session.Unpaid = true;
            }
            sessions.Add(session);
        }
        txtPriceT.Text = price.ToString();
        btnAceptar.Enabled = true;
        BindControl<Session>.BindGrid(gvSessions,sessions);
    }

    private void LoadSessions(Guid medicationId)
    {
        var session = new Session {Medication = {Id = medicationId}};
        var response = BussinessFactory.GetSessionService().GetSessionByMedication(session);
        if (response.OperationResult == OperationResult.Success)
        {
            BindControl<Session>.BindGrid(gvSessions, response.Sessions);
        }
    }

    protected void gvSessions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("EditSession.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_eliminar":
                Delete(new Guid(e.CommandArgument.ToString()));
                LoadMedication(new Guid(Request.QueryString.Get("id")));
                break;
        }
    }

    private void Delete(Guid id)
    {
        var session = BussinessFactory.GetSessionService().Get(id);
        if (session != null)
        {
            session.IsActive = false;
            session.LastModified = LastModified;
            session.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetSessionService().Update(session);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó la sessión: {0}", session.Description);
                return;
            }
        }
    }

    protected void dwService_SelectedIndexChanged(object sender, EventArgs e)
    {
        var service = BussinessFactory.GetServiceService().Get(new Guid(dwService.SelectedValue));
        txtPrice.Value = Convert.ToDouble(service.Price);
        lblCurrency.Text = service.Currency;
    }
}
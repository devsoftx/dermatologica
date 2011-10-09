using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_ListAppoiments : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetAppointments();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        var example = new Appointment
                          {
                              Medical =
                                  {
                                      FirstName = txtSearch.Text.Trim(),
                                      LastNameP = txtSearch.Text.Trim(),
                                      LastNameM = txtSearch.Text.Trim()
                                  }
                          };
        if (!string.IsNullOrEmpty(txtDate.Text))
        {
            var date = Convert.ToDateTime(txtDate.Text);
            example.StartDate = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0);
        }
        else
        {
            example.StartDate = null;
        }
        var response = BussinessFactory.GetAppointmentService().GetByOpMedical(example);
        if (response.OperationResult == OperationResult.Success)
        {
            var appointments = response.Appointments;
            BindControl<Appointment>.BindGrid(gvAppointments, appointments);
        }
    }

    protected void gvAppointments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "Page")
        {
            switch (e.CommandName)
            {
                case "cmd_editar":
                    var id = new Guid(e.CommandArgument.ToString());
                    Response.Redirect(string.Format("~/Derma/Appointment.aspx?id={0}&action=edit&returnUrl={1}", id, Request.RawUrl), true);
                    break;
                case "cmd_eliminar":
                    DeleteAppointment(new Guid(e.CommandArgument.ToString()));
                    GetAppointments();
                    break;
            }   
        }
    }

    private void GetAppointments()
    {
        var response = BussinessFactory.GetAppointmentService().GetAll(u => u.IsActive);
        if(response.OperationResult == OperationResult.Success)
        {
            var appointments = response.Results.OrderBy(p => p.LastModified).ToList();
            BindControl<Appointment>.BindGrid(gvAppointments, appointments);   
        }
    }

    private void DeleteAppointment(Guid id)
    {
        var responseAppointment = BussinessFactory.GetAppointmentService().Get(id);
        if (responseAppointment.OperationResult == OperationResult.Success)
        {
            var appointment = responseAppointment.Entity;
            appointment.IsActive = false;
            appointment.LastModified = LastModified;
            appointment.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetAppointmentService().Update(appointment);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó la cita del Sr. {0} con Dr(a).: {1}", appointment.Patient ,appointment.Medical.CompleteName);
                return;
            }
        }
    }


    protected void gvAppointments_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            ResponseBase<Appointment> response;
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                response = BussinessFactory.GetAppointmentService().GetAll(p => p.IsActive);
            }
            else
            {
                var example = new Appointment
                {
                    Medical =
                    {
                        FirstName = txtSearch.Text.Trim(),
                        LastNameP = txtSearch.Text.Trim(),
                        LastNameM = txtSearch.Text.Trim()
                    }
                };
                if (!string.IsNullOrEmpty(txtDate.Text))
                {
                    var date = Convert.ToDateTime(txtDate.Text);
                    example.StartDate = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0);
                }
                else
                {
                    example.StartDate = null;
                }
                response = BussinessFactory.GetAppointmentService().GetByOpMedical(example);
            }
            if (response.OperationResult == OperationResult.Success)
            {
                var persons = response.Results;
                gvAppointments.DataSource = persons;
                gvAppointments.PageIndex = e.NewPageIndex;
                gvAppointments.DataBind();
            }
        }
        catch (Exception ex)
        {
            litMensaje.Text = string.Format("Error: {0}", ex.Message);
        }
    }
}
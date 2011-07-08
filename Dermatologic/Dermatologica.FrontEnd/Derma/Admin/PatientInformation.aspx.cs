using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_PatientInformation : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var idPerson = Request.QueryString.Get("id");
            if (!string.IsNullOrEmpty(idPerson))
            {
                LoadPatientInformation(new Guid(idPerson));
            }
        }
    }

    private void LoadPatientInformation(Guid? idPerson)
    {
        var entity = BussinessFactory.GetPatientInformationService().Get(idPerson);
        if (entity != null)
        {
            entity.HaveHerpesLabial = HaveHerpesLabial.Checked;
            entity.DateHerpesLabial = !string.IsNullOrEmpty(txtDateHerpesLabial.Text)
                                          ? Convert.ToDateTime(txtDateHerpesLabial.Text)
                                          : (DateTime?) null;
            entity.IsUseMarcapaso = IsUseMarcapaso.Checked;
            entity.DateUseMarcapaso = !string.IsNullOrEmpty(txtDateUseMarcapaso.Text)
                                          ? Convert.ToDateTime(txtDateUseMarcapaso.Text)
                                          : (DateTime?) null;
            entity.HaveVerrugas = HaveVerrugas.Checked;
            entity.DateVerrugas = !string.IsNullOrEmpty(txtDateVerrugas.Text)
                                      ? Convert.ToDateTime(txtDateVerrugas.Text)
                                      : (DateTime?) null;
            entity.HaveHepatitisB = HaveHepatitisB.Checked;
            entity.DateHepatitisB = !string.IsNullOrEmpty(txtDateHepatitisB.Text)
                                        ? Convert.ToDateTime(txtDateHepatitisB.Text)
                                        : (DateTime?) null;
            entity.HaveDiabetes = HaveDiabetes.Checked;
            entity.DateDiabetes = !string.IsNullOrEmpty(txtDateDiabetes.Text)
                                      ? Convert.ToDateTime(txtDateDiabetes.Text)
                                      : (DateTime?) null;
            entity.HaveDermatitisAtopica = HaveDermatitisAtopica.Checked;
            entity.DateDermatitisAtopica = !string.IsNullOrEmpty(txtDateDermatitisAtopica.Text)
                                               ? Convert.ToDateTime(txtDateDermatitisAtopica.Text)
                                               : (DateTime?) null;
            entity.HaveHipotiroidismo = HaveHipotiroidismo.Checked;
            entity.DateHipotiroidismo = !string.IsNullOrEmpty(txtDateHipotiroidismo.Text)
                                            ? Convert.ToDateTime(txtDateHipotiroidismo.Text)
                                            : (DateTime?) null;
            entity.CommentsAntecedentesEnfermedades = txtComentariosAntecedentesEnfermedades.Text.Trim();
            entity.HaveWarfarina = HaveWarfarina.Checked;
            entity.HaveAntibioticosAcne = HaveAntibioticosAcne.Checked;
            entity.HaveRoaccuatan = HaveRoaccuatan.Checked;
            entity.HaveIsotretinoina = HaveIsotretinoina.Checked;
            entity.HaveAspirinas = HaveAspirinas.Checked;
            entity.HaveVitaminas = HaveVitaminas.Checked;
            entity.CommentsMedicacionHabitual = txtComentariosMedicacionHabitual.Text.Trim();
            entity.HaveAlergiaAnestesicosHabituales = HaveAlergiaAnestesicosHabituales.Checked;
            var response = BussinessFactory.GetPatientInformationService().Update(entity);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListPatients.aspx", true);
            }
            else
            {
                litMensajes.Text = string.Format("No se puedo guardar -> Error : {0}", response.Message);
            }
        }
        else
        {
            var info = new PatientInformation
                           {
                               Id = Guid.NewGuid(),
                               HaveHerpesLabial = HaveHerpesLabial.Checked,
                               DateHerpesLabial = !string.IsNullOrEmpty(txtDateHerpesLabial.Text) ? Convert.ToDateTime(txtDateHerpesLabial.Text) : (DateTime?)null,
                               IsUseMarcapaso = IsUseMarcapaso.Checked,
                               DateUseMarcapaso = !string.IsNullOrEmpty(txtDateUseMarcapaso.Text) ? Convert.ToDateTime(txtDateUseMarcapaso.Text) : (DateTime?)null,
                               HaveVerrugas = HaveVerrugas.Checked,
                               DateVerrugas = !string.IsNullOrEmpty(txtDateVerrugas.Text) ? Convert.ToDateTime(txtDateVerrugas.Text) : (DateTime?)null,
                               HaveHepatitisB = HaveHepatitisB.Checked,
                               DateHepatitisB = !string.IsNullOrEmpty(txtDateHepatitisB.Text)? Convert.ToDateTime(txtDateHepatitisB.Text) : (DateTime?)null,
                               HaveDiabetes = HaveDiabetes.Checked,
                               DateDiabetes = !string.IsNullOrEmpty(txtDateDiabetes.Text) ? Convert.ToDateTime(txtDateDiabetes.Text):(DateTime?)null,                           
                               HaveDermatitisAtopica = HaveDermatitisAtopica.Checked,
                               DateDermatitisAtopica = !string.IsNullOrEmpty(txtDateDermatitisAtopica.Text) ? Convert.ToDateTime(txtDateDermatitisAtopica.Text) : (DateTime?)null,
                               HaveHipotiroidismo = HaveHipotiroidismo.Checked,
                               DateHipotiroidismo = !string.IsNullOrEmpty(txtDateHipotiroidismo.Text) ? Convert.ToDateTime(txtDateHipotiroidismo.Text) : (DateTime?)null,
                               CommentsAntecedentesEnfermedades = txtComentariosAntecedentesEnfermedades.Text.Trim(),
                               HaveWarfarina = HaveWarfarina.Checked,
                               HaveAntibioticosAcne = HaveAntibioticosAcne.Checked,
                               HaveRoaccuatan = HaveRoaccuatan.Checked,
                               HaveIsotretinoina = HaveIsotretinoina.Checked,
                               HaveAspirinas = HaveAspirinas.Checked,
                               HaveVitaminas = HaveVitaminas.Checked,
                               CommentsMedicacionHabitual = txtComentariosMedicacionHabitual.Text.Trim(),
                               HaveAlergiaAnestesicosHabituales = HaveAlergiaAnestesicosHabituales.Checked,

                           };
            var response = BussinessFactory.GetPatientInformationService().Save(info);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListPatients.aspx", true);
            }
            else
            {
                litMensajes.Text = string.Format("No se puedo guardar -> Error : {0}", response.Message);
            }
        }
    }
}
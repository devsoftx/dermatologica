using System;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
//using Invoice = Dermatologic.Domain.Invoice;
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
            HaveHerpesLabial.Checked = Convert.ToBoolean(entity.HaveHerpesLabial);
            txtDateHerpesLabial.Text = entity.DateHerpesLabial.HasValue ? Convert.ToString(entity.DateHerpesLabial.Value.ToShortDateString()) : null;
            IsUseMarcapaso.Checked = Convert.ToBoolean(entity.IsUseMarcapaso);
            txtDateUseMarcapaso.Text = entity.DateUseMarcapaso.HasValue ? Convert.ToString(entity.DateUseMarcapaso.Value.ToShortDateString()) : null;
            HaveVerrugas.Checked = Convert.ToBoolean(entity.HaveVerrugas);
            txtDateVerrugas.Text = entity.DateVerrugas.HasValue ? Convert.ToString(entity.DateVerrugas.Value.ToShortDateString()) : null;
            HaveHepatitisB.Checked = Convert.ToBoolean(entity.HaveHepatitisB);
            txtDateHepatitisB.Text = entity.DateHepatitisB.HasValue ? Convert.ToString(entity.DateHepatitisB.Value.ToShortDateString()) : null;
            HaveDiabetes.Checked = Convert.ToBoolean(entity.HaveDiabetes);
            txtDateDiabetes.Text = entity.DateDiabetes.HasValue ? Convert.ToString(entity.DateDiabetes.Value.ToShortDateString()) : null;
            HaveDermatitisAtopica.Checked = Convert.ToBoolean(entity.HaveDermatitisAtopica);
            txtDateDermatitisAtopica.Text = entity.DateDermatitisAtopica.HasValue ? Convert.ToString(entity.DateDermatitisAtopica.Value.ToShortDateString()) : null;
            HaveHipotiroidismo.Checked = Convert.ToBoolean(entity.HaveHipotiroidismo);
            txtDateHipotiroidismo.Text = entity.DateHipotiroidismo.HasValue ? Convert.ToString(entity.DateHipotiroidismo.Value.ToShortDateString()) : null;
            txtComentariosAntecedentesEnfermedades.Text = txtComentariosAntecedentesEnfermedades.Text;
            HaveWarfarina.Checked = Convert.ToBoolean(entity.HaveWarfarina);
            HaveAntibioticosAcne.Checked = Convert.ToBoolean(entity.HaveAntibioticosAcne);
            HaveRoaccuatan.Checked = Convert.ToBoolean(entity.HaveRoaccuatan);
            HaveIsotretinoina.Checked = Convert.ToBoolean(entity.HaveIsotretinoina);
            HaveAspirinas.Checked = Convert.ToBoolean(entity.HaveAspirinas);
            HaveVitaminas.Checked = Convert.ToBoolean(entity.HaveVitaminas);
            txtComentariosMedicacionHabitual.Text= entity.CommentsMedicacionHabitual;
            HaveAlergiaAnestesicosHabituales.Checked=Convert.ToBoolean(entity.HaveAlergiaAnestesicosHabituales);
            HaveAlergiaAspirinas.Checked = Convert.ToBoolean(entity.HaveAlergiaAspirinas);
            HaveAlergiaCorticoides.Checked = Convert.ToBoolean(entity.HaveAlergiaCorticoides);
            HaveAlergiaAsma.Checked = Convert.ToBoolean(entity.HaveAlergiaAsma);
            HaveAlergiaRinitis.Checked = Convert.ToBoolean(entity.HaveAlergiaRinitis);
            txtComentariosAntecedentesAlergias.Text = entity.CommentsAntecedentesAlergias;
            HaveLifting.Checked = Convert.ToBoolean(entity.HaveLifting);
            HaveBotox.Checked = Convert.ToBoolean(entity.HaveBotox);
            HaveRellenos.Checked = Convert.ToBoolean(entity.HaveRellenos);
            HaveLaser.Checked = Convert.ToBoolean(entity.HaveLaser);
            txtComentariosTratamientos.Text = entity.CommentsTratamientosCirugiasActAnt;
            IsFumador.Checked = Convert.ToBoolean(entity.IsFumador);
            IsHabitoBronceadoSoloVer.Checked = Convert.ToBoolean(entity.IsHabitoBronceadoSoloVer);
            IsHabitoBronceadoTodoAno.Checked = Convert.ToBoolean(entity.IsHabitoBronceadoTodoAno);
            IsHabitoEvitoBroncearme.Checked = Convert.ToBoolean(entity.IsHabitoEvitoBroncearme);
            HaveCicatricesQueloides.Checked = Convert.ToBoolean(entity.HaveCicatricesQueloides);     
            txtAreaQueloides.Text= entity.AreaCicatricesQueloides;
            IsDepilacion.Checked = Convert.ToBoolean(entity.IsDepilacion);
            txtAreaDepilacion.Text=entity.AreaDepilacion;
            txtMetodoDepilacion.Text = entity.MetodoDepilacion;
            IsEmbarazada.Checked = Convert.ToBoolean(entity.IsEmbarazada);
            txtDateLastRegla.Text = entity.DateLastRegla.HasValue ? Convert.ToString(entity.DateLastRegla.Value.ToShortDateString()) : null;
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        Save();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/ListPatients.aspx", true);
    }

    private void Save()
    {
        var idPerson = Request.QueryString.Get("id");
        var entity = BussinessFactory.GetPatientInformationService().Get(new Guid(idPerson));
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
            entity. HaveAlergiaAspirinas = HaveAlergiaAspirinas.Checked;              
            entity.HaveAlergiaCorticoides = HaveAlergiaCorticoides.Checked;
            entity.HaveAlergiaAsma = HaveAlergiaAsma.Checked;
            entity.HaveAlergiaRinitis=HaveAlergiaRinitis.Checked;
            entity.CommentsAntecedentesAlergias=txtComentariosAntecedentesAlergias.Text.Trim();
            entity.HaveLifting = HaveLifting.Checked;
            entity.HaveBotox = HaveBotox.Checked;
            entity.HaveRellenos = HaveRellenos.Checked;
            entity.HaveLaser=HaveLaser.Checked;
            entity.CommentsTratamientosCirugiasActAnt=txtComentariosTratamientos.Text.Trim();
            entity.IsFumador=IsFumador.Checked;
            entity.IsHabitoBronceadoSoloVer=IsHabitoBronceadoSoloVer.Checked;
            entity.IsHabitoBronceadoTodoAno = IsHabitoBronceadoTodoAno.Checked;
            entity.IsHabitoEvitoBroncearme = IsHabitoEvitoBroncearme.Checked;
            entity.HaveCicatricesQueloides=HaveCicatricesQueloides.Checked;
            entity.AreaCicatricesQueloides=txtAreaQueloides.Text.Trim();
            entity.IsDepilacion=IsDepilacion.Checked;
            entity.AreaDepilacion=txtAreaDepilacion.Text.Trim();
            entity.MetodoDepilacion=txtMetodoDepilacion.Text.Trim();
            entity.IsEmbarazada=IsEmbarazada.Checked;
            entity.DateLastRegla = !string.IsNullOrEmpty(txtDateLastRegla.Text) ? Convert.ToDateTime(txtDateLastRegla.Text) : (DateTime?)null;



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
                               Id =new Guid(idPerson),
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
                               HaveAlergiaAspirinas = HaveAlergiaAspirinas.Checked,
                               HaveAlergiaCorticoides = HaveAlergiaCorticoides.Checked,
                               HaveAlergiaAsma = HaveAlergiaAsma.Checked,
                               HaveAlergiaRinitis=HaveAlergiaRinitis.Checked,
                               CommentsAntecedentesAlergias=txtComentariosAntecedentesAlergias.Text.Trim(),
                               HaveLifting = HaveLifting.Checked,
                               HaveBotox = HaveBotox.Checked,
                               HaveRellenos = HaveRellenos.Checked,
                               HaveLaser=HaveLaser.Checked,
                               CommentsTratamientosCirugiasActAnt=txtComentariosTratamientos.Text.Trim(),
                               IsFumador=IsFumador.Checked,
                               IsHabitoBronceadoSoloVer=IsHabitoBronceadoSoloVer.Checked,
                               IsHabitoBronceadoTodoAno = IsHabitoBronceadoTodoAno.Checked,
                               IsHabitoEvitoBroncearme = IsHabitoEvitoBroncearme.Checked,
                               HaveCicatricesQueloides=HaveCicatricesQueloides.Checked,
                               AreaCicatricesQueloides=txtAreaQueloides.Text.Trim(),
                               IsDepilacion=IsDepilacion.Checked,
                               AreaDepilacion=txtAreaDepilacion.Text.Trim(),
                               MetodoDepilacion=txtMetodoDepilacion.Text.Trim(),
                               IsEmbarazada=IsEmbarazada.Checked,
                               DateLastRegla = !string.IsNullOrEmpty(txtDateLastRegla.Text) ? Convert.ToDateTime(txtDateLastRegla.Text) : (DateTime?)null,

                               IsActive = true,
                               LastModified = LastModified,
                               CreationDate = CreationDate,
                               ModifiedBy = ModifiedBy,
                               CreatedBy = CreatedBy
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
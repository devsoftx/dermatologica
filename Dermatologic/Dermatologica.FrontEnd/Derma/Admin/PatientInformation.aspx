<%@ Page Title="" Language="C#" MasterPageFile="~/Derma/Derma.master" AutoEventWireup="true"
    CodeFile="PatientInformation.aspx.cs" Inherits="Derma_Admin_PatientInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtDateHerpesLabial").datepicker();
            $("#MainContent_txtDateHerpesLabial").datepicker($.datepicker.regional['es']);
            $("#MainContent_txtDateMarcapaso").datepicker();
            $("#MainContent_txtDateMarcapaso").datepicker($.datepicker.regional['es']);
            $("#MainContent_txtDateVerrugas").datepicker();
            $("#MainContent_txtDateVerrugas").datepicker($.datepicker.regional['es']);
            $("#MainContent_txtDateHepatitisB").datepicker();
            $("#MainContent_txtDateHepatitisB").datepicker($.datepicker.regional['es']);
            $("#MainContent_txtDateDiabetes").datepicker();
            $("#MainContent_txtDateDiabetes").datepicker($.datepicker.regional['es']);
            $("#MainContent_txtDateDermatitisAtopica").datepicker();
            $("#MainContent_txtDateDermatitisAtopica").datepicker($.datepicker.regional['es']);
            $("#MainContent_txtDateHipotiroidismo").datepicker();
            $("#MainContent_txtDateHipotiroidismo").datepicker($.datepicker.regional['es']);
            $("#MainContent_txtDateLastRegla").datepicker();
            $("#MainContent_txtDateLastRegla").datepicker($.datepicker.regional['es']);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="Main">
        <table width="800px">
            <tr>
                <td colspan="2">
                    <asp:Literal runat="server" ID="litMensajes" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Enfermedades:
                </td>
            </tr>
            <tr>
                <td>
                    Enfermedad
                </td>
                <td>
                    Fecha
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveHerpesLabial" runat="server" Text="Herpes Labial" />
                </td>
                <td>
                    <asp:TextBox ID="txtDateHerpesLabial" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="IsUseMarcapaso" runat="server" Text="Usa Marcapaso" />
                </td>
                <td>
                    <asp:TextBox ID="txtDateUseMarcapaso" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveVerrugas" runat="server" Text="Verrugas" />
                </td>
                <td>
                    <asp:TextBox ID="txtDateVerrugas" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveHepatitisB" runat="server" Text="Hepatitis B" />
                </td>
                <td>
                    <asp:TextBox ID="txtDateHepatitisB" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveDiabetes" runat="server" Text="Diabetes" />
                </td>
                <td>
                    <asp:TextBox ID="txtDateDiabetes" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveDermatitisAtopica" runat="server" Text="Dermatitis Atópica" />
                </td>
                <td>
                    <asp:TextBox ID="txtDateDermatitisAtopica" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveHipotiroidismo" runat="server" Text="Hipotiroidismo" />
                </td>
                <td>
                    <asp:TextBox ID="txtDateHipotiroidismo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Comentarios:
                </td>
                <td>
                    <asp:TextBox ID="txtComentariosAntecedentesEnfermedades" runat="server" Rows="3"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Medicinas:
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveWarfarina" runat="server" Text="Warfarina" />
                </td>
                <td>
                    <asp:CheckBox ID="HaveVitaminas" runat="server" Text="Vitaminas" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveAntibioticosAcne" runat="server" 
                        Text="Antibioticos Acne" />
                </td>
                <td>
                    <asp:CheckBox ID="HaveAspirinas" runat="server" Text="Aspirinas" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveRoaccuatan" runat="server" Text="Roaccuatan" />
                </td>
                <td>
                    <asp:CheckBox ID="HaveIsotretinoina" runat="server" Text="Isotretinoina" />
                </td>
            </tr>
            <tr>
                <td>
                    Comentarios:
                </td>
                <td>
                    <asp:TextBox ID="txtComentariosMedicacionHabitual" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Alergias:
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveAlergiaAnestesicosHabituales" runat="server" 
                        Text="Alergia Analgesicos" />
                </td>
                <td>
                    <asp:CheckBox ID="Label17" runat="server" Text="Alergia Med. Asma" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="Label15" runat="server" Text="Alergia Aspirinas" />
                </td>
                <td>
                    <asp:CheckBox ID="Label18" runat="server" Text="Alergia Med. Rinitis" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="Label16" runat="server" Text="Alergia Corticoides" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Comentarios:
                </td>
                <td>
                    <asp:TextBox ID="txtComentariosAntecedentesAlergias" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Tratamientos:
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveListing" runat="server" Text="Lifting" />
                </td>
                <td>
                    <asp:CheckBox ID="HaveRellenos" runat="server" Text="Rellenos" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveBotox" runat="server" Text="Botox" />
                </td>
                <td>
                    <asp:CheckBox ID="HaveLaser" runat="server" Text="Laser" />
                </td>
            </tr>
            <tr>
                <td>
                    Comentarios:
                </td>
                <td>
                    <asp:TextBox ID="txtComentariosTratamientos" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Habitos:
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="IsFumador" runat="server" Text="Es Fumador" />
                </td>
                <td>
                    <asp:CheckBox ID="IsHabitoBronceadoTodoAno" runat="server" Text="Bronceado todo el año" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="IsHabitoBronceadoSoloVer" runat="server" Text="Bronceado en verano" />
                </td>
                <td>
                    <asp:CheckBox ID="IsHabitoEvitoBroncearme" runat="server" Text="Evito Broncearme" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="HaveCicatricesQueloides" runat="server" Text="Queloides" />
                </td>
                <td>
                    <asp:TextBox ID="txtAreaQueloides" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="IsDepilacion" runat="server" Text="Depilacion" />
                </td>
                <td>
                    <asp:TextBox ID="txtAreaDepilacion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtMetodoDepilacion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="IsEmbarazada" runat="server" Text="Embarazada" />
                </td>
                <td>
                    <asp:TextBox ID="txtDateLastRegla" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainFooter" runat="Server">
</asp:Content>

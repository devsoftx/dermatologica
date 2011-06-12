using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class PatientInformation : IEquatable<PatientInformation>
    {
        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual bool? HaveHerpesLabial{ set; get;}

        [DataMember]
        public virtual DateTime? DateHerpesLabial{ set; get;}

        [DataMember]
        public virtual bool? IsUseMarcapaso{ set; get;}

        [DataMember]
        public virtual DateTime? DateUseMarcapaso{ set; get;}

        [DataMember]
        public virtual bool? HaveVerrugas{ set; get;}

        [DataMember]
        public virtual DateTime? DateVerrugas{ set; get;}

        [DataMember]
        public virtual bool? HaveHepatitisB{ set; get;}

        [DataMember]
        public virtual DateTime? DateHepatitisB{ set; get;}

        [DataMember]
        public virtual bool? HaveDiabetes{ set; get;}

        [DataMember]
        public virtual DateTime? DateDiabetes{ set; get;}

        [DataMember]
        public virtual bool? HaveDermatitisAtopica{ set; get;}

        [DataMember]
        public virtual DateTime?DateDermatitisAtopica{ set; get;}

        [DataMember]
        public virtual bool? HaveHipotiroidismo{ set; get;}

        [DataMember]
        public virtual DateTime?DateHipotiroidismo{ set; get;}

        [DataMember]
        public virtual string CommentsAntecedentesEnfermedades{ set; get;}

        [DataMember]
        public virtual bool? HaveWarfarina{ set; get;}

        [DataMember]
        public virtual bool? HaveAntibioticosAcne{ set; get;}

        [DataMember]
        public virtual bool? HaveRoaccuatan{ set; get;}

        [DataMember]
        public virtual bool? HaveIsotretinoina{ set; get;}

        [DataMember]
        public virtual bool? HaveVitaminas{ set; get;}

        [DataMember]
        public virtual bool? HaveAspirinas{ set; get;}

        [DataMember]
        public virtual string CommentsMedicacionHabitual{ set; get;}

        [DataMember]
        public virtual bool? HaveAlergiaAnestesicosHabituales{ set; get;}

        [DataMember]
        public virtual bool? HaveAlergiaAspirinas{ set; get;}

        [DataMember]
        public virtual bool? HaveAlergiaCorticoides{ set; get;}

        [DataMember]
        public virtual bool? HaveAlergiaAsma{ set; get;}

        [DataMember]
        public virtual bool? HaveAlergiaRinitis{ set; get;}

        [DataMember]
        public virtual string CommentsAntecedentesAlergias{ set; get;}

        [DataMember]
        public virtual bool? HaveLifting{ set; get;}

        [DataMember]
        public virtual bool? HaveRellenos{ set; get;}

        [DataMember]
        public virtual bool? HaveBotox{ set; get;}

        [DataMember]
        public virtual bool? HaveLaser{ set; get;}

        [DataMember]
        public virtual string CommentsTratamientosCirugiasActAnt{ set; get;}

        [DataMember]
        public virtual bool? IsFumador{ set; get;}

        [DataMember]
        public virtual bool? IsHabitoBronceadoTodoAno{ set; get;}

        [DataMember]
        public virtual bool? IsHabitoBronceadoSoloVer{ set; get;}

        [DataMember]
        public virtual bool? IsHabitoEvitoBroncearme{ set; get;}

        [DataMember]
        public virtual bool? HaveCicatricesQueloides{ set; get;}

        [DataMember]
        public virtual string AreaCicatricesQueloides{ set; get;}

        [DataMember]
        public virtual bool? IsDepilacion{ set; get;}

        [DataMember]
        public virtual string AreaDepilacion{ set; get;}

        [DataMember]
        public virtual string MetodoDepilacion{ set; get;}

        [DataMember]
        public virtual bool? IsEmbarazada{ set; get;}

        [DataMember]
        public virtual DateTime?  DateLastRegla { set; get; }

        [DataMember]
        public virtual bool IsActive { set; get; }

        [DataMember]
        public virtual DateTime? CreationDate { set; get; }

        [DataMember]
        public virtual DateTime? LastModified { set; get; }

        [DataMember]
        public virtual Guid? CreatedBy { set; get; }

        [DataMember]
        public virtual Guid? ModifiedBy { set; get; }

        public virtual bool Equals(PatientInformation other)
        {
            return Id.Equals(other.Id);
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class MedicalCare : IEquatable<MedicalCare>
    {
        private Session _session ;
        private Person _medical ;
        private Person _pacient;
        private Person _partner;
        private Rate _rate;
        
        public MedicalCare()
        {
            _session = new Session();
            _medical = new Person();
             _pacient = new Person();
             _partner = new Person();
             _rate = new Rate();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

        [DataMember]
        public virtual DateTime? DateAttention { set; get; }

        [DataMember]
        public virtual bool IsPaid { set; get; }

        [DataMember]
        public virtual bool IsPaidPartner { set; get; }
        
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

        [DataMember]
        public virtual Session Session
        {
            get { return _session; }
            set { _session = value; }
        }

        [DataMember]
        public virtual Person Medical
        {
            get { return _medical; }
            set { _medical = value; }
        }

        [DataMember]
        public virtual Person Pacient
        {
            get { return _pacient; }
            set { _pacient = value; }
        }

        [DataMember]
        public virtual Person Partner
        {
            get { return _partner; }
            set { _partner = value; }
        }
        public virtual Rate Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

        public virtual bool Equals(MedicalCare other)
        {
            return Id.Equals(other.Id);
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class MedicalCare : IEquatable<MedicalCare>
    {
        private Session _session = new Session();
        private Person _medical = new Person();
        private Person _pacient = new Person();

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

        [DataMember]
        public virtual DateTime? DateAttention { set; get; }

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

        public virtual bool Equals(MedicalCare other)
        {
            return Id.Equals(other.Id);
        }
    }
}
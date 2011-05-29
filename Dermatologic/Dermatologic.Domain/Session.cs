using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Session : IEquatable<Session>
    {
        private Medication _medication;

        public Session()
        {
            _medication = new Medication();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

        [DataMember]
        public virtual string Currency { set; get; }

        [DataMember]
        public virtual decimal Price { set; get; }

        [DataMember]
        public virtual decimal Account { set; get; }

        [DataMember]
        public virtual decimal Residue { set; get; }

        [DataMember]
        public virtual Medication Medication
        {
            get { return _medication; }
            set { _medication = value; }
        }

        [DataMember]
        public virtual bool IsCompleted { set; get; }

        [DataMember]
        public virtual bool IsPaid { set; get; }

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

        public virtual bool Equals(Session other)
        {
            return Id.Equals(other.Id);
        }
    }
}
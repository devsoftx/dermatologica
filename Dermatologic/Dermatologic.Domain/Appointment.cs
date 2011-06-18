using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Appointment : IEquatable<Appointment>
    {
        private Office _office;
        private Person _medical;

        public Appointment()
        {
            _office = new Office();
            _medical = new Person();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual string Subject { set; get; }

        [DataMember]
        public virtual DateTime StartDate { set; get; }

        [DataMember]
        public virtual DateTime EndDate { set; get; }

        [DataMember]
        public virtual int Type { set; get; }

        [DataMember]
        public virtual string RecurrenceRule { set; get; }

        [DataMember]
        public virtual Guid RecurrenceParentID { set; get; }

        [DataMember]
        public virtual string Patient { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

        [DataMember]
        public virtual int NotifyEach { set; get; }
            
        [DataMember]
        public virtual int Frecuence { set; get; }
            
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
        public virtual Office Office
        {
            set { _office = value; }
            get { return _office; }
        }

        [DataMember]
        public virtual Person Medical
        {
            set { _medical = value; }
            get { return _medical; }
        }

        public virtual bool Equals(Appointment other)
        {
            return Id.Equals(other.Id);
        }
    }
}
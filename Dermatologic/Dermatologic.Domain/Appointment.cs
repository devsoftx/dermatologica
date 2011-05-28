using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Appointment : IEquatable<Appointment>
    {
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
        public virtual string Place { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

        [DataMember]
        public virtual int NotifyEach { set; get; }
            
        [DataMember]
        public virtual int Frencuence { set; get; }
            
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

        public virtual bool Equals(Appointment other)
        {
            throw new NotImplementedException();
        }
    }
}
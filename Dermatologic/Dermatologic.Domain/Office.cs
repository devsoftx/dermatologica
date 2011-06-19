using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Office : IEquatable<Office>
    {
        private IList<Appointment> _appointments;

        public Office()
        {
            _appointments = new List<Appointment>();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual string Name { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

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
        public virtual IList<Appointment> Appointments
        {
            get { return _appointments; }
            set { _appointments = value; }
        }

        public virtual bool Equals(Office other)
        {
            return Id.Equals(other.Id);
        }
    }
}
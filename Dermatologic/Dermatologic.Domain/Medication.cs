using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Medication : IEquatable<Medication>
    {

        private Person _patient;
        private Service _service;
        private IList<Session> _sessions;

        public Medication()
        {
            _patient = new Person();
            _service = new Service();
            _sessions = new List<Session>();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual Decimal Price { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

        [DataMember]
        public virtual int NumberSessions { set; get; }

        [DataMember]
        public virtual bool IsCompleted { set; get; }

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

        public virtual bool Equals(Medication other)
        {
            return Id.Equals(other.Id);
        }

        [DataMember]
        public virtual Person Patient
        {
            set { _patient = value; }
            get { return _patient; }
        }

        [DataMember]
        public virtual Service Service
        {
            set { _service = value; }
            get { return _service; }
        }

        [DataMember]
        public virtual IList<Session> Sessions
        {
            get { return _sessions; }
            set { _sessions = value; }
        }
    }
}
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Medication : IEquatable<Medication>
    {


        //private IList<Session> _session;

        //public Medication()
        //{ 
        //    _session = new List<Session>();
        //}

        private Person _person;

        private Service _service;
        public Medication()
        {
            _person = new Person();
            _service = new Service();
            //_session = new List<Session>();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        //[DataMember]
        //public virtual string Name { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

        [DataMember]
        public virtual int NumberSessions { set; get; }

        //[DataMember]
        //public virtual Decimal TotalPrice { set; get; }

        [DataMember]
        public virtual bool IsCompleted { set; get; }

        //[DataMember]
        //public virtual bool IsPaid { set; get; }
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

        //[DataMember]
        //public virtual IList<Session> Sessions
        //{
        //    set { _session = value; }
        //    get { return _session; }
        //}

        [DataMember]
        public virtual Person Person
        {
            set { _person = value; }
            get { return _person; }
        }
        [DataMember]
        public virtual Service Service
        {
            set { _service = value; }
            get { return _service; }
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Rate : IEquatable<Rate>
    {
        private Service _service;
        private Person _person;

        public Rate()
        { 
        _service=new Service();
        _person=new Person();       
        }


        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual Service Service
        {
            get { return _service; }
            set { _service = value; }
        }
        
        [DataMember]
        public virtual Person Person
        {
            get { return _person; }
            set { _person = value; }
        }

        [DataMember]
        public virtual string Currency { set; get; }

        [DataMember]
        public virtual decimal UnitCost { set; get; }

        [DataMember]
        public virtual decimal  UnitCostPartner { set; get; }

        [DataMember]
        public virtual String Observation { set; get; }

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

        public virtual bool Equals(Rate other)
        {
            return Id.Equals(other.Id);
        }
    }
}
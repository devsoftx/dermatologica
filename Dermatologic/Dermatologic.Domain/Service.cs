using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    public class Service : IEquatable<Service>
    {
        private CostCenter _costcenter;

        public Service()
        { 
            _costcenter=new CostCenter();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual decimal Price { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

        [DataMember]
        public virtual string Currency { set; get; }

        [DataMember]
        public virtual string Name { set; get; }

        [DataMember]
        public virtual CostCenter CostCenter
        {
            set { _costcenter = value; }
            get { return _costcenter; }
        }

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

        public virtual bool Equals(Service other)
        {
            return Id.Equals(other.Id);
        }
    }
}
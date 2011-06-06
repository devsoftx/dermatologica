using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class CostCenter : IEquatable<CostCenter>
    {
        private Service _service;

        public CostCenter()
        {
            _service = new Service();
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
        public virtual Service Service
        {
            get { return _service; }
            set { _service = value; }
        }

        public virtual bool Equals(CostCenter other)
        {
            return Id.Equals(other.Id);
        }
    }
}
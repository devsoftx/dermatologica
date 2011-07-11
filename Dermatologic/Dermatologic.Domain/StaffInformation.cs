using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class StaffInformation : IEquatable<StaffInformation>
    {
        private CostCenter _costCenter;

        public StaffInformation()
        {
            _costCenter = new CostCenter();
        
        }
                
        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual CostCenter CostCenter
        {
            get { return _costCenter; }
            set { _costCenter = value; }
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

      

        public virtual bool Equals(StaffInformation other)
        {
            return Id.Equals(other.Id);
        }
    }
}
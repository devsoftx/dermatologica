using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class StaffInformation : IEquatable<StaffInformation>
    {
        private CostCenter _costCenter;
        private EmployeeType _employeetype;
        private TypeContract _typecontract;

        public StaffInformation()
        {
            _costCenter = new CostCenter();
            _employeetype = new EmployeeType();
            _typecontract = new TypeContract();
        
        }
                
        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual DateTime? JoinDate { set; get; }

        [DataMember]
        public virtual Decimal NetMonthlySalary { set; get; }

        [DataMember]
        public virtual Decimal OvertimePay { set; get; }

        [DataMember]
        public virtual CostCenter CostCenter
        {
            get { return _costCenter; }
            set { _costCenter = value; }
        }

        [DataMember]
        public virtual EmployeeType EmployeeType
        {
            get { return _employeetype; }
            set { _employeetype = value; }
        }

        [DataMember]
        public virtual TypeContract TypeContract
        {
            get { return _typecontract; }
            set { _typecontract = value; }
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
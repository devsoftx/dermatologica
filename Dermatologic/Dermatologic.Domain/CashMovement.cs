using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class CashMovement : IEquatable<CashMovement>
    {
        private CostCenter _costCenter;
        private Invoice _invoice;

        public CashMovement()
        {
            _costCenter = new CostCenter();
            _invoice = new Invoice();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual string MPayment { set; get; }

        [DataMember]
        public virtual DateTime? Date { set; get; }

        [DataMember]
        public virtual decimal ? EmissionAmount { set; get; }

        [DataMember]
        public virtual decimal? Amount { set; get; }

        [DataMember]
        public virtual int? Factor { set; get; }

        [DataMember]
        public virtual string Currency { set; get; }

        [DataMember]
        public virtual DateTime? ExchangeRate { set; get; }

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
        public virtual CostCenter CostCenter
        {
            get { return _costCenter; }
            set { _costCenter = value; }
        }

        [DataMember]
        public virtual Invoice Invoice
        {
            get { return _invoice; }
            set { _invoice = value; }
        }

        public virtual bool Equals(CashMovement other)
        {
            return Id.Equals(other.Id);
        }
    }
}
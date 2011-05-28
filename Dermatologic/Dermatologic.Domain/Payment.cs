using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Payment : IEquatable<Payment>
    {
        private Session _session;
        private Person _pacient;

        public Payment()
        {
            _session = new Session();
            Pacient = new Person();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual string Name { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

        [DataMember]
        public virtual DateTime DatePayment { set; get; }

        [DataMember]
        public virtual string MPayment { set; get; }

        [DataMember]
        public virtual string Invoice { set; get; }

        [DataMember]
        public virtual string NInvoice { set; get; }

        [DataMember]
        public virtual string Amount { set; get; }

        [DataMember]
        public virtual decimal ExchangeRate { set; get; }

        [DataMember]
        public virtual string Currency { set; get; }

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
        public virtual Session Session
        {
            get { return _session; }
            set { _session = value; }
        }

        [DataMember]
        public virtual Person Pacient
        {
            get { return _pacient; }
            set { _pacient = value; }
        }

        public virtual bool Equals(Payment other)
        {
            return Id.Equals(other.Id);
        }
    }
}
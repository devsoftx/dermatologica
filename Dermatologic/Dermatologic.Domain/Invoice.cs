using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]

    public class Invoice : IEquatable<Invoice>
    {
        private Session _session;
        private Person _pacient;
        private Person _personal;
        private CostCenter _costcenter;

        public Invoice()
        {
            _session = new Session();
            _pacient = new Person();
            _personal = new Person();
            _costcenter = new CostCenter();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual string Name { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

        [DataMember]
        public virtual DateTime? DatePayment { set; get; }

        [DataMember]
        public virtual string MPayment { set; get; }

        [DataMember]
        public virtual string InvoiceType { set; get; }

        [DataMember]
        public virtual string NInvoice { set; get; }

        [DataMember]
        public virtual decimal Amount { set; get; }

        [DataMember]
        public virtual string Currency { set; get; }

        [DataMember]
        public virtual decimal ExchangeRate { set; get; }
                     
        [DataMember]
        public virtual string Movement { set; get; }
        
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

        [DataMember]
        public virtual Person Personal
        {
            get { return _personal; }
            set { _personal = value; }
        }

        [DataMember]
        public virtual CostCenter CostCenter
        {
            get { return _costcenter; }
            set { _costcenter = value; }
        }

        public virtual bool Equals(Invoice other)
        {
            return Id.Equals(other.Id);
        }
    }
}

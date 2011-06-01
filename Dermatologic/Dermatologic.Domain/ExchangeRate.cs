using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    public class ExchangeRate: IEquatable<ExchangeRate>
    {
        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual DateTime DateRate { set; get; }

        [DataMember]
        public virtual String Currency { set; get;}

        [DataMember]
        public virtual Decimal Buy { set; get; }

        [DataMember]
        public virtual Decimal Sale { set; get; }

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

        public virtual bool Equals(ExchangeRate other)
        {
            return Id.Equals(other.Id);
        }
    }
}

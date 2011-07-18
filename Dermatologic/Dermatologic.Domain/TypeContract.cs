using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{   
    [DataContract]
    public class TypeContract : IEquatable<TypeContract>
    {
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

        public virtual bool Equals(TypeContract other)
        {
            return Id.Equals(other.Id);
        }
    }
}

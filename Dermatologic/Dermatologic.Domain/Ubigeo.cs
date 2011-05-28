using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Ubigeo : IEquatable<Ubigeo>
    {
        [DataMember]
        public virtual Guid Id { set; get; }

        [DataMember]
        public virtual string Dpto { set; get; }

        [DataMember]
        public virtual string Prov { set; get; }

        [DataMember]
        public virtual string Dist { set; get; }

        [DataMember]
        public virtual string Name { set; get; }

        [DataMember]
        public virtual bool? IsActive { set; get; }

        [DataMember]
        public virtual DateTime? CreationDate { set; get; }

        [DataMember]
        public virtual DateTime? LastModified { set; get; }

        [DataMember]
        public virtual Guid? CreatedBy { set; get; }

        [DataMember]
        public virtual Guid? ModifiedBy { set; get; }

        public virtual bool Equals(Ubigeo other)
        {
            return Id.Equals(other.Id);
        }
    }
}

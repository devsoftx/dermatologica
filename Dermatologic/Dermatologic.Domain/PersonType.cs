using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class PersonType : IEquatable<PersonType>
    {
        private IList<Person> _persons;

        public PersonType()
        {
            _persons = new List<Person>();
        }

        [DataMember]
        public virtual Guid Id { set; get; }

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
        public virtual IList<Person> Persons
        {
            get { return _persons; }
            set { _persons = value; }
        }

        public virtual bool Equals(PersonType other)
        {
            return Id.Equals(other.Id);
        }
    }
}
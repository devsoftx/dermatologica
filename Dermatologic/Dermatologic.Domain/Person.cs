using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Person : IEquatable<Person>
    {
        private PersonType _personType;

        public Person()
        {
            _personType = new PersonType();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual string FirstName { set; get; }

        [DataMember]
        public virtual string LastNameP { set; get; }

        [DataMember]
        public virtual string LastNameM { set; get; }

        [DataMember]
        public virtual DateTime? DateBirthDay { set; get; }

        [DataMember]
        public virtual int? DocumentType { get; set; }

        [DataMember]
        public virtual PersonType PersonType
        {
            set { _personType = value; }
            get { return _personType; }
        }

        [DataMember]
        public virtual string DocumentNumber { get; set; }

        [DataMember]
        public virtual string Picture { get; set; }

        [DataMember]
        public virtual string Phone { set; get; }

        [DataMember]
        public virtual string CellPhone { set; get; }

        [DataMember]
        public virtual string Email { set; get; }

        [DataMember]
        public virtual string EmergencyPhone { set; get; }

        [DataMember]
        public virtual string EmergencyPerson { set; get; }

        [DataMember]
        public virtual string Address { set; get; }

        [DataMember]
        public virtual bool? IsActive { set; get; }

        [DataMember]
        public virtual DateTime? CreationDate { set; get; }

        [DataMember]
        public virtual DateTime? LastModified { set; get; }

        [DataMember]
        public virtual Guid? CreatedBy { set; get; }

        [DataMember]
        public virtual String CompleteName
        {
            get { return string.Format("{0} {1} {2}", FirstName, LastNameP, LastNameM); }
        }

        [DataMember]
        public virtual Guid? ModifiedBy { set; get; }

        public virtual bool Equals(Person other)
        {
            return Id.Equals(other.Id);
        }

    }
}
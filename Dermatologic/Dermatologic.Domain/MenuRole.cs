using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class MenuRole : IEquatable<MenuRole>
    {
        private Menu _menu;
        private Role _role;
        public MenuRole()
        {
            _menu = new Menu();
            _role = new Role();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual Menu Menu
        {
            set { _menu = value; }
            get { return _menu; }
        }

        [DataMember]
        public virtual Role Role
        {
            set { _role = value; }
            get { return _role; }
        }

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

        public virtual bool Equals(MenuRole other)
        {
            return Id.Equals(other.Id);
        }
    }
}
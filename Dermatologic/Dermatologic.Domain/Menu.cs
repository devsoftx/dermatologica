using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Menu : IEquatable<Menu>
    {
        private IList<MenuRole> _menuRoles;
        public Menu()
        {
            _menuRoles = new List<MenuRole>();
        }

        [DataMember]
        public virtual Guid? Id { set; get; }

        [DataMember]
        public virtual Guid? ParentId { set; get; }

        [DataMember]
        public virtual string  Name { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

        [DataMember]
        public virtual string Url { set; get; }

        [DataMember]
        public virtual int? Orden { set; get; }

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

        public virtual IList<MenuRole> MenuRoles
        {
            get { return _menuRoles; }
            set { _menuRoles = value; }
        }

        public virtual bool Equals(Menu other)
        {
            return Id.Equals(other.Id);
        }
    }
}
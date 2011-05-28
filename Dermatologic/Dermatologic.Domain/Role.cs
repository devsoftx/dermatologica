using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Role : IEquatable<Role>
    {
        private IList<MenuRole> _menuRoles;
        private IList<UsersInRoles> _usersInRoles;

        public Role()
        {
            _menuRoles = new List<MenuRole>();
            _usersInRoles = new List<UsersInRoles>();
        }

        [DataMember]
        public virtual Guid? ApplicationId { set; get; }

        [DataMember]
        public virtual Guid? RoleId { set; get; }

        [DataMember]
        public virtual string RoleName { set; get; }

        [DataMember]
        public virtual string LoweredRoleName { set; get; }

        [DataMember]
        public virtual string Description { set; get; }

        public virtual IList<MenuRole> MenuRoles
        {
            get { return _menuRoles; }
            set { _menuRoles = value; }
        }

        public virtual IList<UsersInRoles> UsersInRoles
        {
            get { return _usersInRoles; }
            set { _usersInRoles = value; }
        }

        public virtual bool Equals(Role other)
        {
            return other.RoleId.Equals(this.RoleId);
        }
    }

}
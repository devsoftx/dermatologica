using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class UsersInRoles : IEquatable<UsersInRoles>
    {
        [DataMember]
        public virtual Guid UserId { set; get; }

        [DataMember]
        public virtual Guid RoleId { set; get; }

        public virtual bool Equals(UsersInRoles other)
        {
            return true;
        }
    }
}
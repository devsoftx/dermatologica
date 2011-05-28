using System;
using System.Runtime.Serialization;

namespace Dermatologic.Domain
{
    [DataContract]
    public class Users : IEquatable<Users>
    {
        [DataMember]
        public virtual Guid? ApplicationId { set; get; }

        [DataMember]
        public virtual Guid? UserId { set; get; }

        [DataMember]
        public virtual string UserName { set; get; }

        [DataMember]
        public virtual string LoweredUserName { set; get; }

        public virtual bool Equals(Users other)
        {
            return other.UserId.Equals(UserId);
        }   
    }
}
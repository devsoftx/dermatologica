using System.Runtime.Serialization;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    [DataContract]
    public class RoleResponse : ResponseBase<Role>
    {
        [DataMember]
        public Role Role { set; get; }
    }
}
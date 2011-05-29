using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class SessionResponse : ResponseBase<Session>
    {
        public IList<Session> Sessions { set; get; }
    }
}
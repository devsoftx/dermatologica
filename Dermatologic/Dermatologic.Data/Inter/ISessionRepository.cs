using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public interface ISessionRepository : IRepository<Session>
    {
        IList<Session> GetSessionByMedication(Session medication);
    }
}

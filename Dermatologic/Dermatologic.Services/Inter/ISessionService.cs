using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface ISessionService : IServiceController<Session>
    {
        SessionResponse GetSessionByMedication(Session medication);
    }
}
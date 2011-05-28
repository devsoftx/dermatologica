using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class SessionService : ServiceController<Session> , ISessionService
    {
        public SessionService()
        {
            Repository = RepositoryFactory.GetSessionRepository();
        }
    }
}
using System;
using Dermatologic.Data;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class SessionService : ServiceController<Session> , ISessionService
    {
        public SessionService()
        {
            Repository = RepositoryFactory.GetSessionRepository();
        }

        public SessionResponse GetSessionByMedication(Session medication)
        {
            var response = new SessionResponse();
            ISessionRepository sessioRepository = new SessionRepository();
            try
            {
                response.Sessions = sessioRepository.GetSessionByMedication(medication);
                response.OperationResult = OperationResult.Success;
                return response;
            }
            catch (Exception e)
            {
                response.OperationResult = OperationResult.Failed;
                response.Message = e.Message;
                return response;
            }
        }
    }
}
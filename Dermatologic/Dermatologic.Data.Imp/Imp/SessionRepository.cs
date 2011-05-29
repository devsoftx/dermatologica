using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class SessionRepository : Repository<Session> , ISessionRepository
    {
        public IList<Session> GetSessionByMedication(Session example)
        {
            const string query = "from Session s where s.Medication.Id = :medicationId";
            string[] parameters = { "medicationId" };
            object[] values = {
                                  example.Medication.Id
                              };
            return Query(query, parameters, values);
        }
    }
}

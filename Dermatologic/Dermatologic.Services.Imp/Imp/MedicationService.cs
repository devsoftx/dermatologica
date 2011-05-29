using System;
using System.Collections.Generic;
using Dermatologic.Data;
using Dermatologic.Data.Persistence;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class MedicationService : ServiceController<Medication> , IMedicationService
    {
        public MedicationService()
        {
            Repository = RepositoryFactory.GetMedicationRepository();
        }

        public MedicationResponse SaveMedication(Medication medication, IEnumerable<Session> sessions)
        {
            var response = new MedicationResponse();
            IMedicationRepository _medicationRepository = new MedicationRepository();
            ISessionRepository _sessionRepository = new SessionRepository();
            try
            {
                NhibernateHelper.BeginTransaction();
                _medicationRepository.Save(medication);
                foreach (var session in sessions)
                {
                    _sessionRepository.Save(session);
                }
                response.OperationResult = OperationResult.Success;
                NhibernateHelper.EndTransaction();
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.OperationResult = OperationResult.Failed;
                return response;
            }
        }
    }
}
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IList<Appointment> GetByOpMedical(Appointment example);
    }
}
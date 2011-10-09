using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IList<Appointment> GetByOpMedical(Appointment example);
        IList<Appointment> GetByPatient(Appointment example);
        IList<Appointment> GetAppointments(DateTime? start, DateTime? end);
    }
}
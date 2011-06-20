using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IAppointmentService : IServiceController<Appointment>
    {
        List<Appointment> GetByOffices(Guid? idOffice);

        IEnumerable<Appointment> GetByOffices(Guid? idOffice, DateTime? fechaInicio, DateTime? fechaFin);

        List<Appointment> GetByDay(DateTime? dateTime, Guid? idOffice);

        List<Appointment> GetByWeek(DateTime dateTime, Guid? idOffice);

        List<Appointment> GetByMonth(DateTime? dateTime, Guid? idOffice);

        DateTime[] GetDatesNearby(DateTime dateTime);

        AppointmentResponse GetByOpMedical(Appointment example);
    }
}
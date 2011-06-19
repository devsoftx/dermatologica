using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class AppointmentResponse : ResponseBase<Appointment>
    {
        public IList<Appointment> Appointments { set; get; }
    }
}
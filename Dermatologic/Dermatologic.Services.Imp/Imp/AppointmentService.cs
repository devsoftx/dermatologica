using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class AppointmentService : ServiceController<Appointment>, IAppointmentService
    {
        public AppointmentService()
        {
            Repository = RepositoryFactory.GetAppointmentRepository();
        }
    }
}
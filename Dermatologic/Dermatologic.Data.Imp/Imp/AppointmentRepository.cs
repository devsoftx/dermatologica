using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public IList<Appointment> GetByOpMedical(Appointment example)
        {
            const string query = "from Appointment a where ( lower(a.Medical.FirstName) like :firstName or lower(a.Medical.LastNameP) like :lastNameP or lower(a.Medical.LastNameM) like :lastNameM ) and a.IsActive = true and a.StartDate <= :startdate order by a.StartDate desc";
            string[] parameters = { "firstName", "lastNameP", "lastNameM", "startdate" };
            object[] values = {
                                  string.Format("{0}" + example.Medical.FirstName + "{0}", "%"),
                                  string.Format("{0}" + example.Medical.LastNameP + "{0}", "%"),
                                  string.Format("{0}" + example.Medical.LastNameM + "{0}", "%"),example.StartDate
                              };
            return Query(query, parameters, values);
        }
    }
}
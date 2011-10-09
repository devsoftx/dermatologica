using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public IList<Appointment> GetByOpMedical(Appointment example)
        {
            const string query = "from Appointment a where (lower(a.Medical.FirstName) like :firstName or lower(a.Medical.LastNameP) like :lastNameP or lower(a.Medical.LastNameM) like :lastNameM) and a.IsActive = 1 order by a.StartDate asc";
            string[] parameters = { "firstName", "lastNameP", "lastNameM"};
            object[] values = {
                                  string.Format("{0}" + example.Medical.FirstName + "{0}", "%"),
                                  string.Format("{0}" + example.Medical.LastNameP + "{0}", "%"),
                                  string.Format("{0}" + example.Medical.LastNameM + "{0}", "%")
                              };
            return Query(query, parameters, values);
        }

        public IList<Appointment> GetByPatient(Appointment example)
        {
            const string query = "from Appointment a where ((lower(a.Patient) like :name ) and (a.IsActive = 1) and (a.StartDate between :start and :end)) order by a.StartDate asc";
            string[] parameters = { "name", "start", "end" };
            object[] values = {
                                  string.Format("%{0}%", example.Patient),
                                  example.StartDate.HasValue ? example.StartDate.Value : (DateTime?)null,
                                  example.EndDate.HasValue ? example.EndDate.Value : (DateTime?)null
                              };
            return Query(query, parameters, values);
        }

        public IList<Appointment> GetAppointments(DateTime? start , DateTime? end)
        {
            const string query = "from Appointment a where a.StartDate between :start and :end";
            string[] parameters = { "start", "end" };
            object[] values = {
                                  start.HasValue ? start.Value : (DateTime?)null,
                                  end.HasValue ? end.Value : (DateTime?)null
                              };
            return Query(query, parameters, values);
        }
    }
}
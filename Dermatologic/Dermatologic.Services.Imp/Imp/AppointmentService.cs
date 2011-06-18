using System;
using System.Collections.Generic;
using System.Linq;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class AppointmentService : ServiceController<Appointment>, IAppointmentService
    {
        public AppointmentService()
        {
            Repository = RepositoryFactory.GetAppointmentRepository();
        }

        public List<Appointment> GetByOffices(Guid? idOffice)
        {
            return new List<Appointment>(Repository.GetAll(p => p.Office.Id == idOffice));
        }

        public List<Appointment> GetByOffices(Guid? idOffice, DateTime? fechaInicio, DateTime? fechaFin)
        {
            return new List<Appointment>(Repository.GetAll(p => p.Office.Id == idOffice && (p.StartDate >= fechaInicio || p.EndDate <= fechaFin)));
        }

        public List<Appointment> GetByMonth(DateTime? dateTime, Guid? idOffice)
        {
            var appointments = Repository.GetAll(p => p.Office.Id == idOffice);
            var query = from appointment in appointments
                        where (appointment.StartDate.Month == dateTime.Value.Month || appointment.EndDate.Month == dateTime.Value.Month)
                        select appointment;
            return new List<Appointment>(query);
        }

        public List<Appointment> GetByDay(DateTime? dateTime, Guid? idOffice)
        {
            var appointments = Repository.GetAll(p => p.Office.Id == idOffice);
            return new List<Appointment>(appointments.Where(p => p.StartDate.Date <= dateTime.Value.Date && p.EndDate.Date > dateTime.Value.Date));
        }

        public List<Appointment> GetByWeek(DateTime dateTime, Guid? idOffice)
        {
            var appointments = Repository.GetAll(p => p.Office.Id == idOffice);
            var datetimes = GetDatesNearby(dateTime);
            var query = from appointment in appointments
                        where (appointment.StartDate.Date >= datetimes[0].Date && datetimes[1].Date >= appointment.EndDate.Date)
                        select appointment;
            return new List<Appointment>(query);
        }

        public DateTime[] GetDatesNearby(DateTime dateTime)
        {
            var dateTimes = new DateTime[2];
            var day = GetNroDayFromDay(dateTime.DayOfWeek);
            switch (day)
            {
                case 1:
                    dateTimes[0] = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
                    dateTimes[1] = new DateTime(dateTime.Year, dateTime.Month, dateTime.AddDays(6).Day);
                    break;
                case 2:
                    dateTimes[0] = new DateTime(dateTime.Year, dateTime.Month, dateTime.AddDays(-1).Day);
                    dateTimes[1] = new DateTime(dateTime.Year, dateTime.Month, dateTime.AddDays(5).Day);
                    break;
                case 3:
                    dateTimes[0] = new DateTime(dateTime.Year, dateTime.Month, dateTime.AddDays(-2).Day);
                    dateTimes[1] = new DateTime(dateTime.Year, dateTime.Month, dateTime.AddDays(4).Day);
                    break;
                case 4:
                    dateTimes[0] = new DateTime(dateTime.Year, dateTime.Month, dateTime.AddDays(-3).Day);
                    dateTimes[1] = new DateTime(dateTime.Year, dateTime.Month, dateTime.AddDays(3).Day);
                    break;
                case 5:
                    dateTimes[0] = new DateTime(dateTime.Year, dateTime.Month, dateTime.AddDays(-4).Day);
                    dateTimes[1] = new DateTime(dateTime.Year, dateTime.Month, dateTime.AddDays(2).Day);
                    break;
                case 6:
                    dateTimes[0] = new DateTime(dateTime.Year, dateTime.Month, dateTime.AddDays(-5).Day);
                    dateTimes[1] = new DateTime(dateTime.Year, dateTime.Month, dateTime.AddDays(1).Day);
                    break;
                case 7:
                    dateTimes[0] = new DateTime(dateTime.Year, dateTime.Month, dateTime.AddDays(-6).Day);
                    dateTimes[1] = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
                    break;
            }
            return dateTimes;
        }

        private static int GetNroDayFromDay(DayOfWeek dayOfWeek)
        {
            var returnDay = 0;
            switch (dayOfWeek.ToString())
            {
                case "Monday":
                    returnDay = 1;
                    break;
                case "Tuesday":
                    returnDay = 2;
                    break;
                case "Wednesday":
                    returnDay = 3;
                    break;
                case "Thursday":
                    returnDay = 4;
                    break;
                case "Friday":
                    returnDay = 5;
                    break;
                case "Saturday":
                    returnDay = 6;
                    break;
                case "Sunday":
                    returnDay = 7;
                    break;
            }
            return returnDay;
        }

    }
}
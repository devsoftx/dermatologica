using System;
using System.Collections.Generic;
using System.Linq;
using Dermatologic.Data;
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
            return new List<Appointment>(Repository.GetAll(p => p.Office.Id == idOffice)).Where(p => p.IsActive == true).ToList();
        }

        public IEnumerable<Appointment> GetByOffices(Guid? idOffice, DateTime? fechaInicio, DateTime? fechaFin)
        {
            return new List<Appointment>(Repository.GetAll(p => p.Office.Id == idOffice && (p.StartDate >= fechaInicio || p.EndDate <= fechaFin))).Where(p => p.IsActive == true).ToList();
        }

        public IEnumerable<Appointment> GetByOffices(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return new List<Appointment>(Repository.GetAll( p => p.StartDate >= fechaInicio || p.EndDate <= fechaFin)).Where(p => p.IsActive == true).ToList();
        }

        public AppointmentResponse GetAppointments(DateTime? start, DateTime? end)
        {
            var response = new AppointmentResponse();
            try
            {
                IAppointmentRepository _repository = new AppointmentRepository();
                var results = _repository.GetAppointments(start, end);
                response.Results = results;
                response.OperationResult = OperationResult.Success;
            }
            catch
            {
                response.OperationResult = OperationResult.Failed;
            }
            return response;
        }

        public List<Appointment> GetByMonth(DateTime? dateTime, Guid? idOffice)
        {
            var appointments = Repository.GetAll(p => p.Office.Id == idOffice);
            var query = from appointment in appointments
                        where (appointment.StartDate.Value.Month == dateTime.Value.Month || appointment.EndDate.Value.Month == dateTime.Value.Month)
                        select appointment;
            return new List<Appointment>(query).Where(p => p.IsActive == true).ToList();
        }

        public List<Appointment> GetByDay(DateTime? dateTime, Guid? idOffice)
        {
            var appointments = Repository.GetAll(p => p.Office.Id == idOffice);
            return new List<Appointment>(appointments.Where(p => p.StartDate.Value.Date <= dateTime.Value.Date && p.EndDate.Value.Date > dateTime.Value.Date)).Where(p => p.IsActive == true).ToList();
        }

        public List<Appointment> GetByWeek(DateTime dateTime, Guid? idOffice)
        {
            var appointments = Repository.GetAll(p => p.Office.Id == idOffice);
            var datetimes = GetDatesNearby(dateTime);
            var query = from appointment in appointments
                        where (appointment.StartDate.Value.Date >= datetimes[0].Date && datetimes[1].Date >= appointment.EndDate.Value.Date)
                        select appointment;
            return new List<Appointment>(query).Where(p => p.IsActive == true).ToList();
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

        public AppointmentResponse GetByOpMedical(Appointment example)
        {
            var response = new AppointmentResponse();
            try
            {
                IAppointmentRepository _repository = new AppointmentRepository();
                IList<Appointment> results = _repository.GetByOpMedical(example);
                if (example.StartDate.HasValue)
                {
                    List<Appointment> filter = results.Where(
                        p =>
                        p.StartDate.Value.Year == example.StartDate.Value.Year &&
                        p.StartDate.Value.Month == example.StartDate.Value.Month &&
                        p.StartDate.Value.Day == example.StartDate.Value.Day).ToList();
                    response.Appointments = filter;
                }
                else
                {
                    response.Appointments = results;
                }
                response.OperationResult = OperationResult.Success;
            }
            catch (Exception ex)
            {
                response.OperationResult = OperationResult.Failed;
                response.Message = ex.Message;
            }
            return response;
        }

        public AppointmentResponse GetByPatient(Appointment example, DateTime? startDate, DateTime? endDate)
        {
            var response = new AppointmentResponse();
            try
            {
                IAppointmentRepository _repository = new AppointmentRepository();
                IList<Appointment> results = _repository.GetByPatient(example);
                var query = from t in results
                            where t.StartDate >= startDate.Value && t.StartDate < endDate.Value
                            select t;
                response.Results = query.ToList<Appointment>();
                response.OperationResult = OperationResult.Success;
            }
            catch (Exception ex)
            {
                response.OperationResult = OperationResult.Failed;
                response.Message = ex.Message;
            }
            return response;
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

        public static int GetNroDaysFromMonth(DateTime? date)
        {
            var returnDays = 0;
            if (date.HasValue)
            {
                switch (date.Value.Month)
                {
                    case 1:
                        returnDays = 31;
                        break;
                    case 2:
                        returnDays = 28;
                        break;
                    case 3:
                        returnDays = 31;
                        break;
                    case 4:
                        returnDays = 30;
                        break;
                    case 5:
                        returnDays = 31;
                        break;
                    case 6:
                        returnDays = 30;
                        break;
                    case 7:
                        returnDays = 31;
                        break;
                    case 8:
                        returnDays = 31;
                        break;
                    case 9:
                        returnDays = 30;
                        break;
                    case 10:
                        returnDays = 31;
                        break;
                    case 11:
                        returnDays = 30;
                        break;
                    case 12:
                        returnDays = 31;
                        break;
                }
            }
            return returnDays;
        }

    }
}
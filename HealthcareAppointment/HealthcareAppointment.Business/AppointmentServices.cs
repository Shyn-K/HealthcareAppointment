using HealthcareAppointment.Data;
using HealthcareAppointment.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public class AppointmentService : IAppointmentRepository
    {
        private readonly HealthcareAppointmentContext _dbContext;

        public AppointmentService(HealthcareAppointmentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointment()
        {
            return await Task.FromResult(_dbContext.Appointments.ToList());
        }

        public async Task<Appointment> GetAppointment(string id)
        {
            var appointment = _dbContext.Appointments.FirstOrDefault(a => a.Id == id);
            return await Task.FromResult(appointment);
        }

        public async Task AddAppointment(Appointment appointment)
        {
            _dbContext.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAppointment(string id)
        {
            var appointment = _dbContext.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment != null)
            {
                _dbContext.Appointments.Remove(appointment);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAppointment(Appointment newAppointment)
        {
            var existingAppointment = _dbContext.Appointments.FirstOrDefault(a => a.Id == newAppointment.Id);
            if (existingAppointment != null)
            {
                existingAppointment.PatientId = newAppointment.PatientId;
                existingAppointment.DoctorId = newAppointment.DoctorId;
                existingAppointment.Date = newAppointment.Date;
                existingAppointment.Status = newAppointment.Status;

                _dbContext.Appointments.Update(existingAppointment);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

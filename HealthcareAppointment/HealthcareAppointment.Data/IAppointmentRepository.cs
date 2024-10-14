using HealthcareAppointment.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointment();

        Task<Appointment> GetAppointment(string id);

        Task AddAppointment(Appointment appointment);

        Task DeleteAppointment(string id);

        Task UpdateAppointment(Appointment newAppointment);


    }
}

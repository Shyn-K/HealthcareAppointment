using HealthcareAppointment.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data
{
    public interface IUserRepository
    {
        public List<User> GetAllUser();
        public Task<User> GetUserByID(string id);

        public Task AddUser(User user);

        public Task UpdateUser(User user);

        public Task DeleteUser(string id);


    }
}

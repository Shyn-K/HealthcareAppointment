using HealthcareAppointment.Data;
using HealthcareAppointment.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public class UserServices : IUserRepository
    {
        private readonly HealthcareAppointmentContext _dbContext;

        public UserServices(HealthcareAppointmentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteUser(string id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public List<User> GetAllUser()
        {
            return _dbContext.Users.ToList();
        }

        public Task<User> GetUserByID(string id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        public Task UpdateUser(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;

                _dbContext.Users.Update(existingUser);
                _dbContext.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}

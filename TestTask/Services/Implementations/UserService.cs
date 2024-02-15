using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<User> GetUser() //done
        {
            var userWithMaxOrder = _db.Users.OrderByDescending(o => o.Orders.Sum(q => q.Quantity)).FirstOrDefaultAsync();
            return userWithMaxOrder;
            
        }


        public Task<List<User>> GetUsers() //done
        {
            var inactiveUsers = _db.Users.Where(s => s.Status == UserStatus.Inactive).ToListAsync();
            return inactiveUsers;
        }

    }
}

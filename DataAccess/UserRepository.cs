using DataAcces.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.Set<User>().Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool Exist(Func<User, bool> predicate)
        {
            return _context.Set<User>().Any(predicate);
        }

        public IEnumerable<User> GetAllUsers(Func<User, bool> predicate)
        {
            return _context.Set<User>().Where(predicate);
        }
    }
}
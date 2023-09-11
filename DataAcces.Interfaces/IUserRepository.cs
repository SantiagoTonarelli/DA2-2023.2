using Domain;

namespace DataAcces.Interfaces
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        bool Exist(Func<User, bool> predicate);
        IEnumerable<User> GetAllUsers(Func<User,bool> predicate);
    }
}
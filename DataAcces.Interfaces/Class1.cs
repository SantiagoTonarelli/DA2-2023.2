using Domain;

namespace DataAcces.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(Func<User,bool> predicate);
    }
}
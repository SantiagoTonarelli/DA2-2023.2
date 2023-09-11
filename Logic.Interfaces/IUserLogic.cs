using Domain;

namespace Logic.Interfaces
{
    public interface IUserLogic
    {
        IEnumerable<User> GetAllUsers();
    }
}
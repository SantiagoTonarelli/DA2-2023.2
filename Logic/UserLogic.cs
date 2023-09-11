using DataAcces.Interfaces;
using Domain;
using Logic.Interfaces;

namespace Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;
        public UserLogic(IUserRepository userRepository) {
            this._userRepository = userRepository;
        }

        public User CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers(string nameOrEmpty)
        {
            return _userRepository.GetAllUsers(GetUsersByName(nameOrEmpty));
        }

        private Func<User,bool> GetUsersByName(string name)
        {
            return (User u) => u.Name == name;
        }
    }
}
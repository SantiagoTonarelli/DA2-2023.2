using DataAcces.Interfaces;
using Domain;
using Logic.Interfaces;
using System.Xml.Linq;

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
            user.SelfValidation();
            if (this._userRepository.Exist(GetUsersByName(user.Name)))
            {
                throw new InvalidOperationException("User already exist");
            }
            return this._userRepository.CreateUser(user);
        }

        public IEnumerable<User> GetAllUsers(string nameOrEmpty)
        {
            return _userRepository.GetAllUsers(GetUsersByName(nameOrEmpty));
        }

        private Func<User,bool> GetUsersByName(string name)
        {
            return (User u) => name == "" || u.Name == name;
        }
    }
}
using Domain;

namespace APIModels
{
    public class UserRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Pass { get; set; }

        public User ToEntity()
        {
            return new User { Name = Name, Age = Age, Pass = Pass };
        }
    }
}
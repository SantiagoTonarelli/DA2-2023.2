using Domain;

namespace APIModels
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public UserResponse(User aUser)
        {
            this.Id = aUser.Id;
            this.Name = aUser.Name;
            this.Age = aUser.Age;
        }
    }
}
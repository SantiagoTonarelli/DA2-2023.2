namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Pass { get; set; }

        public void SelfValidation()
        {
            if (this.Age < 5) throw new ArgumentNullException("Age Invalid");
        }
    }
}
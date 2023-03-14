namespace Domain.Entities
{
    public class User : EntityBase
    {
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }

        public User(string email, string name, string password)
        {
            Email = email;
            Name = name;
            Password = password;
        }
    }
}
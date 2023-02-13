using EntitiesLayer.Abstract;

namespace EntitiesLayer.Concrete
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Person(int id, string firstName, string lastName, string email, string phoneNumber, string passwordHash, string passwordSalt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
        public Person()
        {

        }
    }
}
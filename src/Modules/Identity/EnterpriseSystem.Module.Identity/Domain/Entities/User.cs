using EnterpriseSystem.Shared.DDD;

namespace EnterpriseSystem.Module.Identity.Domain.Entities
{
    public class User : Aggregate<Guid>
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string DocumentType { get; private set; }
        public string DocumentNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        private User() { } 

        public User(Guid id, string name,string lastName,string documentType,string documentNumber,string email,string password)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            DocumentType = documentType;
            DocumentNumber = documentNumber;
            Email = email;
            Password = password;
        }

        public static User Create(
            string name, 
            string lastName, 
            string documentType, 
            string documentNumber, 
            string email, 
            string password)
        {
            return new User(
                Guid.NewGuid(),
                name,
                lastName,
                documentType,
                documentNumber,
                email,
                password
            );
        }


    }
}

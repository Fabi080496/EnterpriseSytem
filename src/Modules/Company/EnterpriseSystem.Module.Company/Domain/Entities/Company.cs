using EnterpriseSystem.Shared.DDD;

namespace EnterpriseSystem.Module.Organization.Domain.Entities
{
    public class Company : Aggregate<Guid>
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        private Company()
        {

        }
        public Company(Guid id, int number, string name, string address)
        {
            Id = id;
            Number = number;
            Name = name;
            Address = address;
        }

        public static Company Create(int number, string name, string address)
        {
            return new Company(Guid.NewGuid(), number, name, address);
        }

    }
}

using Millennium.Models;

namespace Millennium.Persistance
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ILogger<Person> logger) : base(logger)
        {
            this.inMemoryDatabase.Add(new Person()
            {
                Name = "John",
                Age = 13,
                Phone = "987654321",
            });
            this.inMemoryDatabase.Add(new Person()
            {
                Name = "John",
                Age = 13,
            });

            foreach (var person in inMemoryDatabase)
            {
                Console.WriteLine(person);
            }
        }

        public List<Person> GetAllWithPhones()
        {
            return this.Get(p => string.IsNullOrEmpty(p.Phone)).ToList();
        }
    }
}

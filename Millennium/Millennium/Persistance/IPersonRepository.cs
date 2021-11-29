using Millennium.Infrastructure;
using Millennium.Models;

namespace Millennium.Persistance;

public interface IPersonRepository : IRepository<Person>
{
    public List<Person> GetAllWithPhones();
}
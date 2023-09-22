using Sandbox.Models;

namespace Sandbox.Services
{
    public interface IPersonService
    {
        void AddPerson(Person person);
        List<Person> GetPersons();
    }
}

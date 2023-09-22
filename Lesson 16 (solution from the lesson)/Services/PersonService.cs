using Sandbox.Models;
using System.Text.Json;

namespace Sandbox.Services
{
    public class PersonService : IPersonService
    {
        private readonly string _fileName = "persons.json";

        public void AddPerson(Person person)
        {
            if(person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            var persons = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(_fileName))
                ?? new List<Person>();
            persons.Add(person);
            File.WriteAllText(_fileName, JsonSerializer.Serialize(persons));
        }

        public List<Person> GetPersons()
        {
            return JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(_fileName))
                ?? new List<Person>();
        }
    }
}

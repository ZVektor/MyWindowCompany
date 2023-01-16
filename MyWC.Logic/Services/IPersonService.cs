using Microsoft.EntityFrameworkCore;
using MyWC.DataModels.Models;

namespace MyWC.Logic.Services
{
    public interface IPersonService
    {
        //IEnumerable<Person> GetPersons();
        public Task<IEnumerable<Person>> GetPersons();

        public Task<IEnumerable<Person>> GetPersons(PersonSortState sortOrder, string searchName, string searchLName, string searchCity);

        public Task<Person> GetPerson(int id);

        public Task<int> PostPerson(Person newPerson);

        public Task<bool> UpdatePerson(int id, Person updatePerson);

        public Task<bool> DeletePerson(int id);

    }
}

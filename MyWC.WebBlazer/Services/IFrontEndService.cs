using MyWC.DataModels.Models;
using MyWC.Logic.Services;

namespace MyWC.WebBlazer.Services
{
    public interface IFrontEndService
    {
        public Task<IEnumerable<Person>> GetPersons();

        public Task<IEnumerable<Person>> GetPersons(PersonSortState sortState, string? searchName, string? searchLName, string? searchCity);

        public Task<Person> GetPerson(int id);

        public Task<int> PostPerson(Person newPerson);

        public Task<bool> UpdatePerson(Person newPerson);

        public Task<bool> DeletePerson(int id);


        public Task<IEnumerable<Phone>> GetPhones();
        public Task<IEnumerable<Phone>> GetPhone(int id);
    }
}

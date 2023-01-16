using MyWC.DataModels.Models;

namespace MyWC.Logic.Services
{
    public interface IPersonService
    {
        //IEnumerable<Person> GetPersons();
        public Task<IEnumerable<Person>> GetPersons();

        public Task<IEnumerable<Person>> GetPersons(SortState sortState);

        public Task<Person> GetPerson(int id);

        //int PostPerson(Person newPersonModel);

        //bool UpdatePerson(int id, Person updatePersonModel);

        //bool DeletePerson(int id);
    }
}

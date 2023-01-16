using Microsoft.EntityFrameworkCore;
using MyWC.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWC.Logic.Services
{
    public class PersonService : IPersonService
    {
        private readonly MyWcdbContext _db;
        public PersonService(MyWcdbContext db) => _db = db;

        public async Task<IEnumerable<Person>> GetPersons()
        {
            //return await _db.People.ToListAsync();
            return await _db.People.Include(c => c.Phones).ToListAsync();
        }


        public async Task<Person> GetPerson(int id)
        {
            var response = await _db.People.Include(c => c.Phones).FirstOrDefaultAsync(x => x.Id == id);
            return response;

        }

        public async Task<IEnumerable<Person>> GetPersons(SortState sortOrder, string searchName,string searchLName, string searchCity)
        {
            IQueryable<Person>? personData = _db.People;

            if (!String.IsNullOrEmpty(searchName))
            {
                personData = personData.Where(s => s.FirstName.Contains(searchName));
            }
            if (!String.IsNullOrEmpty(searchLName))
            {
                personData = personData.Where(s => s.LastName.Contains(searchLName));
            }
            if (!String.IsNullOrEmpty(searchCity))
            {
                personData = personData.Where(s => s.City.Contains(searchCity));
            }

            personData = sortOrder switch
            {
                SortState.IdDesk=> personData.OrderByDescending(s => s.Id),
                SortState.FistNameAsc => personData.OrderBy(s => s.FirstName),
                SortState.FistNameDesc => personData.OrderByDescending(s => s.FirstName),
                SortState.LastNameAsc => personData.OrderBy(s => s.LastName),
                SortState.LastNameDesc => personData.OrderByDescending(s => s.LastName),
                SortState.CityAsc => personData.OrderBy(s => s.City),
                SortState.CityDesc => personData.OrderByDescending(s => s.City),
                _ => personData.OrderBy(s => s.Id),
            };

            return await personData.AsNoTracking().Include(c => c.Phones).ToListAsync();
        }

        //public PersonModel GetPerson(int id)
        //{
        //    //Это какойто треш, надо что то делать с этим
        //    var personFind = _db.Persons.FirstOrDefault(x => x.Id == id);
        //    PersonModel _personModel = new PersonModel();
        //    if (personFind != null)
        //    {
        //        _personModel.Id = personFind.Id;
        //        _personModel.FirstName = personFind.FirstName;
        //        _personModel.LastName = personFind.LastName;
        //        _personModel.City = personFind.City;
        //        return _personModel;
        //    }
        //    else
        //        return null;


        //}

        //public int PostPerson(PersonModel newPersonModel)
        //{
        //    Person _person = new Person();
        //    _person.FirstName = newPersonModel.FirstName;
        //    _person.LastName = newPersonModel.LastName;
        //    _person.City = newPersonModel.City;
        //    _db.Add(_person);
        //    _db.SaveChanges();

        //    var personId = _person.Id;

        //    return personId;
        //}

        //public bool UpdatePerson(int id, PersonModel updatePersonModel)
        //{
        //    bool flag = false;
        //    var _personFind = _db.Persons.FirstOrDefault(x => x.Id == id);
        //    if (_personFind != null)
        //    {
        //        _personFind.FirstName = updatePersonModel.FirstName;
        //        _personFind.LastName = updatePersonModel.LastName;
        //        _personFind.City = updatePersonModel.City;
        //        try
        //        {
        //            _db.Persons.Update(_personFind);
        //            _db.SaveChanges();
        //            flag = true;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //    return flag;
        //}

        //public bool DeletePerson(int id)
        //{
        //    bool flag = false;
        //    var _personFind = _db.Persons.FirstOrDefault(x => x.Id == id);
        //    if (_personFind != null)
        //    {
        //        try
        //        {
        //            _db.Persons.Remove(_personFind);
        //            _db.SaveChanges();
        //            flag = true;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //    return flag;
        //}
    }
}

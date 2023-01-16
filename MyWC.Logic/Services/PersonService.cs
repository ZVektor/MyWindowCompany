using Microsoft.EntityFrameworkCore;
using MyWC.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWC.Logic.Services;

namespace MyWC.Logic.Services
{
    public class PersonService : IPersonService
    {
        private readonly MyWcdbContext _db;
        public PersonService(MyWcdbContext db) => _db = db;

        //TODO Проверить! Возможно она больше не нужна
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

        /// <summary>
        /// Метод получения данных, можно с сортировкой
        /// </summary>
        /// <param name="sortOrder">Модель сортировки прописана в классе</param>
        /// <param name="searchName">Фильтр по имени</param>
        /// <returns>Describe return value.</returns>
        public async Task<IEnumerable<Person>> GetPersons(SortState sortOrder, string searchName, string searchLName, string searchCity)
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
                SortState.IdDesk => personData.OrderByDescending(s => s.Id),
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

        public async Task<int> PostPerson(Person newPersonModel)
        {

            _db.Add(newPersonModel);
            await _db.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            var personId = newPersonModel.Id;

            return personId;
        }

        public async Task<bool> UpdatePerson(int id, Person updatePersonModel)
        {
            bool flag = false;
            _db.Entry(updatePersonModel).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
                flag = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }
            return flag;
        }

        public async Task<bool> DeletePerson(int id)
        {
            bool flag = false;
            var person = await _db.People.FindAsync(id);
            if (person != null)
            {
                try
                {
                    _db.People.Remove(person);
                    await _db.SaveChangesAsync();
                    flag = true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return flag;
        }
        private bool PersonExists(int id)
        {
            return _db.People.Any(e => e.Id == id);
        }
    }
}

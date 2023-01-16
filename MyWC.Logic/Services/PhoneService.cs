using Microsoft.EntityFrameworkCore;
using MyWC.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWC.Logic.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly MyWcdbContext _db;
        public PhoneService(MyWcdbContext db) => _db = db;

        //TODO Проверить! Возможно она больше не нужна
        public async Task<IEnumerable<Phone>> GetPhones()
        {
            //return await _db.People.ToListAsync();
            return await _db.Phones.ToListAsync();
        }

        public async Task<Phone> GetPhone(int id)
        {
            var response = await _db.Phones.FirstOrDefaultAsync(x => x.Id == id);
            return response;

        }

        /// <summary>
        /// Метод получения данных, можно с сортировкой
        /// </summary>
        /// <param name="sortOrder">Модель сортировки прописана в классе</param>
        /// <param name="searchPhone">Фильтр по телефону</param>
        /// <returns>Describe return value.</returns>
        public async Task<IEnumerable<Phone>> GetPhones(PhoneSortState sortOrder, string searchPhone)
        {
            IQueryable<Phone>? phoneData = _db.Phones;
            if (!String.IsNullOrEmpty(searchPhone))
            {
                phoneData = phoneData.Where(s => s.PhoneNumber.Contains(searchPhone));
            }
            phoneData = sortOrder switch
            {
                PhoneSortState.IdDesk => phoneData.OrderByDescending(s => s.Id),
                PhoneSortState.PhoneAsc => phoneData.OrderBy(s => s.PhoneNumber),
                PhoneSortState.PhoneDesc => phoneData.OrderByDescending(s => s.PhoneNumber),
                PhoneSortState.PersonIdAsc => phoneData.OrderBy(s => s.PeopleId),
                PhoneSortState.PersonIdDesc => phoneData.OrderByDescending(s => s.PeopleId),
                _ => phoneData.OrderBy(s => s.Id),
            };
            return await phoneData.AsNoTracking().ToListAsync();
        }

        public async Task<int> PostPhone(Phone newPhone)
        {
            //TODO Надо ли добавить try catch - выяснить
            //и переделать чтоб возвращал успех или нет, bool
            _db.Add(newPhone);
            await _db.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            var phoneId = newPhone.Id;

            return phoneId;
        }

        public async Task<bool> UpdatePhone(int id, Phone updatePhone)
        {
            bool flag = false;
            _db.Entry(updatePhone).State = EntityState.Modified;

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

        public async Task<bool> DeletePhone(int id)
        {
            bool flag = false;
            var deletePhone = await _db.Phones.FindAsync(id);
            if (deletePhone != null)
            {
                try
                {
                    _db.Phones.Remove(deletePhone);
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
        private bool PhoneExists(int id)
        {
            return _db.Phones.Any(e => e.Id == id);
        }
    }
}

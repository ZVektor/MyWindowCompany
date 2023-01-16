using MyWC.DataModels.Models;

namespace MyWC.Logic.Services
{
    public interface IPhoneService
    {
        public Task<IEnumerable<Phone>> GetPhones();

        public Task<IEnumerable<Phone>> GetPhones(PhoneSortState sortOrder, string searchPhone);

        public Task<Phone> GetPhone(int id);

        public Task<int> PostPhone(Phone newPhone);

        public Task<bool> UpdatePhone(int id, Phone updatePerson);

        public Task<bool> DeletePhone(int id);
    }
}

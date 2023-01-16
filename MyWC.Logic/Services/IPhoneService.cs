using MyWC.DataModels.Models;

namespace MyWC.Logic.Services
{
    public interface IPhoneService
    {
        IEnumerable<Phone> GetPhones();

        Phone GetPhone(int id);


    }
}

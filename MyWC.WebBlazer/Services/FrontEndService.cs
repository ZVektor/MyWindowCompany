using MyWC.DataModels.Models;
using MyWC.Logic.Services;
using System.Net;

namespace MyWC.WebBlazer.Services
{
    public class FrontEndService: IFrontEndService
    {
        private readonly HttpClient _httpClient;
        public FrontEndService(HttpClient httpClient) => _httpClient = httpClient;

        //--------------------------------------------
        //---------Сервисы карточки клиентов ---------
        //--------------------------------------------
        public async Task<IEnumerable<Person>> GetPersons()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Person>>("api/People");
            return response;
        }

        public async Task<IEnumerable<Person>> GetPersons(PersonSortState sortState, string? searchName, string? searchLName, string? searchCity)
        {
            //TODO Переделать весь запрос на метод POST!!!????
            string newFilterRequest ="";
            if (!String.IsNullOrEmpty(searchName))
            {
                newFilterRequest = newFilterRequest+"&searchName=" + searchName;
            }
            if (!String.IsNullOrEmpty(searchLName))
            {
                newFilterRequest = newFilterRequest+"&searchLName=" + searchLName;
            }
            if (!String.IsNullOrEmpty(searchCity))
            {
                newFilterRequest = newFilterRequest+"&searchCity=" + searchCity;
            }



            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Person>>("api/People?sortState="+ sortState.ToString()+ newFilterRequest);
            return response;
        }

        public async Task<Person> GetPerson(int id)
        {   //Можно обозначить явный тип PersonModel
            var response = await _httpClient.GetFromJsonAsync<Person>("api/People/" + id.ToString());
            return response;
        }

        public async Task<int> PostPerson(Person newPerson)
        {
            //Можно обозначить явный тип: HttpResponseMessage response = null;
            var response = await _httpClient.PostAsJsonAsync("api/People", newPerson);

            if (response.StatusCode == (HttpStatusCode)200)
            {
                //Строка возвращает ответ после POST запроса
                int responseId = await response.Content.ReadFromJsonAsync<int>();
                return responseId;
            }
            else
            {
                return 0;
            }
        }

        public async Task<bool> UpdatePerson(Person newPerson)
        {
            HttpResponseMessage response = null;
            response = await _httpClient.PutAsJsonAsync("api/People/" + newPerson.Id, newPerson);
            if (response.StatusCode == (HttpStatusCode)200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeletePerson(int id)
        {
            HttpResponseMessage response = null;
            response = await _httpClient.DeleteAsync("api/People/" + id.ToString());

            if (response.StatusCode == (HttpStatusCode)200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //-------------------------------------------
        //---------Сервисы телефонные Номера---------
        //-------------------------------------------
        public async Task<IEnumerable<Phone>> GetPhones()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Phone>>("api/Phone");

        }

        public async Task<IEnumerable<Phone>> GetPhone(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Phone>>("api/Phone/" + id.ToString());

        }
    }
}

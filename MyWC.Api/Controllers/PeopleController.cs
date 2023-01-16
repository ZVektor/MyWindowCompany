using Microsoft.AspNetCore.Mvc;
using MyWC.Logic.Services;
using MyWC.DataModels.Models;

namespace MyWC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BindProperties(SupportsGet = true)]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        //GET api/People?sortState=CityAsc&searchName=..&searchCity=..
        [HttpGet]
        //TODO переделать фильтр, на в какой колонке искать и две переменные searchString и searchInt
        public async Task<IActionResult> GetPersons(SortState sortState, string? searchName, string? searchLName, string? searchCity)
        {
            var data = await _personService.GetPersons(sortState, searchName, searchLName, searchCity);
            return Ok(data);
        }

        //GET api/People/int
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var data = await _personService.GetPerson(id);
            return Ok(data);
        }


        // POST: api/PostPerson
        [HttpPost]
        public async Task<IActionResult> PostPerson(Person newPersonModel)
        {
            var data = await _personService.PostPerson(newPersonModel);
            return Ok(data);
        }


        // PUT: api/PostPerson
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person updatePerson)
        {
            if (id != updatePerson.Id)
            {
                return BadRequest();
            }
            var data = await _personService.UpdatePerson(id, updatePerson);
            return Ok(data);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var data = await _personService.DeletePerson(id);
            return Ok(data);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWC.DataModels.Models;
using MyWC.Logic.Services;

namespace MyWC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;
        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        //GET api/Phone?sortState=PhoneAsc&searchName=8923
        [HttpGet]
        //TODO переделать фильтр, на в какой колонке искать и две переменные searchString и searchInt
        public async Task<IActionResult> GetPhones(PhoneSortState sortState, string? searchPhone)
        {
            var data = await _phoneService.GetPhones(sortState, searchPhone);
            return Ok(data);
        }

        //GET api/Phone/int
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPhone(int id)
        {
            var data = await _phoneService.GetPhone(id);
            return Ok(data);
        }

        // POST: api/Phone
        [HttpPost]
        public async Task<IActionResult> PostPhone(Phone newPhone)
        {
            var data = await _phoneService.PostPhone(newPhone);
            return Ok(data);
        }

        // PUT: api/Phone
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhone(int id, Phone updatePhone)
        {
            if (id != updatePhone.Id)
            {
                return BadRequest();
            }
            var data = await _phoneService.UpdatePhone(id, updatePhone);
            return Ok(data);
        }

        // DELETE: api/Phone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhone(int id)
        {
            var data = await _phoneService.DeletePhone(id);
            return Ok(data);
        }
    }
}

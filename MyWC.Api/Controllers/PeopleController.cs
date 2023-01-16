﻿using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet]
        //public async Task<IActionResult> GetPersons()
        //{
        //    var data = await _personService.GetPersons();
        //    return Ok(data);

        //}
        [HttpGet]
        //[HttpGet("sortState:SortState")]
        public async Task<IActionResult> GetPersons(SortState sortState)
        {
            var data = await _personService.GetPersons(sortState);
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var data = await _personService.GetPerson(id);
            return Ok(data);
        }
    }
}
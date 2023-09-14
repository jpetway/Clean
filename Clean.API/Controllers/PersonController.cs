using Clean.Application.DTOs;
using Clean.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        public PersonController(IPersonService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Retrieves all person records.
        /// </summary>
        /// <returns>IEnumerable or Persons</returns>
        [HttpGet("GetAllPeople")]
        public async Task<IEnumerable<PersonDto>> Get() => await _service.GetAllAsync();

        /// <summary>
        ///     Retrieves individual person record based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON of Person</returns>
        [HttpGet("GetPersonById/{id}")]
        public async Task<PersonDto> Get(int id) => await _service.GetByIdAsync(id);

        /// <summary>
        ///     Create New Person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("AddPerson")]
        public async void Post([FromBody] PersonDto person) => await _service.AddAsync(person);

        // PUT api/<PersonController>/5
        /// <summary>
        ///     Update Person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPut("UpdatePerson")]
        public async void Put([FromBody] PersonDto person) => await _service.UpdateAsync(person);


        // DELETE api/<PersonController>/5
        /// <summary>
        ///     Soft Delete Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeletePerson/{id}")]
        public async void Delete(int id) => await _service.DeleteAsync(id);
        
    }
}

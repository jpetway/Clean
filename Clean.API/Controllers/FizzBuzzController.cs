using Clean.Application.DTOs;
using Clean.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzService _fizzBuzzService;
        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        /// <summary>
        ///     GetAllFizzBuzz
        /// </summary>
        /// <returns>IDIctionary of FizzBuzz</returns>
        [HttpGet()]
        public IDictionary<int, string> Get() => _fizzBuzzService.GetFizzBuzz();
    }
}

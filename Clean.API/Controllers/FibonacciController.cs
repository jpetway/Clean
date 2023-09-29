using Clean.Application.DTOs;
using Clean.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FibonacciController : ControllerBase
{
    private readonly IFibonacciService _service;
    public FibonacciController(IFibonacciService service)
    {
        _service = service;
    }

    [HttpGet()]
    public FibonacciDto FibonacciNPosition(int n) => _service.FibonacciNPosition(n);
}

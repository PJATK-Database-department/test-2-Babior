using Microsoft.AspNetCore.Mvc;
using Test2.Services.Contracts;

namespace Test2.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassController : ControllerBase
{
    //inject service
    private readonly IClassService _classService;
    
    public ClassController(IClassService classService)
    {
        _classService = classService;
    }

    
}
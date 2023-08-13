using Microsoft.AspNetCore.Mvc;

namespace ClinicaSanFelipeAPI.Controllers;

[ApiController]
[Route("/")]
public class DefaultController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Running...";
    }
}


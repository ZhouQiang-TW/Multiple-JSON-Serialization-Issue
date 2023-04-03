using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly Dictionary<string, object> Details = new()
    {
        {
            "InfoDetails", new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            }
        }
    };

    [HttpGet(nameof(GetOne))]
    public IActionResult GetOne()
    {
        return new JsonResult(Details);
    }

    [HttpGet(nameof(GetTwo))]
    public IActionResult GetTwo()
    {
        return new JsonResult(Details, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    ProcessDictionaryKeys = false
                }
            }
        });
    }
}
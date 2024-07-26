using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Api.Services;
namespace SurveyBasket.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class DevelopmentController : ControllerBase
{
    private readonly ILogger logger;
  

    public DevelopmentController(ILogger<DevelopmentController> logger)
    {
      
        this.logger = logger;
    }

    [HttpGet] 
    public IActionResult Run(
        [FromKeyedServices(key:"windows")] IOperationTransient windowsService,
        [FromKeyedServices(key:"macOs")] IOperationTransient macOsService)
    {
        //logger.LogWarning("Windows {0}", windowsService.OprationId);
        logger.LogError("MacOs {0}", macOsService.OprationId);


        return Ok();

    }
}
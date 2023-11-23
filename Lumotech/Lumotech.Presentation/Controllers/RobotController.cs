using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Lumotech.Presentation.Controllers;

[Route("api/robotstations/{robotStationId}/robots")]
[ApiController]
public class RobotController : ControllerBase
{
    private readonly IServiceManager _service;

    public RobotController(IServiceManager service) => _service = service;
}
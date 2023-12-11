using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

namespace Lumotech.Presentation.Controllers;

[Route("api/backup")]
[ApiController]
public class BackupController : ControllerBase
{
    private readonly IServiceManager _service;

    public BackupController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpPost]
    [Route("create")]
    public IActionResult CreateDbBackup()
    {
        try
        {
            _service.BackupService.CreateBackup();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Backup creation failed: {ex.Message}");
        }
    }
}
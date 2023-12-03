using Lumotech.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Lumotech.Presentation.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IServiceManager _service;

    public UserController(IServiceManager service) => _service = service;
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var result = await _service.UserService.DeleteUser(id);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        return NoContent();
    }
}
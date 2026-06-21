using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e2Commerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{UserID}")]
    public async Task<IActionResult> GetUserByUserID(Guid? UserID)
    {
        if (UserID == null)
        {
            return BadRequest("UserID cannot be null");
        }
        UserDTO? userDTO = await _userService.GetUserByUserID(UserID);
        if (userDTO == null)
        {
            return NotFound();
        }
        return Ok(userDTO);
    }
}

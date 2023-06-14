using ApiFarmacia.Services;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace ApiFarmacia.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    /*private readonly TokenService _tokenService;
    public AccountController(TokenService tokenService) 
    {
        _tokenService = tokenService;
    }  */

    [HttpPost("v1/login")]
    public IActionResult Login([FromServices] TokenService tokenService)
    {
        var token = tokenService.GenerateToken(null);
        return Ok(token);
    }
}

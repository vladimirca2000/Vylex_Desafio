using Microsoft.AspNetCore.Mvc;
using Vylex.Domain.DTOs.Base;
using Vylex.WebAPI.Service;

namespace Vylex.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        // Valide o usuário (isso é apenas um exemplo, você deve validar contra um banco de dados)
        if (model.Username == "test" && model.Password == "test")
        {
            var token = _tokenService.GenerateToken(model.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}


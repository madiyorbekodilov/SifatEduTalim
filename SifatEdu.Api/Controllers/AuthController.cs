using SifatEdu.Api.Models;
using SifatEdu.Service.Helpers;
using Microsoft.AspNetCore.Mvc;
using SifatEdu.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace SifatEdu.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("authenticate")]
    [AllowAnonymous]
    public async Task<IActionResult> AuthenticateAsync(string emailOrUsername, string password)
    {
        if (Validator.IsValidEmail(emailOrUsername))
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await this.authService.GenerateTokenAsync(emailOrUsername, password)
            });
        }
        else if (Validator.IsValidPassword(password))
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.authService.GenerateTokenAsync(emailOrUsername, password)
            });
        }

        return BadRequest("Username or password is incorrect");
    }
}
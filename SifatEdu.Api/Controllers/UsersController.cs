using SifatEdu.Api.Models;
using SifatEdu.Service.Helpers;
using Microsoft.AspNetCore.Mvc;
using SifatEdu.Service.DTOs.User;
using SifatEdu.Service.Interfaces;

namespace SifatEdu.Api.Controllers;

public class UsersController : BaseController
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> PostAsync(UserCreationDto dto)
    {
        var emailValid = Validator.IsValidEmail(dto.Email);
        var passwordValid = Validator.IsValidPassword(dto.Password);
        var nameValid = Validator.IsValidName(dto.FirsName);
        var surnameValid = Validator.IsValidName(dto.LastName);

        if (emailValid && passwordValid && nameValid && surnameValid)
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.userService.AddAsync(dto)
            });
        return BadRequest("Invalid Information");
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(UserUpdateDto dto)
    {
        var emailValid = Validator.IsValidEmail(dto.Phone);
        var nameValid = Validator.IsValidName(dto.FirsName);
        var surnameValid = Validator.IsValidName(dto.LastName);
        
        if(emailValid && nameValid && surnameValid)
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.userService.ModifyAsync(dto)
            });

        return BadRequest("Invalid Information");
    }

    [HttpDelete("get/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.RemoveAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.RetrieveByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.RetrieveAllAsync()
        });
}
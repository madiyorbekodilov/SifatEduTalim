using SifatEdu.Api.Models;
using Microsoft.AspNetCore.Mvc;
using SifatEdu.Service.Helpers;
using SifatEdu.Service.DTOs.Test;
using SifatEdu.Service.Interfaces;

namespace SifatEdu.Api.Controllers;

public class TestController : BaseController
{
    private readonly ITestService service;

    public TestController(ITestService service)
    {
        this.service = service;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(TestCreationDto dto)
    {
        var validation = Validator.IsValidText(dto.Name);
        var validDescription = Validator.IsValidDescription(dto.Description);

        if (validation && validDescription)
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.service.CreateAsync(dto)
            });

        return BadRequest("Name or Description is invalid");
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(TestUpdateDto dto)
    {
        var validation = Validator.IsValidText(dto.Name);
        var validDescription = Validator.IsValidDescription(dto.Description);

        if (validation && validDescription)
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.service.ModifyAsync(dto)
            });

        return BadRequest("Name or Description is invalid");
    }

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.DeleteAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.GetByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.GetAllAsync()
        });

    [HttpGet("search/{id:long}")]
    public async Task<IActionResult> SearchAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.SearchExamAsync(id)
        });
}
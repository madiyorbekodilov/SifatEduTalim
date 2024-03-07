using Microsoft.AspNetCore.Mvc;
using SifatEdu.Service.DTOs.Question;
using SifatEdu.Service.Helpers;
using SifatEdu.Api.Models;
using SifatEdu.Service.Interfaces;

namespace SifatEdu.Api.Controllers;

public class QuestionController : BaseController
{
    private readonly IQuestionService service;

    public QuestionController(IQuestionService service)
    {
         this.service = service;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(QuestionCreationDto dto)
    {
        var validation = Validator.IsValidText(dto.Savol);

        if (validation)
           return Ok(new Response
           {
               StatusCode = 200,
               Message = "Success",
               Data = await this.service.CreateAsync(dto)
           });

        return BadRequest("Question is invalid");
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(QuestionUpdateDto dto)
    {
        var validation = Validator.IsValidText(dto.Savol);

        if (validation)
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.service.ModifyAsync(dto)
            });

        return BadRequest("Question is invalid");
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

    [HttpPut("update-image")]
    public async Task<IActionResult> PutImageAsync(long id, IFormFile formFile)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.ModifyImageAsync(id, formFile)
        });
}
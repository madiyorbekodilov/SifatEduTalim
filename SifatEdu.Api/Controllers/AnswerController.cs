using SifatEdu.Api.Models;
using Microsoft.AspNetCore.Mvc;
using SifatEdu.Service.Helpers;
using SifatEdu.Service.Interfaces;
using SifatEdu.Service.DTOs.Answer;

namespace SifatEdu.Api.Controllers;

public class AnswerController : BaseController
{
    private readonly IAnswerService answerService;

    public AnswerController(IAnswerService answerService)
    {
        this.answerService = answerService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(AnswerCreationDto dto)
    {
        var validation = Validator.IsValidText(dto.Javob);
        if (validation)
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.answerService.CreateAsync(dto)
            });

        return BadRequest("Invalid answer");
    }

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(AnswerUpdateDto dto)
    {
        var validation = Validator.IsValidText(dto.Javob);
        if (validation)
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.answerService.ModifyAsync(dto)
            });

        return BadRequest("Invalid answer");
    }

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.answerService.DeleteAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.answerService.GetByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.answerService.GetAllAsync()
        });

    [HttpGet("get-questinId")]
    public async Task<IActionResult> GetByQuestionIdAsync(long questionId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.answerService.GetByQuestionIdAsync(questionId)
        });
}
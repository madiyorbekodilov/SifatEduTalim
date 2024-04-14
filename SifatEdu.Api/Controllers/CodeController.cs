using SifatEdu.Api.Models;
using Microsoft.AspNetCore.Mvc;
using SifatEdu.Service.Interfaces;
using SifatEdu.Service.DTOs.CodeUchun;

namespace SifatEdu.Api.Controllers;

public class CodeController : BaseController
{
    private readonly ICodeuchunService service;

    public CodeController(ICodeuchunService service)
    {
        this.service = service;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(CodeUchunCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.CreateAsync(dto)
        });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(CodeUchunUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.ModifyAsync(dto)
        });

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

    [HttpGet("get")]
    public async Task<IActionResult> GetByQuestionIdAsync(long questionId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.GetByQuestionIdAsync(questionId)
        });
}
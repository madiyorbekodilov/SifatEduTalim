using Microsoft.AspNetCore.Mvc;
using SifatEdu.Api.Models;
using SifatEdu.Service.DTOs.Participate;
using SifatEdu.Service.Interfaces;

namespace SifatEdu.Api.Controllers;

public class ParticipateController : BaseController
{
    private readonly IParticipateService service;

    public ParticipateController(IParticipateService service)
    {
        this.service = service;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(ParticipateCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.CreateAsync(dto)
        });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(ParticipateUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.UpdateAsync(dto)
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

    [HttpGet("get-testId")]
    public async Task<IActionResult> GetByTestId(long testId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.GetByTestId(testId)
        });

    [HttpGet("get-userId")]
    public async Task<IActionResult> GetByUserId(long userId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.GetByUserId(userId)
        });
}
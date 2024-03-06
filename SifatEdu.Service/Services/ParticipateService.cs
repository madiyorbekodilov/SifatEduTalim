using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SifatEdu.Data.IRepasitories;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.DTOs.Participate;
using SifatEdu.Service.Exceptions;
using SifatEdu.Service.Interfaces;

namespace SifatEdu.Service.Services;

public class ParticipateService : IParticipateService
{
    private readonly IMapper mapper;
    private readonly IUserService userService;
    private readonly ITestService testService;
    private readonly IRepasitory<Participate> repasitory;

    public ParticipateService(IRepasitory<Participate> repasitory, IMapper mapper,
                                IUserService userService, ITestService testService)
    {
        this.mapper = mapper;
        this.repasitory = repasitory;
        this.userService = userService;
        this.testService = testService;
    }

    public async Task<ParticipateResultDto> CreateAsync(ParticipateCreationDto creationDto)
    {
        var mappedUser = this.mapper.Map<Participate>(creationDto);
        await this.repasitory.CreateAsync(mappedUser);
        await this.repasitory.SaveAsync();

        return this.mapper.Map<ParticipateResultDto>(mappedUser);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await this.repasitory.SelectAsync(x => x.Id == id);

        if (user is null)
            throw new NotFoundException("Participate not found");

        this.repasitory.Delete(user);
        await this.repasitory.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<ParticipateResultDto>> GetAllAsync()
    {
        var participates = await this.repasitory.SelectAll().ToListAsync();
        return this.mapper.Map<IEnumerable<ParticipateResultDto>>(participates);
    }

    public async Task<ParticipateResultDto> GetByIdAsync(long id)
    {
        var exisTester = await this.repasitory.SelectAsync(x => x.Id == id);

        if (exisTester is null)
            throw new NotFoundException("Test not found");

        return this.mapper.Map<ParticipateResultDto>(exisTester);
    }

    public async Task<IEnumerable<ParticipateResultDto>> GetByTestId(long testId)
    {
        var existest = await this.testService.GetByIdAsync(testId);

        if (existest is null)
            throw new NotFoundException("Test is invaid");

        var exisUser = this.repasitory.SelectAll(x => x.TesId == testId);

        return this.mapper.Map<IEnumerable<ParticipateResultDto>>(exisUser);

    }

    public async Task<IEnumerable<ParticipateResultDto>> GetByUserId(long userId)
    {
        var exisUser = await this.userService.RetrieveByIdAsync(userId);

        if (exisUser is null)
            throw new NotFoundException("User not found");

        var natijalar = this.repasitory.SelectAll(x => x.UserId == userId);

        return this.mapper.Map<IEnumerable<ParticipateResultDto>>(natijalar);
    }


    public async Task<ParticipateResultDto> UpdateAsync(ParticipateUpdateDto updateDto)
    {
        var exisUser = await this.repasitory.SelectAsync(x => x.Id == updateDto.Id);
        if (exisUser is null)
            throw new NotFoundException("Participate not found");

        this.mapper.Map(updateDto, exisUser);
        this.repasitory.Update(exisUser);
        await this.repasitory.SaveAsync();

        return this.mapper.Map<ParticipateResultDto>(exisUser); 
    }
}
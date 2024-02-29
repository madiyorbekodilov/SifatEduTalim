using AutoMapper;
using SifatEdu.Data.IRepasitories;
using SifatEdu.Domain.Configurations;
using SifatEdu.Domain.Entities;
using SifatEdu.Domain.Enums;
using SifatEdu.Service.DTOs.User;
using SifatEdu.Service.Exceptions;
using SifatEdu.Service.Helpers;
using SifatEdu.Service.Interfaces;

namespace SifatEdu.Service.Services;

public class UserService : IUserService
{
    public Task<bool> CheckUserAsync(string emailOrUsername, string password)
    {
        throw new NotImplementedException();
    }

    public Task<UserResultDto> CreateAsync(UserCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserResultDto> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UserResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserResultDto>> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserResultDto>> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<UserResultDto> ModifyPasswordAsync(long id, string oldPass, string newPass)
    {
        throw new NotImplementedException();
    }
}
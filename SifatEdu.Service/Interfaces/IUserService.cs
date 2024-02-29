﻿using SifatEdu.Service.DTOs.User;

namespace SifatEdu.Service.Interfaces;

public interface IUserService
{
    Task<bool> DeleteAsync(long id);
    Task<UserResultDto> GetByIdAsync(long id);
    Task<IEnumerable<UserResultDto>> GetAllAsync();
    Task<UserResultDto> GetByEmailAsync(string email);
    Task<UserResultDto> ModifyAsync(UserUpdateDto dto);
    Task<UserResultDto> CreateAsync(UserCreationDto dto);
    Task<IEnumerable<UserResultDto>> GetByName(string name);
    Task<bool> CheckUserAsync(string emailOrUsername, string password);
    Task<IEnumerable<UserResultDto>> GetByUsernameAsync(string username);
    Task<UserResultDto> ModifyPasswordAsync(long id, string oldPass, string newPass);
}
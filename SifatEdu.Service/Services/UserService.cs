using AutoMapper;
using SifatEdu.Domain.Enums;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.Helpers;
using SifatEdu.Service.DTOs.User;
using SifatEdu.Service.Exceptions;
using SifatEdu.Service.Extentions;
using SifatEdu.Data.IRepasitories;
using SifatEdu.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using SifatEdu.Domain.Configurations;

namespace SifatEdu.Service.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IRepasitory<User> userRepository;
    public UserService(IRepasitory<User> userRepository, IMapper mapper)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<UserResultDto> AddAsync(UserCreationDto dto)
    {
        User existUser = await this.userRepository.SelectAsync(u => u.Phone.Equals(dto.Phone));
        if (existUser is not null)
            throw new AlreadyExistException($"This user is already exists with phone = {dto.Phone}");

        var mappedUser = this.mapper.Map<User>(dto);
        mappedUser.Password = PasswordHasher.Hash(mappedUser.Password);
        await this.userRepository.CreateAsync(mappedUser);
        await this.userRepository.SaveAsync();


        var result = this.mapper.Map<UserResultDto>(mappedUser);
        return result;
    }

    public async Task<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        User existUser = await this.userRepository.SelectAsync(u => u.Email.Equals(dto.Email))
            ?? throw new NotFoundException($"This user is not found with ID = {dto.Email}");

        this.mapper.Map(dto, existUser);
        this.userRepository.Update(existUser);
        await this.userRepository.SaveAsync();

        var result = this.mapper.Map<UserResultDto>(existUser);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        User existUser = await this.userRepository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new NotFoundException($"This user is not found with ID = {id}");

        this.userRepository.Delete(existUser);
        await this.userRepository.SaveAsync();
        return true;
    }

    public async Task<UserResultDto> RetrieveByIdAsync(long id)
    {
        User existUser = await this.userRepository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new NotFoundException($"This user is not found with ID = {id}");

        var result = this.mapper.Map<UserResultDto>(existUser);
        return result;
    }

    public async Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var users = await this.userRepository.SelectAll()
                            .ToPaginate(@params)
                            .OrderBy(filter)
                            .ToListAsync();
                            

        var result = users.Where(user => user.FirsName.Contains(search, StringComparison.OrdinalIgnoreCase));
        var mappedUsers = this.mapper.Map<List<UserResultDto>>(result);
        return mappedUsers;
    }

    public async Task<IEnumerable<UserResultDto>> RetrieveAllAsync()
    {
        var users = await this.userRepository.SelectAll()
            .ToListAsync();
        var result = this.mapper.Map<IEnumerable<UserResultDto>>(users);
        return result;
    }

    public async Task<UserResultDto> UpgradeRoleAsync(long id, UserRole role)
    {
        User existUser = await this.userRepository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new NotFoundException($"This user is not found with ID = {id}");

        existUser.Role = role;
        await this.userRepository.SaveAsync();

        var result = this.mapper.Map<UserResultDto>(existUser);
        return result;
    }
}
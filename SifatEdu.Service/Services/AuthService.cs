using System.Text;
using System.Security.Claims;
using SifatEdu.Domain.Entities;
using SifatEdu.Service.Helpers;
using SifatEdu.Data.IRepasitories;
using SifatEdu.Service.Exceptions;
using SifatEdu.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace SifatEdu.Service.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration configuration;
    private readonly IRepasitory<User> userRepository;
    public AuthService(IRepasitory<User> userRepository, IConfiguration configuration)
    {
        this.configuration = configuration;
        this.userRepository = userRepository;
    }

    public async Task<string> GenerateTokenAsync(string phone, string originalPassword)
    {
        var user = await this.userRepository.SelectAsync(u => u.Email.Equals(phone));
        if (user is null)
            throw new NotFoundException("This user is not found");

        bool verifiedPassword = PasswordHasher.Verify(originalPassword,user.Password);
        if (!verifiedPassword)
            throw new CustomException(400, "Phone or password is invalid");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim("Email", user.Email),
                 new Claim("Id", user.Id.ToString()),
                 new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
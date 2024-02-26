using SifatEdu.Domain.Enums;

namespace SifatEdu.Service.DTOs.User;

public class UserCreationDto
{
    public string FirsName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public UserRole Role { get; set; }
    public DateTime DateOfBirth { get; set; }
}

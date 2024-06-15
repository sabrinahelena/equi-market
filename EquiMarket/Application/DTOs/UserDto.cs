namespace Application.DTOs;

public class UserDto
{
    public string Name { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
    public DateTime BirthDate { get; init; }
}

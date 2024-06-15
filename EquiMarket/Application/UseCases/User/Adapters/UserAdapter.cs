using Application.DTOs;
using Application.UseCases.User.Commands.Update;

namespace Application.UseCases.User.Adapters;

public static class UserAdapter
{
    public static Domain.AggregatesModel.UserModel.User Map(this UpdateUserCommand dto)
    {
        return new Domain.AggregatesModel.UserModel.User
        {
            Id = dto.UserId,
            BirthDate = dto.BirthDate,
            UpdatedAt = DateTime.UtcNow,
            Email = dto.Email,
            Name = dto.Name,
            Password = dto.Password,
            Type = dto.Type
        };
    }

    public static UserDto Map(this Domain.AggregatesModel.UserModel.User user)
    {
        return new UserDto
        {
            Email = user.Email,
            Name = user.Name,
            BirthDate = user.BirthDate
        };
    }
}

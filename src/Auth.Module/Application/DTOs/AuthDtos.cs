namespace Auth.Module.Application.DTOs;

public record RegisterUserDto(
    string Email,
    string Password,
    string Name
);

public record LoginDto(
    string Email,
    string Password
);

public record AuthResultDto(
    Guid UserId,
    string Email,
    string Name,
    string Token
);

using Auth.Module.Application.DTOs;
using Auth.Module.Domain.Ports;

namespace Auth.Module.Application.UseCases;

public class LoginUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUseCase(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthResultDto> ExecuteAsync(LoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null)
            throw new InvalidOperationException("Invalid credentials");

        if (!_passwordHasher.Verify(dto.Password, user.PasswordHash))
            throw new InvalidOperationException("Invalid credentials");

        if (!user.IsActive)
            throw new InvalidOperationException("User is inactive");

        return new AuthResultDto(user.Id, user.Email, user.Name, "token-placeholder");
    }
}

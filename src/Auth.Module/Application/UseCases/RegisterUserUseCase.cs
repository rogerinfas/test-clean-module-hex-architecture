using Auth.Module.Application.DTOs;
using Auth.Module.Domain.Entities;
using Auth.Module.Domain.Ports;

namespace Auth.Module.Application.UseCases;

public class RegisterUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserUseCase(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthResultDto> ExecuteAsync(RegisterUserDto dto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
        if (existingUser != null)
            throw new InvalidOperationException("User already exists");

        var passwordHash = _passwordHasher.Hash(dto.Password);
        var user = new User(dto.Email, passwordHash, dto.Name);
        
        await _userRepository.AddAsync(user);

        return new AuthResultDto(user.Id, user.Email, user.Name, "token-placeholder");
    }
}

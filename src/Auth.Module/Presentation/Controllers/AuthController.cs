using Auth.Module.Application.DTOs;
using Auth.Module.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Module.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly RegisterUserUseCase _registerUseCase;
    private readonly LoginUseCase _loginUseCase;

    public AuthController(RegisterUserUseCase registerUseCase, LoginUseCase loginUseCase)
    {
        _registerUseCase = registerUseCase;
        _loginUseCase = loginUseCase;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResultDto>> Register([FromBody] RegisterUserDto dto)
    {
        var result = await _registerUseCase.ExecuteAsync(dto);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResultDto>> Login([FromBody] LoginDto dto)
    {
        var result = await _loginUseCase.ExecuteAsync(dto);
        return Ok(result);
    }
}

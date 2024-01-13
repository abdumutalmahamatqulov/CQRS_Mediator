using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityDbContext1.Services;
using Microsoft.AspNetCore.Authorization;
using CQRS_Mediator.Dto_s;
using CQRS_Mediator.Models;
using CQRS_Mediator.CreateToken;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using CQRS_Mediator.Models.LoginViewModel;
using CQRS_Mediator.Models.RegisterViewModel;

namespace IdentityDbContext1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("ListUsers"), Authorize]
    public async Task<IActionResult> GetAllUsers() => Ok(await _authService.UserList());

    [HttpPost("register")]
    [ProducesResponseType(typeof(User), 200)]
    [ProducesResponseType(typeof(List<string>), 400)]
    public async Task<IActionResult> Register(RegisterViewModel request)
    {
        var model = await _authService.Register(request);
        if (model == null)
        {
            return BadRequest("password or email is mistake");
        }
        return Ok(model);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginViewModel request)
    {
        var token = await _authService.Login(request);
        return Ok(new { token = token });
    }

}

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using CQRS_Mediator.Data;
using CQRS_Mediator.Dto_s;
using CQRS_Mediator.Models;
using CQRS_Mediator.CreateToken;
using CQRS_Mediator.FluentValidation;
using CQRS_Mediator.Models.LoginViewModel;
using CQRS_Mediator.Models.RegisterViewModel;

namespace IdentityDbContext1.Services;
public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, AppDbContext context)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _context = context;
    }

    public async Task<User> Register(RegisterViewModel request)
    {
        var user = new User
        {
            UserName= request.Username,
            Email = request.Email,
        };
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return null;            

        }

        await _userManager.AddToRoleAsync(user, Enum.GetName(request.Role).ToUpper());
        await _context.SaveChangesAsync();
        return user;
    }
     
    public async Task<string> Login(LoginViewModel request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Email == request.Email);

        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
            /*  roleClaims.Add(new Claim(ClaimTypes.Email, request.Email));*/
            string token = CreateTokenInJwtAuthorizationFromUsers.CreateToken(user, roleClaims);

            return token;
        }

        throw new BadHttpRequestException("User not Found=> Foydalanuvchi topilmadi");
    }

    public async Task<List<User>> UserList() => await _context.Users.ToListAsync();
}

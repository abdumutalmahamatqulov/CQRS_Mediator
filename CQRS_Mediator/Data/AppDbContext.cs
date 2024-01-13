using CQRS_Mediator.Dto_s;
using CQRS_Mediator.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Mediator.Data;

public class AppDbContext :IdentityDbContext<User>
{
    private IServiceProvider services;
    public AppDbContext(DbContextOptions<AppDbContext>options, IServiceProvider services) :base(options) { this.Service = services; }
    public IServiceProvider Service { get; set; }

    public DbSet<Student> Students { get; init; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration<IdentityRole>(new RoleConfiguration(Service));
    }
}

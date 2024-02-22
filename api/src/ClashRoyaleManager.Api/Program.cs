using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Infraestructure.DbContexts;
using ClashRoyaleManager.Infraestructure.Repositories;
using ClashRoyaleManager.Infraestructure.Services;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

builder.Services.AddDbContext<DefaultDbContext>(
    cfg => cfg.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"))
);

/// DependencyInjection ///
{
builder.Services.AddScoped<IEncryptService, EncryptService>()
                .AddScoped<DefaultDbContext>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IClanRepository, ClanRepository>()
                .AddScoped<IPlayerRepository, PlayerRepository>();
}

var app = builder.Build();

app.UseFastEndpoints();

app.Run();

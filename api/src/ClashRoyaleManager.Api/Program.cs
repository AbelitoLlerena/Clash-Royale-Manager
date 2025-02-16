using ClashRoyaleManage.Api.Auth;
using ClashRoyaleManage.Infraestructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using FastEndpoints;
using ClashRoyaleManager.Application.Query.Clans;
using ClashRoyaleManage.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

/// DependencyInjection ///
{
    builder.Services        
        .AddInfrastructure(builder.Configuration)
        .ConfigureAutheticationServices(builder.Configuration);
}

var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseCors("MyPolicy");

    app.UseFastEndpoints(c => {
        c.Endpoints.RoutePrefix = "api";
    });

    app.UseHttpsRedirection();
    
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseStatusCodePages();

    app.Run();
}

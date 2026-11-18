using Lab10.Application.UseCases.ResponseUseCase;
using Lab10.Application.UseCases.RoleUseCase;
using Lab10.Application.UseCases.TicketUseCase;
using Lab10.Application.UseCases.UserUseCase;
using Lab10.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab10.Api.Configuration;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. Infraestructura (DbContext, Repositorios, UnitOfWork)
        services.AddInfrastructureServices(configuration);

        // 2. Registrar Use Cases (Aplicación)
        // Tickets
        services.AddScoped<AddTicketUseCase>();
        services.AddScoped<GetAllTicketsUseCase>();
        services.AddScoped<GetTicketByIdUseCase>();

        // Users
        services.AddScoped<AddUserUseCase>();
        services.AddScoped<GetAllUsersUseCase>();

        // Roles
        services.AddScoped<AddRoleUseCase>();
        services.AddScoped<GetAllRolesUseCase>();

        // Responses
        services.AddScoped<AddResponseUseCase>();
        services.AddScoped<GetResponsesByTicketIdUseCase>();

        // 3. Controladores y Swagger
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
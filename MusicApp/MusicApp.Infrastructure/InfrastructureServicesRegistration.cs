using Microsoft.Extensions.DependencyInjection;
using MusicApp.Application.Abstractions.Services;
using MusicApp.Infrastructure.Implementations.Services;
using MusicApp.Infrastructure.Implementations.Services.BackgroundServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IOTPService, OTPService>();
        services.AddHostedService<ExpiredOTPCleanupService>();
        services.AddHostedService<ExpiredRefreshTokenCleanupService>();




        return services;
    }
}

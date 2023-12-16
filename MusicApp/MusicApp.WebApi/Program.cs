using Microsoft.AspNetCore.Authentication.Cookies;
using MusicApp.Application;
using MusicApp.Application.Abstractions.Services;
using MusicApp.Infrastructure;
using MusicApp.Persistence;
using MusicApp.WebApi;
using MusicApp.WebApi.Implementations.Services;
using MusicApp.WebApi.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var allowedOrigins = config["AllowedOrigins"].Split(',');

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins(allowedOrigins)
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});


builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(config);
builder.Services.AddApiServices(config);

var app = builder.Build();

app.UseMiddleware<JwtCookieMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
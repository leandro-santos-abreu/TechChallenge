using Agenda.Api.Extensions;
using Agenda.Api.Middlewares;
using Agenda.Domain.EntitiesAbstractions.EntitiesDto;
using Agenda.Infrastructure.Extensions;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<UserDto>();
        fv.RegisterValidatorsFromAssemblyContaining<ContactDto>();
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

DependencyInjection.ApplyDependencyInjection(builder);

var app = builder.Build();

app.UseAuthenticationMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Validators;
using SocialMedia.CrossCutting.DependencyInjection;
using SocialMedia.Infrastructure.Context;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = "Host=localhost;Port=5432;Database=SocialMedia;Username=docker;Password=docker";

    options.UseNpgsql(connectionString!, x =>
    {
        x.MigrationsAssembly("SocialMedia.Infrastructure");
    });
});

builder.Services.AddValidatorsFromAssembly(typeof(CreatePostValidator).Assembly);

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddFactories();
builder.Services.AddEvents();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

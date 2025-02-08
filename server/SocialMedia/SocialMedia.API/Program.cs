using Microsoft.EntityFrameworkCore;
using SocialMedia.CrossCutting.DependencyInjection;
using SocialMedia.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = "Host=localhost;Port=5432;Database=SocialMedia;Username=docker;Password=docker";

    options.UseNpgsql(connectionString!, x =>
    {
        x.MigrationsAssembly("SocialMedia.Infrastructure");
    });
});

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

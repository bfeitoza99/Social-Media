using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Validators;
using SocialMedia.CrossCutting.DependencyInjection;
using SocialMedia.Infrastructure.Context;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

var connectionString =  Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING") 
            ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();
app.UseCors("AllowAll");

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AddMigrations(app);

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddMigrations(WebApplication app)
{
    using (var serviceScope = app.Services.CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

        context.Database.Migrate();
    }
}
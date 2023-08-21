using FluentValidation;

using Microsoft.EntityFrameworkCore;

using ModernisationChallengeApi.Data;
using ModernisationChallengeApi.Services.Task;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// EF core context
builder.Services.AddDbContext<ModernisationChallengeContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("ModernisationChallenge")
            ?? throw new InvalidOperationException("Connection string 'ModernisationChallenge' not found.")
        )
);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS configurations. Should not allow anything in real life app
builder.Services.AddCors(
    options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            }
        );
    }
);

// Register services in app
builder.Services.AddValidatorsFromAssemblyContaining<Program>(); // Register FluentValidator profiles
builder.Services.AddAutoMapper(typeof(Program)); // Register AutoMapper

builder.Services.AddScoped<ITaskService, TaskService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

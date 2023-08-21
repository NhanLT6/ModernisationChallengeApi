using Microsoft.EntityFrameworkCore;

using ModernisationChallengeApi.Data;
using ModernisationChallengeApi.Services.Task;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ModernisationChallengeContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("ModernisationChallengeContext")
            ?? throw new InvalidOperationException("Connection string 'ModernisationChallengeContext' not found.")
        )
);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services in app
builder.Services.AddScoped<ITaskService, TaskService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

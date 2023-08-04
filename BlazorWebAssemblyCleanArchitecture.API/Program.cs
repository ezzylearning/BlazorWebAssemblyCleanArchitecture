using BlazorWebAssemblyCleanArchitecture.Application.Extensions;
using BlazorWebAssemblyCleanArchitecture.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

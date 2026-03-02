using backend.Domain.Entities;
using backend.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;  // For builder.Services
using Microsoft.Extensions.Configuration;       // For Configuration

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Services
// --------------------

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --------------------
// Middleware
// --------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = string.Empty; // Swagger at root
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PageService v1");
    });
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// --------------------
// Auto-apply migrations
// --------------------

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
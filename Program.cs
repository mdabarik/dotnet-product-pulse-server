using Microsoft.EntityFrameworkCore;
using ProductPulseServer.Application.Interfaces;
using ProductPulseServer.Application.Services;
using ProductPulseServer.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// builder.Services.AddDbContext<AppDbContext>(options =>
//     // options.UseMySql(
//     //     builder.Configuration.GetConnectionString("DefaultConnection"),
//     //     new MySqlServerVersion(new Version(8, 0, 33))
//     // )
// );

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

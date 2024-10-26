using Microsoft.EntityFrameworkCore;
using Api_redes.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TuDbContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("CadenaSQL");
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 22)); // Cambia a la versión de tu servidor MySQL
    opt.UseMySql(connectionString, serverVersion);
});

var app = builder.Build();



// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

 app.UseSwagger();
    app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();

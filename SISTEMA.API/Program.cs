using BLL.Validaciones;
using SISTEMA.API.DBContextDapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddSingleton<DapperCNN>();
builder.Services.AddSingleton<ClientesValidaciones>();

var app = builder.Build();


//IMPORTACI�N PARA LA BASE DE DATOS
builder.Configuration.AddJsonFile("appsettings.json");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

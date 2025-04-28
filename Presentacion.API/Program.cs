
using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Dominio.Repositorios;
using Infraestuctura.Contexto;
using Infraestuctura.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IPersonaServicio, PersonaServicio>();
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();


//Conexión a BD
builder.Services.AddDbContext<ContextoDB>(options =>
{
    var connectionString = "Server=localhost;Database=TareaDDD;Trusted_Connection=True;TrustServerCertificate=True";
    options.UseSqlServer(connectionString);
});





var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();
// Configure CORS para permitir solicitudes desde cualquier origen
// Puedes ajustar AllowAnyOrigin, AllowAnyMethod y AllowAnyHeader según tus necesidades
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
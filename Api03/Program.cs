using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers(); // Habilita el uso de controladores
builder.Services.AddEndpointsApiExplorer(); // Habilita la exploraci�n de puntos finales
builder.Services.AddSwaggerGen(); // Habilita Swagger para la documentaci�n de la API

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita Swagger en desarrollo
    app.UseSwaggerUI(); // Habilita la interfaz de usuario de Swagger
}

app.UseHttpsRedirection(); // Redirige a HTTPS
app.UseAuthorization(); // Habilita la autorizaci�n
app.MapControllers(); // Mapea los controladores

app.Run(); // Inicia la aplicaci�n

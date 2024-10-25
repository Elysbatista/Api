using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers(); // Habilita el uso de controladores
builder.Services.AddEndpointsApiExplorer(); // Habilita la exploración de puntos finales
builder.Services.AddSwaggerGen(); // Habilita Swagger para la documentación de la API

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita Swagger en desarrollo
    app.UseSwaggerUI(); // Habilita la interfaz de usuario de Swagger
}

app.UseHttpsRedirection(); // Redirige a HTTPS
app.UseAuthorization(); // Habilita la autorización
app.MapControllers(); // Mapea los controladores

app.Run(); // Inicia la aplicación

using GestionDeUsuarios_App.Data;
using GestionDeUsuarios_App.Services;
using GestionDeUsuarios_App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexi�n a la base de datos
// GestionDeUsuarios_App/Program.cs
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Resto de la configuraci�n
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Registrar servicios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();

// Configurar el pipeline de la aplicaci�n
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

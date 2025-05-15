using AppCrudMinerd.Application.Interfaces.Repositories;
using AppCrudMinerd.Application.Interfaces.Services;
using AppCrudMinerd.Application.Services;
using AppCrudMinerd.Persistence.Context;
using AppCrudMinerd.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar Kestrel para escuchar en todas las IPs (0.0.0.0)
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5293);
});

// 1) Registrar el DbContext
builder.Services.AddDbContext<AppCrudMinerdContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2) Registrar repositorio y servicio
builder.Services.AddScoped<IDataMinerdRepository, DataMinerdRepository>();
builder.Services.AddScoped<IDataMinerdService, DataMinerdService>();

// ────── Configuración de CORS ──────
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyFrontend", policy =>
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});
// ────────────────────────────────────

// 3) Registrar controllers y swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4) Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ────── Activar CORS ──────
app.UseCors("AllowMyFrontend");
// ─────────────────────────

app.UseAuthorization();

// 5) Mapear controllers
app.MapControllers();

app.Run();

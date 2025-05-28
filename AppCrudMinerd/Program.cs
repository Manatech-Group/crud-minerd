using AppCrudMinerd.Application.Interfaces.Repositories;
using AppCrudMinerd.Application.Interfaces.Services;
using AppCrudMinerd.Application.Services;
using AppCrudMinerd.Persistence.Context;
using AppCrudMinerd.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ─── Configuración de Kestrel ─────────────────────────────────────────────
builder.WebHost.ConfigureKestrel(opts =>
{
    opts.ListenAnyIP(5293);
    opts.ListenLocalhost(7206, lo => lo.UseHttps());
});
// ────────────────────────────────────────────────────────────────────────────

// 1) DbContext
builder.Services.AddDbContext<AppCrudMinerdContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2) Repositorios y servicios
builder.Services.AddScoped<IDataMinerdRepository, DataMinerdRepository>();
builder.Services.AddScoped<IDataMinerdService, DataMinerdService>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceService, DeviceService>();

// 3) CORS
builder.Services.AddCors(o =>
    o.AddPolicy("AllowMyFrontend", p =>
        p.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader()
    )
);

// 4) Controllers + Swagger
builder.Services.AddControllers();

// Este registra el generador de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AppCrudMinerd API",
        Version = "v1"
    });
});

var app = builder.Build();

// ─── Middleware ─────────────────────────────────────────────────────────────
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppCrudMinerd API v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowMyFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();

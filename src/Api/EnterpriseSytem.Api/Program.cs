using EnterpriseSystem.Module.Identity.Application;
using EnterpriseSystem.Module.Identity.Infraestructure;
using EnterpriseSystem.Module.Identity.Infraestructure.Security;
using EnterpriseSystem.Shared.Exceptions.Handler;
using EnterpriseSystem.Shared.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// =======================================
// CONFIGURACIÓN
// =======================================

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

// =======================================
// SERVICIOS (ANTES DE Build)
// =======================================

// MediatR (Application)
builder.Services.AddMediatRWithAssemblies(
    typeof(IdentityApplicationAssemblyMarker).Assembly
);

// Infrastructure
builder.Services.AddIdentityInfrastructure(connectionString);

// Controllers + OpenAPI
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// JWT Options (Binding appsettings)
builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("Jwt"));

//  Authentication + JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        var jwtOptions = builder.Configuration
            .GetSection("Jwt")
            .Get<JwtOptions>();

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtOptions!.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOptions.Key))
        };
    });

builder.Services.AddAuthorization();

// =======================================
// BUILD (PUNTO DE NO RETORNO)
// =======================================

var app = builder.Build();

// =======================================
// PIPELINE
// =======================================

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Migraciones automáticas (esto SÍ va después de Build)
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider
//        .GetRequiredService<IdentityDbContext>();

//    db.Database.Migrate();
//}
builder.Services
    .AddExceptionHandler<CustomExceptionHandler>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using EnterpriseSystem.Module.Identity;
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

// COMMON SERVICES
var identityAssembly = typeof(IdentityModule).Assembly;


builder.Services
    .AddMediatRWithAssemblies(identityAssembly);


builder.Services.AddIndentityModule(builder.Configuration);



// Controllers + OpenAPI
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// JWT Options
builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("Jwt"));

// Authentication + JWT
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

//  Exception Handler
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddProblemDetails();

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

// Middleware del exception handler
app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
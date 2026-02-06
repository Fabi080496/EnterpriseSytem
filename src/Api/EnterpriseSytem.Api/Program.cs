using EnterpriseSystem.Module.Identity.Application;
using EnterpriseSystem.Shared.Extension;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddIdentityModule(connectionString);


// Registrar MediatR con todos los módulos
builder.Services.AddMediatRWithAssemblies(
    typeof(IdentityModule).Assembly
//, typeof(UsersModule).Assembly // agregar más módulos aquí
);

builder.Services.AddControllers();
builder.Services.AddOpenApi();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Aplicar migraciones automáticamente
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
//    db.Database.Migrate();
//}

app.UseAuthorization();
app.MapControllers();

app.Run();

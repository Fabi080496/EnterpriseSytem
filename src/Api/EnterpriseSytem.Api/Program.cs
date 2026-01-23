var builder = WebApplication.CreateBuilder(args);

// 🚪 Railway: puerto dinámico
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

// Servicios
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// ❌ NO usar UseHttpsRedirection en Railway
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

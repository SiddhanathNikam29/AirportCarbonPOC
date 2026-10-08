using AirportCarbonPOC.Api.Data;
using AirportCarbonPOC.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();   // ✅ Kept — now works with correct package versions

builder.Services.AddSingleton<SyntheticDataProvider>();
builder.Services.AddScoped<EmissionService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
        policy.WithOrigins(
                "http://localhost:3000",
                "https://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReact");
app.UseAuthorization();

// Root endpoint — redirects to Swagger in Development
app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapControllers();

app.Run();
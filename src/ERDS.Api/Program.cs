using ERDS.Application;
using ERDS.Infrastructure;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting ERDS vNext API");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .WriteTo.Console());

    // OpenAPI / Swagger
    builder.Services.AddOpenApi();

    // Controllers
    builder.Services.AddControllers();

    // Health checks
    builder.Services.AddHealthChecks();

    // Application layer (MediatR, FluentValidation)
    builder.Services.AddApplication();

    // Infrastructure layer (EF Core, services)
    builder.Services.AddInfrastructure(builder.Configuration);

    // CORS for React dev server
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("DevCors", policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
    });

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseCors("DevCors");
    }

    app.UseHttpsRedirection();

    app.MapControllers();
    app.MapHealthChecks("/health");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

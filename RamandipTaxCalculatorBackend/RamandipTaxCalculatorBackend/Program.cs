using RamandipTaxCalculatorBackend.Services;
using Microsoft.EntityFrameworkCore;
using RamandipTaxCalculatorBackend.Data;
using RamandipTaxCalculatorBackend.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register the DbContext
builder.Services.AddDbContext<TaxDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the Repository and Service
builder.Services.AddScoped<ITaxBandRepository, TaxBandRepository>();
builder.Services.AddScoped<ITaxCalculationService, TaxCalculationService>();

// Register controllers
builder.Services.AddControllers();

// Register Swagger services for API documentation
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Enable Swagger middleware
    app.UseSwaggerUI();  // Enable Swagger UI for API testing
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

app.Run();

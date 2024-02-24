using AykhanWebApplication;
using AykhanWebApplication.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Azure") ?? throw new InvalidOperationException("Connection string 'Azure' not found.");
builder.Services.AddDbContext<SqldatabaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(builder =>
{
	builder.WithOrigins("http://localhost:3000", "http://localhost:3001")
		.AllowAnyHeader()
		.AllowAnyMethod()
		.AllowCredentials();
});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
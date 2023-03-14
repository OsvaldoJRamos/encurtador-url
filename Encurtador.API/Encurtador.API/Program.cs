using Encurtador.API.Configuration;
using Encurtador.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var defaultCors = "defaultCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: defaultCors,
                      builder =>
                      {
                          builder.WithOrigins("https://encurtador.app",
                                              "http://localhost:4200",
                                              "https://localhost:4200")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EncurtadorContext>(options =>
                                                 options.UseSqlite(connectionString));

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(defaultCors);

app.UseAuthorization();

app.MapControllers();

app.Run();

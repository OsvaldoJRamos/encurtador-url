using Encurtador.API.Configuration;
using Encurtador.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

bool useSqLite = false;

if (useSqLite)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionSqLite");
    builder.Services.AddDbContext<EncurtadorContext>(options => options.UseSqlite(connectionString));
}
else
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionMySql");
    builder.Services.AddDbContext<EncurtadorContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(
            new Version(8, 0, 29))));

}

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors(defaultCors);

app.UseAuthorization();

app.MapControllers();

app.Run();

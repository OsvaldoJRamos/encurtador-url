using Encurtador.Data.Repositories.Interfaces;
using Encurtador.Data.Repositories;
using Encurtador.Service;
using Microsoft.Extensions.DependencyInjection;
using Encurtador.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Encurtador.Domain.Dtos.Request;

namespace Encurtador.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = new SqliteConnection("DataSource=:memory:");

            connection.Open();
            var options = new DbContextOptionsBuilder<EncurtadorContext>()
                           .UseSqlite(connection)
                           .Options;

            var dbContext = new EncurtadorContext(options);
            dbContext.Database.EnsureCreated();            

            services.AddScoped<IEncurtarRepository>(a => new EncurtarRepository(dbContext));
            services.AddScoped<IEncurtarService, EncurtarService>();

        }
    }
}
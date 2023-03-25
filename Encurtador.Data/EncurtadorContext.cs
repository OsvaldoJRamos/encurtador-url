using Encurtador.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Encurtador.Data
{
    public class EncurtadorContext : DbContext
    {
        public EncurtadorContext(DbContextOptions<EncurtadorContext> options) : base(options)
        {

        }

        public virtual DbSet<Encurtado> Encurtado { get; set; }
        public virtual DbSet<Click> Click { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

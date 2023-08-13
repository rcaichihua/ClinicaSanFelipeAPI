using ClinicaSanFelipeAPI.Configuration;
using ClinicaSanFelipeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaSanFelipeAPI.Data
{
	public class ClinicaSFDbContext:DbContext
	{
		public ClinicaSFDbContext(
            DbContextOptions<ClinicaSFDbContext> options) : base(options)
		{
		}
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Para schema
            modelBuilder.HasDefaultSchema("farmacia");
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ProductoConfiguration(modelBuilder.Entity<Producto>());
        }
    }
}


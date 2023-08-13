using ClinicaSanFelipeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaSanFelipeAPI.Configuration
{
	public class ProductoConfiguration
	{
		public ProductoConfiguration(EntityTypeBuilder<Producto> entityBuilder)
		{
			entityBuilder.HasKey(e => e.IdProducto);
			entityBuilder.Property(e => e.DescripcionProducto)
				.IsRequired()
				.HasMaxLength(150);
			entityBuilder.Property(e => e.PrecioCompra)
				.IsRequired()
				.HasPrecision(10, 2);
            entityBuilder.Property(e => e.FecRegistro)
            .IsRequired()
			.HasDefaultValueSql("GETDATE()");
			entityBuilder.HasIndex(e => e.DescripcionProducto)
				.HasDatabaseName("IX_DescripcionProducto");
        }
	}
}


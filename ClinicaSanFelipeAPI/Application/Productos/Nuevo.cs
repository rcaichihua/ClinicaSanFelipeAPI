using ClinicaSanFelipeAPI.Data;
using ClinicaSanFelipeAPI.Models;
using MediatR;

namespace ClinicaSanFelipeAPI.Application.Productos
{
	public class Nuevo
	{
		public class Ejecuta : IRequest
		{
            public string? DescripcionProducto { get; set; }
            public double PrecioCompra { get; set; }
            public DateTime FechaLote { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ClinicaSFDbContext _context;
            public Manejador(ClinicaSFDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto = new Producto
                {
                    DescripcionProducto = request.DescripcionProducto,
                    PrecioCompra = request.PrecioCompra,
                    FechaLote = request.FechaLote
                };
                _context.Productos.Add(producto);
                var valor = await _context.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el producto.");
            }
        }
    }
}


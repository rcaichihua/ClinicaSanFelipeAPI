using System;
using ClinicaSanFelipeAPI.Data;
using MediatR;

namespace ClinicaSanFelipeAPI.Application.Productos
{
	public class Editar
	{
		public class EjecutaE : IRequest
		{
            public int IdProducto { get; set; }
            public string? DescripcionProducto { get; set; }
            public double? PrecioCompra { get; set; }
            public DateTime? FechaLote { get; set; }
        }
        public class Manejador : IRequestHandler<EjecutaE>
        {
            private readonly ClinicaSFDbContext _context;
            public Manejador(ClinicaSFDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(EjecutaE request, CancellationToken cancellationToken)
            {              
                var producto = await _context.Productos.FindAsync(request.IdProducto) ?? throw new Exception("El producto no existe");
                producto.DescripcionProducto = request.DescripcionProducto ?? producto.DescripcionProducto;
                producto.PrecioCompra = request.PrecioCompra ?? producto.PrecioCompra;
                producto.FechaLote = request.FechaLote ?? producto.FechaLote;

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se puede guardar el producto");
            }
        }
	}
}


using System;
using ClinicaSanFelipeAPI.Data;
using ClinicaSanFelipeAPI.Models;
using MediatR;

namespace ClinicaSanFelipeAPI.Application.Productos
{
	public class ConsultaId
	{
		public class ProductoUnico : IRequest<Producto>
		{
			public int Id { get; set; }
		}

		public class Manejador : IRequestHandler<ProductoUnico, Producto>
		{
			private readonly ClinicaSFDbContext _context;
			public Manejador(ClinicaSFDbContext context)
			{
				_context = context;
			}

            public async Task<Producto> Handle(ProductoUnico request, CancellationToken cancellationToken)
            {
				var producto = await _context.Productos.FindAsync(request.Id);
				return producto;
            }
        }
	}
}


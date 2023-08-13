using ClinicaSanFelipeAPI.Data;
using ClinicaSanFelipeAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicaSanFelipeAPI.Application.Productos
{
	public class Consulta
	{
        public class ListaProductos : IRequest<List<Producto>> {

        }
        public class Manejador : IRequestHandler<ListaProductos, List<Producto>>
        {
            private readonly ClinicaSFDbContext _context;
            public Manejador(ClinicaSFDbContext context)
            {
                _context = context;
            }

            public async Task<List<Producto>> Handle(ListaProductos request, CancellationToken cancellationToken)
            {
                var productos = await _context.Productos.ToListAsync();
                return productos;
            }
        }
    }
}


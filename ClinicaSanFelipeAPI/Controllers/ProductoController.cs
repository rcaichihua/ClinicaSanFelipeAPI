using ClinicaSanFelipeAPI.Application.Productos;
using ClinicaSanFelipeAPI.Data;
using ClinicaSanFelipeAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSanFelipeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController:ControllerBase
	{
		private readonly IMediator _mediator;
		public ProductoController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<ActionResult<List<Producto>>> Get()
		{
			return await _mediator.Send(new Consulta.ListaProductos());
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Producto>> GetId(int id)
		{ 
			return await _mediator.Send(new ConsultaId.ProductoUnico{Id = id});
		}
		[HttpPost]
		public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta ejecuta)
		{
			return await _mediator.Send(ejecuta);
		}
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id, Editar.EjecutaE ejecuta)
        {
			ejecuta.IdProducto = id;
            return await _mediator.Send(ejecuta);
        }
    }
}


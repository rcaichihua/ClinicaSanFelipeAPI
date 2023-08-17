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
		public async Task<ActionResult<EstructuraEntrega>> Get()
		{
			var productos = await _mediator.Send(new Consulta.ListaProductos());

            return new EstructuraEntrega
            {
                mensaje = "ok",
                lista = productos,
                producto = null,
            }; 
        }
		[HttpGet("{id}")]
		public async Task<ActionResult<EstructuraEntrega>> GetId(int id)
		{ 
			var producto = await _mediator.Send(new ConsultaId.ProductoUnico { Id = id });
            return new EstructuraEntrega
            {
                mensaje = "ok",
                lista = null,
                producto = producto,
            };
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


using System.IO;
using ClinicaSanFelipeAPI.Application.Productos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSanFelipeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExportarDocumentoController: ControllerBase
    {
        private readonly IMediator _mediator;
        public ExportarDocumentoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<Stream>> GetTask()
        {
            return await _mediator.Send(new ExportPDF.Consulta());
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using NURBNB.Alojamiento.Application.UseCases.Transacciones.Command.CrearTransaccion;
using NURBNB.Alojamiento.Application.UseCases.Transacciones.Query;

namespace NURBNB.Alojamiento.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransaccionController : ControllerBase
	{
		private readonly IMediator _mediator;
		public TransaccionController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[Route("CrearTransaccion")]
		public async Task<IActionResult> CrearTransaccion([FromBody] CrearTransaccionCommand command)
		{
			try
			{
				var transaccionId = await _mediator.Send(command);
				return Ok(transaccionId);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("ListarTransacciones")]
		public async Task<IActionResult> ListarTransacciones()
		{
			var items = await _mediator.Send(new IGetTransaccionList()
			{
			});

			return Ok(items);
		}

		[HttpGet]
		[Route("ListarTransaccionesReserva")]
		public async Task<IActionResult> ListarTransaccionesReserva(Guid reservaId)
		{
			var items = await _mediator.Send(new IGetTransaccionFilterByReservaList()
			{
				ReservaId = reservaId
			});

			return Ok(items);
		}
	}
}

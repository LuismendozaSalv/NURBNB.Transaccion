using MediatR;
using NURBNB.Alojamiento.Application.Dto.Transacciones;
using NURBNB.Alojamiento.Application.UseCases.Transacciones.Query;
using NURBNB.Alojamiento.Domain.Model.Transaccion;
using NURBNB.Alojamiento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.UsesCases.Transacciones.Query
{
	public class GetTransaccionFilterByReservaListHandler : IRequestHandler<IGetTransaccionFilterByReservaList, ICollection<TransaccionDTO>>
	{
		private readonly ITransaccionRepository _transaccionRepository;

		public GetTransaccionFilterByReservaListHandler(ITransaccionRepository transaccionRepository)
		{
			_transaccionRepository = transaccionRepository;
		}
		public async Task<ICollection<TransaccionDTO>> Handle(IGetTransaccionFilterByReservaList request, CancellationToken cancellationToken)
		{
			var transacciones = (ICollection<Transaccion>)_transaccionRepository.FindByReserva(request.ReservaId).Result;
			return transacciones
			.Select(t => new TransaccionDTO
			{
				TransaccionID = t.Id,
				Monto = t.Monto.Value,
				ReservaId = t.ReservaId,
				UsuarioId = t.UsuarioId,
				TipoTransaccion = t.TipoTransaccion.ToString()
			})
			.ToList();
		}
	}
}

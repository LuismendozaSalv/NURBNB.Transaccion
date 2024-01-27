using MediatR;
using NURBNB.Alojamiento.Application.UseCases.Pais.Command.CrearPais;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Model.Transaccion;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Transacciones.Command.CrearTransaccion
{
	public class CrearTransaccionHandler : IRequestHandler<CrearTransaccionCommand, Guid>
	{
		private ITransaccionRepository _transaccionRepository;
		private ITransaccionFactory _transaccionFactory;
		private IUnitOfWork _unitOfWork;

		public CrearTransaccionHandler(ITransaccionRepository transaccionRepository,
			ITransaccionFactory transaccionFactory,
			IUnitOfWork unitOfWork)
		{
			_transaccionRepository = transaccionRepository;
			_transaccionFactory = transaccionFactory;
			_unitOfWork = unitOfWork;
		}
		public async Task<Guid> Handle(CrearTransaccionCommand request, CancellationToken cancellationToken)
		{
			Transaccion transaccionCreada = null;
			TipoTransaccion tipoTransaccion = request.TipoTransaccion;
			switch (tipoTransaccion)
			{
				case TipoTransaccion.Pago:
					transaccionCreada = _transaccionFactory.CreateTransaccionPago(request.Monto, request.UsuarioId, request.ReservaId);
					break;
				case TipoTransaccion.Devolucion:
					transaccionCreada = _transaccionFactory.CreateTransaccionDevolucion(request.Monto, request.UsuarioId, request.ReservaId);
					break;

			}
			transaccionCreada.AddPagoReservaDomainEvent();
			await _transaccionRepository.CreateAsync(transaccionCreada);

			await _unitOfWork.Commit();

			return transaccionCreada.Id;
		}
	}
}

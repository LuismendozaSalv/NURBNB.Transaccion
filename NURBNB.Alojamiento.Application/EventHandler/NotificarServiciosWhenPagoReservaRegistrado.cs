using MediatR;
using NURBNB.Alojamiento.Application.Services;
using NURBNB.Alojamiento.Domain.Model.Transacciones.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.EventHandler
{
	internal class NotificarServiciosWhenPagoReservaRegistrado : INotificationHandler<PagoReservaRegistrado>
	{
		private readonly IBusService _bus;

		public NotificarServiciosWhenPagoReservaRegistrado(IBusService bus)
		{
			_bus = bus;
		}
		public async Task Handle(PagoReservaRegistrado notification, CancellationToken cancellationToken)
		{
			IntegrationEvents.PagoReservaRegistrado evento = new IntegrationEvents.PagoReservaRegistrado
			{
				ReservaId = notification.ReservaId,
				TransaccionId = notification.TransaccionId,
			};
			await _bus.PublishAsync(evento);
		}
	}
}

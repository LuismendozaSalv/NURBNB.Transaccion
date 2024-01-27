using MediatR;
using Restaurant.SharedKernel.Core;

namespace NURBNB.Alojamiento.Domain.Model.Transacciones.Events
{
	public record PagoReservaRegistrado : DomainEvent, INotification
	{
		public Guid ReservaId { get; set; }
		public Guid TransaccionId { get; set; }

		public PagoReservaRegistrado(Guid reservaId, Guid transaccionId) : base(DateTime.Now)
		{
			this.ReservaId = reservaId;
			this.TransaccionId = transaccionId;
		}
	}
}

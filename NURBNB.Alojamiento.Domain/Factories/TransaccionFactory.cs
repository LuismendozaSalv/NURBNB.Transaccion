using NURBNB.Alojamiento.Domain.Model.Transaccion;

namespace NURBNB.Alojamiento.Domain.Factories
{
	public class TransaccionFactory : ITransaccionFactory
	{
		public Transaccion CreateTransaccionDevolucion(Monto monto, Guid usuarioId, Guid reservaId)
		{
			return new Transaccion(monto, usuarioId, reservaId, TipoTransaccion.Pago);
		}

		public Transaccion CreateTransaccionPago(Monto monto, Guid usuarioId, Guid reservaId)
		{
			return new Transaccion(monto, usuarioId, reservaId, TipoTransaccion.Devolucion);
		}
	}
}

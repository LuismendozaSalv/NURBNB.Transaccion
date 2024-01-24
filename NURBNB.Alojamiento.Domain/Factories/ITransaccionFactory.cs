using NURBNB.Alojamiento.Domain.Model.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Factories
{
	public interface ITransaccionFactory
	{
		public Transaccion CreateTransaccionPago(Monto monto, Guid usuarioId, Guid reservaId);
		public Transaccion CreateTransaccionDevolucion(Monto monto, Guid usuarioId, Guid reservaId);
	}
}

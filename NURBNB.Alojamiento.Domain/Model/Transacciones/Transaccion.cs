using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Model.Transaccion
{
	public class Transaccion : AggregateRoot
	{
		public Monto Monto { get; private set; }
		public Guid ReservaId { get; private set; }
		public Guid UsuarioId { get; private set; }
		public TipoTransaccion TipoTransaccion { get; private set; }

		internal Transaccion(Monto monto, Guid reservaId, Guid usuarioId, TipoTransaccion tipoTransaccion)
		{
			Id = Guid.NewGuid();
			Monto = monto;
			ReservaId = reservaId;
			UsuarioId = usuarioId;
			TipoTransaccion = tipoTransaccion;
		}
	}
}

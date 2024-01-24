using MediatR;
using NURBNB.Alojamiento.Domain.Model.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Transacciones.Command.CrearTransaccion
{
	public class CrearTransaccionCommand : IRequest<Guid>
	{
		public Monto Monto { get; private set; }
		public Guid ReservaId { get; private set; }
		public Guid UsuarioId { get; private set; }
		public TipoTransaccion TipoTransaccion { get; private set; }
	}
}

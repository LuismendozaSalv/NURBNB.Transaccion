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
		public Monto Monto { get; set; }
		public Guid ReservaId { get; set; }
		public Guid UsuarioId { get; set; }
		public TipoTransaccion TipoTransaccion { get; set; }
	}
}

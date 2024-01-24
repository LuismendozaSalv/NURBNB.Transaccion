using MediatR;
using NURBNB.Alojamiento.Domain.Model.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Transacciones.Query
{
	public class IGetTransaccionList : IRequest<ICollection<Transaccion>>
	{
	}
}

using MediatR;
using NURBNB.Alojamiento.Application.Dto.Transacciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Transacciones.Query
{
	public class IGetTransaccionFilterByReservaList : IRequest<ICollection<TransaccionDTO>>
	{
		public Guid ReservaId { get; set; }
	}
}

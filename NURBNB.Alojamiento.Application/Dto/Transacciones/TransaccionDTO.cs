using NURBNB.Alojamiento.Domain.Model.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.Dto.Transacciones
{
	public class TransaccionDTO
	{
		public Guid TransaccionID { get; set; }
		public decimal Monto { get; set; }
		public Guid ReservaId { get; set; }
		public Guid UsuarioId { get; set; }
		public String TipoTransaccion { get; set; }
	}
}

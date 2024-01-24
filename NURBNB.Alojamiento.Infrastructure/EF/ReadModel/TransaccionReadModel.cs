using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
	[Table("transaccion")]
	internal class TransaccionReadModel
	{
		[Key]
		[Column("transaccionId")]
		public Guid Id { get; set; }

		[Required]
		[Column("monto", TypeName = "decimal(18,2)")]
		public decimal Monto { get; set; }

		[Required]
		[Column("usuarioId")]
		public Guid UsuarioId { get; set; }
		[Required]
		[Column("reservaId")]
		public Guid ReservaId { get; set; }

		[Required]
		[Column("tipoTransaccion")]
		[MaxLength(25)]
		public string TipoTransaccion { get; set; }
	}
}

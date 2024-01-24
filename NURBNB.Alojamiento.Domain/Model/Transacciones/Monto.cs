using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Model.Transaccion
{
	public record Monto : ValueObject
	{
		public decimal Value { get; init; }

		public Monto(decimal value)
		{
			if (value <= 0)
			{
				throw new ArgumentException("El monto no puede ser cero");
			}
			Value = value;
		}

		public static implicit operator decimal(Monto monto) => monto.Value;

		public static implicit operator Monto(decimal value) => new(value);
	}
}

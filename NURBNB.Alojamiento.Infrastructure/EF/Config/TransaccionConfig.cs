using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NURBNB.Alojamiento.Domain.Model.Transaccion;

namespace NURBNB.Alojamiento.Infrastructure.EF.Config
{
	internal class TransaccionConfig : IEntityTypeConfiguration<Transaccion>
	{
		public void Configure(EntityTypeBuilder<Transaccion> builder)
		{
			builder.ToTable("transaccion");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
			.HasColumnName("transaccionId");

			builder.Property(x => x.UsuarioId)
			.HasColumnName("usuarioId");

			builder.Property(x => x.ReservaId)
						.HasColumnName("reservaId");

			var montoConverter = new ValueConverter<Monto, decimal>(
				monto => monto.Value,
				monto => new Monto(monto)
			);

			builder.Property(x => x.Monto)
				.HasConversion(montoConverter)
				.HasColumnName("monto");

			var tipoConverter = new ValueConverter<TipoTransaccion, string>(
				tipoEnumValue => tipoEnumValue.ToString(),
				tipo => (TipoTransaccion)Enum.Parse(typeof(TipoTransaccion), tipo)
			);

			builder.Property(x => x.TipoTransaccion)
				 .HasConversion(tipoConverter)
				 .HasColumnName("tipoTransaccion")
				 .HasMaxLength(20)
				 .IsRequired();


			builder.Ignore("_domainEvents");
			builder.Ignore(x => x.DomainEvents);
		}
	}
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Application.Dto;
using NURBNB.Alojamiento.Application.UseCases.Pais.Query.GetPaisList;
using NURBNB.Alojamiento.Application.UseCases.Transacciones.Query;
using NURBNB.Alojamiento.Domain.Model.Transaccion;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Infrastructure.EF.Context;
using NURBNB.Alojamiento.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.UsesCases.Transacciones.Query
{
	public class GetTransaccionListHandler : IRequestHandler<IGetTransaccionList, ICollection<Transaccion>>
	{
		private readonly DbSet<TransaccionReadModel> _transacciones;
		private readonly ITransaccionRepository _transaccionRepository;

		public GetTransaccionListHandler(ITransaccionRepository transaccionRepository)
		{
			_transaccionRepository = transaccionRepository;
		}
		public async Task<ICollection<Transaccion>> Handle(IGetTransaccionList request, CancellationToken cancellationToken)
		{
			return (ICollection<Transaccion>)_transaccionRepository.FindAll();
		}


	}
}

using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Model.Transaccion;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Repositories
{
	public interface ITransaccionRepository : IRepository<Transaccion, Guid>
	{
		Task<List<Transaccion>> FindAll();
		Task<Transaccion> FindById(Guid id);
		Task<List<Transaccion>> FindByReserva(Guid idReserva);
		Task<List<Transaccion>> FindByUsuarioId(Guid usuarioId);
		Task<List<Transaccion>> FindByIds(List<Guid> ids);
		Task UpdateAsync(Transaccion transaccion);
	}
}

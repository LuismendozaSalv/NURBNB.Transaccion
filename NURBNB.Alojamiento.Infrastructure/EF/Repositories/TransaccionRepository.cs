using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Model.Transaccion;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Infrastructure.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.Repositories
{
	public class TransaccionRepository : ITransaccionRepository
	{
		private readonly WriteDbContext _context;

		public TransaccionRepository(WriteDbContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(Transaccion obj)
		{
			await _context.Transaccion.AddAsync(obj);
		}

		public async Task<List<Transaccion>> FindAll()
		{
			return await _context.Transaccion.ToListAsync();
		}

		public async Task<Transaccion> FindById(Guid id)
		{
			return await _context.Transaccion.Where(x => x.UsuarioId == id).FirstOrDefaultAsync();
		}

		public Task<Transaccion?> FindByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Transaccion>> FindByIds(List<Guid> ids)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Transaccion>?> FindByReserva(Guid idReserva)
		{
			return await _context.Transaccion.Where(x => x.ReservaId == idReserva).ToListAsync();
		}

		public async Task<List<Transaccion>> FindByUsuarioId(Guid usuarioId)
		{
			return await _context.Transaccion.Where(x => x.UsuarioId == usuarioId).ToListAsync();
		}

		public async Task UpdateAsync(Transaccion transaccion)
		{
			_context.Transaccion.Update(transaccion);
			await Task.CompletedTask;
		}
	}
}

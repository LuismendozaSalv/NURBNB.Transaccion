﻿using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Infrastructure.EF.Context;

namespace NURBNB.Alojamiento.Infrastructure.EF.Repositories
{
    internal class PropiedadRepository : IPropiedadRepository
    {
        private readonly WriteDbContext _context;

        public PropiedadRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Propiedad obj)
        {
            await _context.Propiedad.AddAsync(obj);
        }

        public async Task<Propiedad?> FindByIdAsync(Guid id)
        {
            return await _context.Propiedad
                .Include(x => x.Capacidad)
                .Where(x => x.Id == id).AsSplitQuery().FirstOrDefaultAsync();
        }

        public Task UpdateAsync(Propiedad Propiedad)
        {
            _context.Propiedad.Update(Propiedad);
            return Task.CompletedTask;
        }
    }
}
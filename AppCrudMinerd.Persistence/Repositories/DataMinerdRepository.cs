using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCrudMinerd.Application.Interfaces.Repositories;
using AppCrudMinerd.Persistence.Context;
using AppCrudMinerd.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace AppCrudMinerd.Persistence.Repositories
{

    public class DataMinerdRepository : IDataMinerdRepository
    {
        private readonly AppCrudMinerdContext _context;

        public DataMinerdRepository(AppCrudMinerdContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DataMinerd>> GetAllAsync()
        {
            return await _context.DATA_MINERD.ToListAsync();
        }

        public async Task<DataMinerd?> GetByIdAsync(string site)
        {
            return await _context.DATA_MINERD.FindAsync(site);
        }

        public async Task AddAsync(DataMinerd entity)
        {
            _context.DATA_MINERD.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DataMinerd entity)
        {
            _context.DATA_MINERD.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string site)
        {
            var entity = await _context.DATA_MINERD.FindAsync(site);
            if (entity != null)
            {
                _context.DATA_MINERD.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string site)
        {
            return await _context.DATA_MINERD.AnyAsync(d => d.Site == site);
        }


        public async Task<IEnumerable<DataMinerd>> GetBySearchAsync(string searchTerm, int limit = 100)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await _context.DATA_MINERD
                                     .Take(limit)
                                     .ToListAsync();

            // Normaliza y añade comodines (convertimos el patrón a mayúsculas con ToUpper())
            var term = $"%{searchTerm.Trim().ToUpper()}%";

            return await _context.DATA_MINERD
                .Where(e =>
                    EF.Functions.Like(e.Site.ToUpper(), term) ||
                    EF.Functions.Like(e.Circuito.ToString(), term) ||
                    EF.Functions.Like(e.Nombre_Escuela.ToUpper(), term) ||
                    EF.Functions.Like(e.WAN_IP.ToUpper(), term) ||
                    EF.Functions.Like(e.Nombre_Contacto.ToUpper(), term) ||
                    EF.Functions.Like(e.Telefono_Contacto.ToUpper(), term) ||
                    EF.Functions.Like(e.Distrito.ToUpper(), term)
                )
                .Take(limit)
                .ToListAsync();
        }


        public async Task<List<string>> GetExistingSitesAsync(IEnumerable<string> sites)
        {
            return await _context.DATA_MINERD
                                 .Where(d => sites.Contains(d.Site))
                                 .Select(d => d.Site)
                                 .ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<DataMinerd> entities)
        {
            await _context.DATA_MINERD.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }


    }
}


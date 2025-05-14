using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCrudMinerd.Application.Interfaces.Repositories;
using AppCrudMinerd.Persistence.Context;
using AppCrudMinerd.Persistence.Entities;
using Microsoft.EntityFrameworkCore;


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
        }
}


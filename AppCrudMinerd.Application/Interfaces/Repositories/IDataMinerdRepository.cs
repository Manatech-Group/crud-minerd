using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCrudMinerd.Persistence.Entities;

namespace AppCrudMinerd.Application.Interfaces.Repositories
{
    public interface IDataMinerdRepository
    {
        Task<IEnumerable<DataMinerd>> GetAllAsync();
        Task<DataMinerd?> GetByIdAsync(string site);
        Task AddAsync(DataMinerd entity);
        Task UpdateAsync(DataMinerd entity);
        Task DeleteAsync(string site);
        Task<bool> ExistsAsync(string site);
    }
}

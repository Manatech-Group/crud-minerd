using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCrudMinerd.Application.Dtos;
using Microsoft.AspNetCore.Http;

namespace AppCrudMinerd.Application.Interfaces.Services
{
    public interface IDataMinerdService
    {
        Task<IEnumerable<DataMinerdDto>> GetAllAsync();
        Task<DataMinerdDto?> GetByIdAsync(string site);
        Task CreateAsync(CreateDataMinerdDto dto);
        Task UpdateAsync(string site, UpdateDataMinerdDto dto);
        Task DeleteAsync(string site);

        Task<IEnumerable<DataMinerdDto>> SearchAsync(string searchTerm);   // <-- nuevo

        Task<ImportDataMinerdResultDto> ImportFromCsvAsync(IFormFile file);
    }
}

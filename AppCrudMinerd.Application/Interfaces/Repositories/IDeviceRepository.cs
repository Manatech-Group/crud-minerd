using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCrudMinerd.Domain.Entities;

namespace AppCrudMinerd.Application.Interfaces.Repositories
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetAllAsync();
    }
}

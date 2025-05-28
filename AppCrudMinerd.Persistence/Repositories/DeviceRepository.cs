using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCrudMinerd.Application.Interfaces.Repositories;
using AppCrudMinerd.Domain.Entities;
using AppCrudMinerd.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppCrudMinerd.Persistence.Repositories
{
    public class DeviceRepository : IDeviceRepository   
    {
        private readonly AppCrudMinerdContext _context;
        public DeviceRepository(AppCrudMinerdContext context)
        {
            _context = context;
        }
        public async Task<List<Device>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }

    }
}

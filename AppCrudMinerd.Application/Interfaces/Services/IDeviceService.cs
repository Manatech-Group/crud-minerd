﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCrudMinerd.Application.Dtos;
using Microsoft.AspNetCore.Http;

namespace AppCrudMinerd.Application.Interfaces.Services
{
    public interface IDeviceService
    {
        Task<List<DeviceDto>> GetAllAsync();
      
    }
}

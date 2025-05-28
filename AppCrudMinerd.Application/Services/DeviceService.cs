using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCrudMinerd.Application.Dtos;
using AppCrudMinerd.Application.Interfaces.Repositories;
using AppCrudMinerd.Application.Interfaces.Services;

namespace AppCrudMinerd.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<List<DeviceDto>> GetAllAsync()
        {
            var devices = await _deviceRepository.GetAllAsync();

            // Manual mapping
            var dtoList = new List<DeviceDto>();

            foreach (var device in devices)
            {
                dtoList.Add(new DeviceDto
                {
                    SerialNumber = device.SerialNumber,
                    SiteName = device.SiteName,
                    FirmwareVersion = device.FirmwareVersion
                });
            }

            return dtoList;
        }
    }
}

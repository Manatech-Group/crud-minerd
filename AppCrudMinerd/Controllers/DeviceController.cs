using AppCrudMinerd.Application.Dtos;
using AppCrudMinerd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCrudMinerd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        /// <summary>
        /// Devuelve la lista de dispositivos registrados
        /// </summary>
        /// <returns>Lista de dispositivos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceDto>>> GetDevices()
        {
            var devices = await _deviceService.GetAllAsync();
            return Ok(devices);
        }

        // Puedes agregar aquí otros métodos como GetById, Create, etc.
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCrudMinerd.Application.Dtos
{
    public class DeviceDto
    {
        public string SerialNumber { get; set; }
        public string SiteName { get; set; }
        public string FirmwareVersion { get; set; }
    }
}

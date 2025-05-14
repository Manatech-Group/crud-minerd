using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCrudMinerd.Application.Dtos
{
    public class CreateDataMinerdDto
    {
        public string Site { get; set; } // Si lo autogenera la DB, remueve esto

        public long? Circuito { get; set; }

        public string Nombre_Escuela { get; set; }

        public string WAN_IP { get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set; }

        public string Long_Name { get; set; }

        public string? Nombre_Contacto { get; set; }

        public string? Telefono_Contacto { get; set; }

        public string? Regional { get; set; }

        public string? Distrito { get; set; }

        public string? Codigo_Planta_Fisica { get; set; }

        public string? Hostname { get; set; }

        public string? DDNS { get; set; }

        public string? IP_Gestion_FMG { get; set; }

        public string? IP_Gestion_SW { get; set; }

        public bool? SSHStatus { get; set; }

        public DateTime? LastSSHTest { get; set; }

        public bool? PingStatus { get; set; }

        public DateTime? LastPingTest { get; set; }

        public string? Fortigate { get; set; }

        public string? Fortigate_FW { get; set; }

        public bool? Fortigate_HTTPS { get; set; }

        public string? SiteType { get; set; }
    }

}

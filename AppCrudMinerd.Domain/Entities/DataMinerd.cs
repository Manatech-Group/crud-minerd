using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCrudMinerd.Persistence.Entities
{
    public class DataMinerd
    {
        [Key]
        public string Site { get; set; }

        public long? Circuito { get; set; }

        [Required]
        public string Nombre_Escuela { get; set; }

        [Required]
        public string WAN_IP { get; set; }

        [Required]
        public string Latitud { get; set; }

        [Required]
        public string Longitud { get; set; }

        [Required]
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

        // Si quieres establecer la relación con Devices:
        // public Devices? FortigateDevice { get; set; }
    }

}

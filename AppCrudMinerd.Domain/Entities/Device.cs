using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCrudMinerd.Domain.Entities
{
    public class Device
    {
        [Key]
        [Column("Serial_Number")]
        public string SerialNumber { get; set; }

        [Column("SKU_ID")]
        public int SkuId { get; set; }

        [Column("Site_Name")]
        public string SiteName { get; set; }

        [Column("Accessed")]
        public bool Accessed { get; set; }

        [Column("FirmwareVersion")]
        public string FirmwareVersion { get; set; }

        [Column("LastSeen")]
        public DateTime LastSeen { get; set; }
    }
}

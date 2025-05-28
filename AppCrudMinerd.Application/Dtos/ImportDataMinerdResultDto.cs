using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCrudMinerd.Application.Dtos
{
    public class ImportDataMinerdResultDto
    {
        public List<DataMinerdDto> Nuevos { get; set; }
        public List<DataMinerdDto> Existentes { get; set; }
    }
}

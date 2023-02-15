using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Application.Dtos.Response
{
  public class CategorySelectResponseDto
    {

        public int IdCategoria { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public DateTime fechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
        public bool? Activo { get; set; }

    }
}

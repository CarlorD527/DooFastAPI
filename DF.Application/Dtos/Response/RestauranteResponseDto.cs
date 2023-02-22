using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Application.Dtos.Response
{
    public class RestauranteResponseDto
    {
        public int IdRestaurante { get; set; }

        public string NombreRestaurante { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Aforo { get; set; }
        
        public bool? Activo { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

  
    }
}

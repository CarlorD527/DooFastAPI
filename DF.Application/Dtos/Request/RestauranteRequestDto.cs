using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Application.Dtos.Request
{
    public class RestauranteRequestDto
    {
        public string NombreRestaurante { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Aforo { get; set; }

    }
}

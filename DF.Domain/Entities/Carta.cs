using System;
using System.Collections.Generic;

namespace DF.Domain.Entities;

public partial class Carta
{
    public int IdCarta { get; set; }

    public int? IdRestaurante { get; set; }

    public string NombreCarta { get; set; } = null!;

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Restaurante? IdRestauranteNavigation { get; set; }

    public virtual ICollection<Platillo> Platillos { get; } = new List<Platillo>();
}

using System;
using System.Collections.Generic;

namespace DF.Domain.Entities;

public partial class Platillo
{
    public int IdPlatillo { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdCarta { get; set; }

    public string NombrePlatillo { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? Foto { get; set; }

    public bool? Activo { get; set; }

    public decimal Precio { get; set; }

    public virtual Carta? IdCartaNavigation { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual ICollection<OrdenesPlatillo> OrdenesPlatillos { get; } = new List<OrdenesPlatillo>();
}

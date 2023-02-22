using System;
using System.Collections.Generic;

namespace DF.Domain.Entities;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Platillo> Platillos { get; } = new List<Platillo>();
}

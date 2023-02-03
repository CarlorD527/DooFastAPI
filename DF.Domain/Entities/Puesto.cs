using System;
using System.Collections.Generic;

namespace DF.Domain.Entities;

public partial class Puesto
{
    public int IdPuesto { get; set; }

    public string NombrePuesto { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}

using System;
using System.Collections.Generic;

namespace DF.Domain.Entities;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int? IdRestaurante { get; set; }

    public int? IdPuesto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public decimal Sueldo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? Foto { get; set; }

    public bool? Activo { get; set; }

    public virtual Puesto? IdPuestoNavigation { get; set; }

    public virtual Restaurante? IdRestauranteNavigation { get; set; }

    public virtual ICollection<OrdenesPlatillos> Ordenes { get; } = new List<OrdenesPlatillos>();
}

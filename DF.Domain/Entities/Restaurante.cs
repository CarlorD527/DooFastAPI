using System;
using System.Collections.Generic;

namespace DF.Domain.Entities;

public partial class Restaurante
{
    public int IdRestaurante { get; set; }

    public string NombreRestaurante { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Aforo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Carta> Carta { get; } = new List<Carta>();

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();

    public virtual ICollection<Mesa> Mesas { get; } = new List<Mesa>();

    public virtual ICollection<OrdenesPlatillos> Ordenes { get; } = new List<OrdenesPlatillos>();
}

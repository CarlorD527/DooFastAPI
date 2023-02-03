using System;
using System.Collections.Generic;

namespace DF.Domain.Entities;

public partial class Mesa
{
    public int IdMesa { get; set; }

    public int? IdRestaurante { get; set; }

    public int NumeroMesa { get; set; }

    public int Capacidad { get; set; }

    public int NumeroNivel { get; set; }

    public string Disponibilidad { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual Restaurante? IdRestauranteNavigation { get; set; }

    public virtual ICollection<OrdenesPlatillos> Ordenes { get; } = new List<OrdenesPlatillos>();
}

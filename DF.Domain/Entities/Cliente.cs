using System;
using System.Collections.Generic;

namespace DF.Domain.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int? IdMesa { get; set; }

    public int? IdRestaurante { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string? Dni { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public bool? Activo { get; set; }

    public virtual Mesa? IdMesaNavigation { get; set; }

    public virtual Restaurante? IdRestauranteNavigation { get; set; }

    public virtual ICollection<OrdenesPlatillos> Ordenes { get; } = new List<OrdenesPlatillos>();
}

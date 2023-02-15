using System;
using System.Collections.Generic;

namespace DF.Domain.Entities;

public partial class OrdenesPlatillos
{
    public int IdOrden { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdRestaurante { get; set; }

    public int? IdMesa { get; set; }

    public int? IdCliente { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public decimal CostoTotal { get; set; }

    public string Estado { get; set; } = null!;

    public string? NotaAdicional { get; set; }

    public string? FormaPago { get; set; }

    public bool? Activo { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Mesa? IdMesaNavigation { get; set; }

    public virtual Restaurante? IdRestauranteNavigation { get; set; }

    public virtual ICollection<OrdenesPlatillo> ListaOrdenesPlatillos { get; } = new List<OrdenesPlatillo>();
}

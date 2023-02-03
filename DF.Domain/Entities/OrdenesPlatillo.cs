using System;
using System.Collections.Generic;

namespace DF.Domain.Entities;

public partial class OrdenesPlatillo
{
    public int IdOrdenPlatillo { get; set; }

    public int? IdOrden { get; set; }

    public int? IdPlatillo { get; set; }

    public int? Cantidad { get; set; }

    public virtual OrdenesPlatillos? IdOrdenNavigation { get; set; }

    public virtual Platillo? IdPlatilloNavigation { get; set; }
}

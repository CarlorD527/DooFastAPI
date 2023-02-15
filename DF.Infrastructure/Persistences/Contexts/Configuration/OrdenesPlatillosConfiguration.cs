using DF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Infrastructure.Persistences.Contexts.Configuration
{
    public class OrdenesPlatillosConfiguration : IEntityTypeConfiguration<OrdenesPlatillo>
    {
        public void Configure(EntityTypeBuilder<OrdenesPlatillo> builder)
        {
            builder.HasKey(e => e.IdOrdenPlatillo);

            builder.ToTable("ORDENES_PLATILLOS");

            builder.Property(e => e.IdOrdenPlatillo).HasColumnName("id_orden_platillo");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.IdOrden).HasColumnName("id_orden");
            builder.Property(e => e.IdPlatillo).HasColumnName("id_platillo");

            builder.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.ListaOrdenesPlatillos)
                .HasForeignKey(d => d.IdOrden)
                .HasConstraintName("FK_PLATILLO_ESTA_ORDENES");

            builder.HasOne(d => d.IdPlatilloNavigation).WithMany(p => p.OrdenesPlatillos)
                .HasForeignKey(d => d.IdPlatillo)
                .HasConstraintName("FK_ORDEN_TIENE_PLATILLOS");
        }
    }
}

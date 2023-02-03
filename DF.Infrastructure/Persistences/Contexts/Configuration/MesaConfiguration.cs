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
    public class MesaConfiguration : IEntityTypeConfiguration<Mesa>
    {
        public void Configure(EntityTypeBuilder<Mesa> builder)
        {
            builder.HasKey(e => e.IdMesa);

            builder.ToTable("MESAS");

            builder.Property(e => e.IdMesa).HasColumnName("id_mesa");
            builder.Property(e => e.Activo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("activo");
            builder.Property(e => e.Capacidad).HasColumnName("capacidad");
            builder.Property(e => e.Disponibilidad)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValueSql("('DISPONIBLE')")
                .HasColumnName("disponibilidad");
            builder.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            builder.Property(e => e.IdRestaurante).HasColumnName("id_restaurante");
            builder.Property(e => e.NumeroMesa).HasColumnName("numero_mesa");
            builder.Property(e => e.NumeroNivel).HasColumnName("numero_nivel");

            builder.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.IdRestaurante)
                .HasConstraintName("FK_RESTAURANTE_TIENE_MESAS");
        }
    }
}

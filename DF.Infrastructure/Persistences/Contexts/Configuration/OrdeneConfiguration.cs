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
    public class OrdeneConfiguration : IEntityTypeConfiguration<OrdenesPlatillos>
    {
        public void Configure(EntityTypeBuilder<OrdenesPlatillos> builder)
        {
            builder.HasKey(e => e.IdOrden);

            builder.ToTable("ORDENES");

            builder.Property(e => e.IdOrden).HasColumnName("id_orden");
            builder.Property(e => e.Activo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("activo");
            builder.Property(e => e.CostoTotal)
                .HasColumnType("money")
                .HasColumnName("costo_total");
            builder.Property(e => e.Estado)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValueSql("('PENDIENTE')")
                .HasColumnName("estado");
            builder.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            builder.Property(e => e.FormaPago)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("forma_pago");
            builder.Property(e => e.IdCliente).HasColumnName("id_cliente");
            builder.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            builder.Property(e => e.IdMesa).HasColumnName("id_mesa");
            builder.Property(e => e.IdRestaurante).HasColumnName("id_restaurante");
            builder.Property(e => e.NotaAdicional)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("nota_adicional");

            builder.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_CLIENTE_PIDE_ORDEN");

            builder.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK_EMPLEADO_TOMA_ORDEN");

            builder.HasOne(d => d.IdMesaNavigation).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.IdMesa)
                .HasConstraintName("FK_MESA_TIENE_ORDENES");

            builder.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.IdRestaurante)
                .HasConstraintName("FK_RESTAURANTE_TIENE_ORDENES");
        }
    }
}

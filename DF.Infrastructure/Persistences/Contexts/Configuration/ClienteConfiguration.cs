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
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.IdCliente);

            builder.ToTable("CLIENTES");

            builder.Property(e => e.IdCliente).HasColumnName("id_cliente");
            builder.Property(e => e.Activo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("activo");
            builder.Property(e => e.Dni)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DNI");
            builder.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            builder.Property(e => e.IdMesa).HasColumnName("id_mesa");
            builder.Property(e => e.IdRestaurante).HasColumnName("id_restaurante");
            builder.Property(e => e.NombreCliente)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre_cliente");

            builder.HasOne(d => d.IdMesaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdMesa)
                .HasConstraintName("FK_MESA_TIENE_CLIENTES");

            builder.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdRestaurante)
                .HasConstraintName("FK_RESTAURANTE_TIENE_CLIENTE");
        }
    }
}

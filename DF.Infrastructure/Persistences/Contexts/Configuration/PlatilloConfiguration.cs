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
    public class PlatilloConfiguration : IEntityTypeConfiguration<Platillo>
    {
        public void Configure(EntityTypeBuilder<Platillo> builder)
        {
            builder.HasKey(e => e.IdPlatillo);

            builder.ToTable("PLATILLOS");

            builder.Property(e => e.IdPlatillo).HasColumnName("id_platillo");
            builder.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("activo");
            builder.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            builder.Property(e => e.Foto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("foto");
            builder.Property(e => e.IdCarta).HasColumnName("id_carta");
            builder.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            builder.Property(e => e.NombrePlatillo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_platillo");
            builder.Property(e => e.Precio)
                .HasColumnType("money")
                .HasColumnName("precio");

            builder.HasOne(d => d.IdCartaNavigation).WithMany(p => p.Platillos)
                .HasForeignKey(d => d.IdCarta)
                .HasConstraintName("FK_CARTA_TIENE_PLATILLOS");

            builder.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Platillos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_PLATILLO_TIENE_CATEGORIA");
        }
    }
}

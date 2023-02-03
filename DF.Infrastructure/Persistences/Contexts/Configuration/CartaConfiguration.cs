using DF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DF.Infrastructure.Persistences.Contexts.Configuration
{
    public class CartaConfiguration : IEntityTypeConfiguration<Carta>
    {
        public void Configure(EntityTypeBuilder<Carta> builder)
        {
            builder.HasKey(e => e.IdCarta);

            builder.ToTable("CARTAS");

            builder.Property(e => e.IdCarta).HasColumnName("id_carta");
            builder.Property(e => e.Activo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("activo");
            builder.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            builder.Property(e => e.IdRestaurante).HasColumnName("id_restaurante");
            builder.Property(e => e.NombreCarta)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre_carta");

            builder.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Carta)
                .HasForeignKey(d => d.IdRestaurante)
                .HasConstraintName("FK_RESTAURANTE_TIENE_CARTA");
        }
    }
}

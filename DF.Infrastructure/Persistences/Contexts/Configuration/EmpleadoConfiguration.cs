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
    internal class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(e => e.IdEmpleado);

            builder.ToTable("EMPLEADOS");

            builder.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            builder.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("activo");
            builder.Property(e => e.Contrasenia)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("contrasenia");
            builder.Property(e => e.Direccion)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("direccion");
            builder.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            builder.Property(e => e.Foto)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("foto");
            builder.Property(e => e.IdPuesto).HasColumnName("id_puesto");
            builder.Property(e => e.IdRestaurante).HasColumnName("id_restaurante");
            builder.Property(e => e.Nombre)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nombre");
            builder.Property(e => e.Sueldo)
                .HasColumnType("money")
                .HasColumnName("sueldo");
            builder.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");
            builder.Property(e => e.Usuario)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("usuario");

            builder.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("FK_EMPLEADO_TIENE_PUESTO");

            builder.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdRestaurante)
                .HasConstraintName("FK_RESTAURANTE_TIENE_EMPLEADOS");
        }
    }
}

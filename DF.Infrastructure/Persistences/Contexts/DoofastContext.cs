using DF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DF.Infrastructure.Persistences.Contexts;

public partial class DoofastContext : DbContext
{
    public DoofastContext()
    {
    }

    public DoofastContext(DbContextOptions<DoofastContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carta> Cartas { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<OrdenesPlatillos> Ordenes { get; set; }

    public virtual DbSet<OrdenesPlatillo> OrdenesPlatillos { get; set; }

    public virtual DbSet<Platillo> Platillos { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Restaurante> Restaurantes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

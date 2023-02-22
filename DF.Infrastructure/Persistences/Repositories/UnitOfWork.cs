using DF.Infrastructure.Persistences.Contexts;
using DF.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DoofastContext _context;
        public ICategoriaRepository Categoria { get; private set; }

        public IRestauranteRepository Restaurante { get; private set; }

        public UnitOfWork(DoofastContext context)
        {
            _context = context;
            Categoria = new CategoriaRepository(_context);
            Restaurante= new RestauranteRepository(_context);
        }

        public void Dispose()
        {
            //liberar recursos en memoria
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

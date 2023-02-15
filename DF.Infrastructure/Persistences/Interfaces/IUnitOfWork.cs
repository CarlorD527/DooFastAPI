using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        
        //Declaracion o matricula de nuestra interfaces a nivel repository

        ICategoriaRepository Categoria { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}

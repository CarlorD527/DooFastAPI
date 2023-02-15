using DF.Domain.Entities;
using DF.Infrastructure.Commons.Bases.Request;
using DF.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Infrastructure.Persistences.Interfaces
{
    public interface ICategoriaRepository
    {

        Task<BaseEntityResponse<Categoria>> ListCategories(BaseFilterRequest filters);

        Task<IEnumerable<Categoria>> ListSelectCategories();


        Task<Categoria> CategoryById(int categoryId);

        Task<bool> RegisterCategory(Categoria category);

        Task<bool> EditCategory(Categoria category);

        Task<bool> RemoveCategory(int categoryId);


    }
}

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
    public interface IRestauranteRepository
    {

        Task<BaseEntityResponse<Restaurante>> ListRestaurantes(BaseFilterRequest filters);

        Task<IEnumerable<Restaurante>> ListSelectRestaurantes();

        Task<Restaurante> RestauranteById(int categoryId);

        Task<bool> RegisterRestaurante(Restaurante category);

        Task<bool> EditRestaurante(Restaurante category);

        Task<bool> RemoveRestaurante(int categoryId);
    }
}

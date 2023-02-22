using DF.Domain.Entities;
using DF.Infrastructure.Commons.Bases.Request;
using DF.Infrastructure.Commons.Bases.Response;
using DF.Infrastructure.Persistences.Contexts;
using DF.Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Infrastructure.Persistences.Repositories
{
    public class RestauranteRepository : GenericRepository<Restaurante>, IRestauranteRepository
    {

        private readonly DoofastContext _context;

        public RestauranteRepository(DoofastContext context)
        {
            _context = context;

        }
        public async Task<BaseEntityResponse<Restaurante>> ListRestaurantes(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<Restaurante>();

            var restaurantes = (from c in _context.Restaurantes
                              where c.Activo == true
                              select c).AsNoTracking().AsQueryable();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {

                switch (filters.NumFilter)
                {

                    case 1:
                        restaurantes = restaurantes.Where(x => x.NombreRestaurante!.Contains(filters.TextFilter));

                        break;

                    case 2:
                        restaurantes = restaurantes.Where(x => x.Direccion.Contains(filters.TextFilter));

                        break;
                }
            }

            if (filters.Sort is null) filters.Sort = "IdRestaurante";

            response.totalRecords = await restaurantes.CountAsync();
            response.Items = await Ordering(filters, restaurantes, !(bool)filters.Download!).ToListAsync();

            return response;
        }

        public async Task<IEnumerable<Restaurante>> ListSelectRestaurantes()
        {
            var restaurantes = await _context.Restaurantes.Where(x => x.Activo == true).ToListAsync();

            return restaurantes;
        }

        public async Task<Restaurante> RestauranteById(int restauranteId)
        {
            var restaurante =  _context.Restaurantes.AsNoTracking().FirstOrDefault(x => x.IdRestaurante.Equals(restauranteId));

            return restaurante!;
        }

        public async Task<bool> RegisterRestaurante(Restaurante restaurante)
        {
            restaurante.FechaCreacion = DateTime.Now;

            await _context.AddAsync(restaurante);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

        public async Task<bool> EditRestaurante(Restaurante restaurante)
        {
            restaurante.FechaActualizacion = DateTime.Now;

            _context.Update(restaurante);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> RemoveRestaurante(int restauranteId)
        {
            var restaurante = _context.Restaurantes.AsNoTracking().SingleOrDefault(x => x.IdRestaurante.Equals(restauranteId));

            restaurante!.Activo = false;

            _context.Update(restaurante);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }


    }
}

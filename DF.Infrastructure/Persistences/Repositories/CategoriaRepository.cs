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
    public class CategoriaRepository :GenericRepository<Categoria> , ICategoriaRepository
    {

        private readonly DoofastContext _context;

        public CategoriaRepository(DoofastContext context)
        {
            _context = context;

        }
        public async Task<BaseEntityResponse<Categoria>> ListCategories(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<Categoria>();

            var categories = (from c in _context.Categorias where c.Activo == true 
                              select c).AsNoTracking().AsQueryable();

            if(filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter)) {
            
                switch(filters.NumFilter) {

                    case 1:
                        categories = categories.Where(x => x.Nombre!.Contains(filters.TextFilter)) ; 
                        
                        break;

                    case 2:
                            categories = categories.Where(x => x.Descripcion!.Contains(filters.TextFilter));
                        
                        break;  
                }
            }

            if (filters.Sort is null) filters.Sort = "IdCategoria";

            response.totalRecords = await categories.CountAsync();
            response.Items = await Ordering(filters, categories, !(bool)filters.Download!).ToListAsync();

            return response;
        }
        public async Task<IEnumerable<Categoria>> ListSelectCategories()
        {
            var categories = await _context.Categorias.Where(x => x.Activo == true).ToListAsync();

            return categories;
        }
        public async Task<Categoria> CategoryById(int categoryId)
        {
           var category = _context.Categorias.AsNoTracking().FirstOrDefault(x=>x.IdCategoria.Equals(categoryId));

            return category!;
        }

        public async Task<bool> RegisterCategory(Categoria category)
        {

            category.FechaCreacion = DateTime.Now;

            await _context.AddAsync(category);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }
        public async Task<bool> EditCategory(Categoria category)
        {
            category.FechaActualizacion = DateTime.Now;

            _context.Update(category);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;

        }
        public async Task<bool> RemoveCategory(int categoryId)
        {
            var category =  _context.Categorias.AsNoTracking().SingleOrDefault(x => x.IdCategoria.Equals(categoryId));

            category!.Activo = false;

            _context.Update(category);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }
    }
}

﻿using DF.Infrastructure.Commons.Bases.Request;
using DF.Infrastructure.Helpers;
using DF.Infrastructure.Persistences.Interfaces;
using System.Linq.Dynamic.Core;

namespace DF.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {

            IQueryable<TDTO> queryDto = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} descending") : queryable.OrderBy($"{request.Sort} ascending");

            if (pagination) queryDto = queryDto.Paginate(request);

            return queryDto;
        
        }
    }
}

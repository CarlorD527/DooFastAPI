using DF.Application.Commons.Bases;
using DF.Application.Dtos.Request;
using DF.Application.Dtos.Response;
using DF.Infrastructure.Commons.Bases.Request;
using DF.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFilterRequest filters);

        Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories();

        Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId);

        Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto);

        Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto);

        Task<BaseResponse<bool>> RemoveCategory(int categoryId);
    }
}

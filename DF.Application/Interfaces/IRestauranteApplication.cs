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
    public interface IRestauranteApplication
    {

        Task<BaseResponse<BaseEntityResponse<RestauranteResponseDto>>> ListRestaurantes(BaseFilterRequest filters);

        Task<BaseResponse<IEnumerable<RestauranteSelectResponseDto>>> ListSelectRestaurantes();

        Task<BaseResponse<RestauranteResponseDto>> RestauranteById(int restauranteId);

        Task<BaseResponse<bool>> RegisterRestaurante(RestauranteRequestDto requestDto);

        Task<BaseResponse<bool>> EditRestaurante(int restauranteId, RestauranteRequestDto requestDto);

        Task<BaseResponse<bool>> RemoveRestaurante(int restauranteId);
    }
}

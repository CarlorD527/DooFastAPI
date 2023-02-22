using AutoMapper;
using DF.Application.Commons.Bases;
using DF.Application.Dtos.Request;
using DF.Application.Dtos.Response;
using DF.Application.Interfaces;
using DF.Application.Validators.Category;
using DF.Domain.Entities;
using DF.Infrastructure.Commons.Bases.Request;
using DF.Infrastructure.Commons.Bases.Response;
using DF.Infrastructure.Persistences.Interfaces;
using DF.Utilities.Static;

namespace DF.Application.Services
{
    public class RestauranteApplication : IRestauranteApplication
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly RestauranteValidator _validatorRules;

        public RestauranteApplication (IUnitOfWork unitOfWork, IMapper mapper, RestauranteValidator validatorRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validatorRules = validatorRules;
        }
        public async Task<BaseResponse<BaseEntityResponse<RestauranteResponseDto>>> ListRestaurantes(BaseFilterRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<RestauranteResponseDto>>();
            var restaurantes = await _unitOfWork.Restaurante.ListRestaurantes(filters);

            if (restaurantes is not null)
            {

                response.isSucces = true;
                response.Data = _mapper.Map<BaseEntityResponse<RestauranteResponseDto>>(restaurantes);
                response.Message = ReplyMessage.MESSAGE_QUERY;

            }
            else
            {

                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<RestauranteSelectResponseDto>>> ListSelectRestaurantes()
        {
            var response = new BaseResponse<IEnumerable<RestauranteSelectResponseDto>>();
            var restaurantes = await _unitOfWork.Restaurante.ListSelectRestaurantes();

            if (restaurantes is not null)
            {
                response.isSucces = true;
                response.Data = _mapper.Map<IEnumerable<RestauranteSelectResponseDto>>(restaurantes);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {

                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }
        public async Task<BaseResponse<RestauranteResponseDto>> RestauranteById(int restauranteId)
        {
            var response = new BaseResponse<RestauranteResponseDto>();

            var restaurante = await _unitOfWork.Restaurante.RestauranteById(restauranteId);

            if (restaurante is not null)
            {
                response.isSucces = true;
                response.Data = _mapper.Map<RestauranteResponseDto>(restaurante);
                response.Message = ReplyMessage.MESSAGE_QUERY;

            }
            else
            {

                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

            }

            return response;

        }
        public async Task<BaseResponse<bool>> RegisterRestaurante(RestauranteRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validatorRules.ValidateAsync(requestDto);

            if (!validationResult.IsValid)
            {
                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;

            }

            var restaurante = _mapper.Map<Restaurante>(requestDto);
            response.Data = await _unitOfWork.Restaurante.RegisterRestaurante(restaurante);

            if (response.Data)
            {

                response.isSucces = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;

            }
            else
            {
                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;

            }

            return response;
        }
        public async Task<BaseResponse<bool>> EditRestaurante(int restauranteId, RestauranteRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var restauranteEdit = await RestauranteById(restauranteId);

            if (restauranteEdit.Data is null)
            {

                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;


            }
            var restaurate = _mapper.Map<Restaurante>(requestDto);
            restaurate.IdRestaurante = restauranteId;
            restaurate.Activo = (bool)restauranteEdit.Data!.Activo!;
            restaurate.FechaCreacion = (DateTime)restauranteEdit!.Data.FechaCreacion!;
            response.Data = await _unitOfWork.Restaurante.EditRestaurante(restaurate);

            if (response.Data)
            {

                response.isSucces = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;

            }
            else
            {

                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }
        public async Task<BaseResponse<bool>> RemoveRestaurante(int restauranteId)
        {
            var response = new BaseResponse<bool>();

            var restaurante = await RestauranteById(restauranteId);

            if (restaurante.Data is null)
            {
                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

            }


            response.Data = await _unitOfWork.Restaurante.RemoveRestaurante(restauranteId);

            if (response.Data)
            {

                response.isSucces = true;
            }
            return response;
        }

    }
}

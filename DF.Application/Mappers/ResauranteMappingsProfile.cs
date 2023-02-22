using AutoMapper;
using DF.Application.Dtos.Request;
using DF.Application.Dtos.Response;
using DF.Domain.Entities;
using DF.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Application.Mappers
{
    public class ResauranteMappingsProfile : Profile
    {
        public ResauranteMappingsProfile()
        {

            CreateMap<Restaurante, RestauranteResponseDto>()
                   .ForMember(x => x.Activo, x => x.MapFrom(y => y.Activo.Equals(true) ? true : false))
                   .ReverseMap();

            CreateMap<BaseEntityResponse<Restaurante>, BaseEntityResponse<RestauranteResponseDto>>()
                .ReverseMap();

            CreateMap<RestauranteRequestDto, Restaurante>();

            CreateMap<Restaurante, RestauranteSelectResponseDto>()
                .ReverseMap();

        }
    }
}

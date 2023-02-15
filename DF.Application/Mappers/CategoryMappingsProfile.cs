using AutoMapper;
using DF.Application.Dtos.Request;
using DF.Application.Dtos.Response;
using DF.Domain.Entities;
using DF.Infrastructure.Commons.Bases.Response;
using DF.Utilities.Static;

namespace DF.Application.Mappers
{
    public class CategoryMappingsProfile : Profile
    {
        public CategoryMappingsProfile() {

            CreateMap<Categoria, CategoryResponseDto>()
                   .ForMember(x => x.Activo, x => x.MapFrom(y => y.Activo.Equals(true) ? true : false))
                   .ReverseMap();

            CreateMap<BaseEntityResponse<Categoria>, BaseEntityResponse<CategoryResponseDto>>()
                .ReverseMap();

            CreateMap<CategoryRequestDto, Categoria>();

            CreateMap<Categoria, CategorySelectResponseDto>()
                .ReverseMap() ;

        }
    }
}

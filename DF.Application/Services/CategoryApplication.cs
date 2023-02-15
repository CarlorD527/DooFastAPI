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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Application.Services
{
    public class CategoryApplication : ICategoryApplication
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly CategoryValidator _validatorRules;

        public CategoryApplication(IUnitOfWork unitOfWork, IMapper mapper, CategoryValidator validatorRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validatorRules = validatorRules;
        }
        public async Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFilterRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<CategoryResponseDto>>();
            var categories = await _unitOfWork.Categoria.ListCategories(filters);

            if (categories is not null)
            {

                response.isSucces = true;
                response.Data = _mapper.Map<BaseEntityResponse<CategoryResponseDto>>(categories);
                response.Message = ReplyMessage.MESSAGE_QUERY;

            }
            else {

                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories()
        {
            var response = new BaseResponse<IEnumerable<CategorySelectResponseDto>>();
            var categories = await _unitOfWork.Categoria.ListSelectCategories();

            if (categories is not null)
            {
                response.isSucces = true;
                response.Data = _mapper.Map<IEnumerable<CategorySelectResponseDto>>(categories);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else {

                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId)
        {
            var response = new BaseResponse<CategoryResponseDto>();

            var category = await _unitOfWork.Categoria.CategoryById(categoryId);

            if (category is not null)
            {
                response.isSucces = true;
                response.Data = _mapper.Map<CategoryResponseDto>(category);
                response.Message = ReplyMessage.MESSAGE_QUERY;

            }
            else {

                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validatorRules.ValidateAsync(requestDto);

            if(!validationResult.IsValid)
            {
                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;

            }

            var category = _mapper.Map<Categoria>(requestDto);
            response.Data = await _unitOfWork.Categoria.RegisterCategory(category);

            if (response.Data)
            {

                response.isSucces = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;

            }
            else {
                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;

            }

            return response;
        }
        public async Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var categoryEdit = await CategoryById(categoryId);

            if (categoryEdit.Data is null) {

                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

            
            }
            var category = _mapper.Map<Categoria>(requestDto);
            category.IdCategoria = categoryId;
            response.Data = await _unitOfWork.Categoria.EditCategory(category);

            if (response.Data)
            {

                response.isSucces = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;

            }
            else { 
            
                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response; 
        }


        public async Task<BaseResponse<bool>> RemoveCategory(int categoryId)
        {
            var response = new BaseResponse<bool>();

            var category = await CategoryById(categoryId);

            if(category.Data is null)
            {
                response.isSucces = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

            }


            response.Data = await _unitOfWork.Categoria.RemoveCategory(categoryId);

            if (response.Data) { 
            
                response.isSucces|= true;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response; 
        }
    }
}

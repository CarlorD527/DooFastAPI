using DF.Application.Dtos.Request;
using DF.Application.Interfaces;
using DF.Domain.Entities;
using DF.Infrastructure.Commons.Bases.Request;
using DF.Infrastructure.Persistences.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoriaController(ICategoryApplication cateoApplication)
        {

            _categoryApplication = cateoApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListCategories([FromBody] BaseFilterRequest filters) { 
        
            var response = await _categoryApplication.ListCategories(filters);
            return Ok(response);
        }

        [HttpGet("select")]
        public async Task<ActionResult> listSelectCategories() {

            var response = await _categoryApplication.ListSelectCategories();

            return Ok(response);
        }
        [HttpGet("{categoryId:int}")]

        public async Task<IActionResult> CategoryById(int categoryId) {

            var response = await _categoryApplication.CategoryById(categoryId);

            return Ok(response);
        
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterCategory([FromBody] CategoryRequestDto requestDto)

        {
            var response = await _categoryApplication.RegisterCategory(requestDto);

            return Ok(response); 
        }

        [HttpPut("Edit/{categoryId:int}")]

        public async Task<IActionResult> EditCategory(int categoryId, [FromBody] CategoryRequestDto requestDto) {

            var response = await _categoryApplication.EditCategory(categoryId, requestDto);
            return Ok(response);
        }
        [HttpPut("Remove/{categoryId:int}")]
        public async Task<IActionResult> RemoveCategory(int categoryId)
        {

            var response = await _categoryApplication.RemoveCategory(categoryId);
            return Ok(response);
        }

    }
}

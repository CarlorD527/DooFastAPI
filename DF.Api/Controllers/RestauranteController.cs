using DF.Application.Dtos.Request;
using DF.Application.Interfaces;
using DF.Application.Services;
using DF.Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly IRestauranteApplication _restauranteApplication;

        public RestauranteController(IRestauranteApplication resApplication)
        {

            _restauranteApplication = resApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListRestaurantes([FromBody] BaseFilterRequest filters)
        {

            var response = await _restauranteApplication.ListRestaurantes(filters);
            return Ok(response);
        }

        [HttpGet("select")]
        public async Task<ActionResult> listSelectRestaurantes()
        {

            var response = await _restauranteApplication.ListSelectRestaurantes();

            return Ok(response);
        }
        [HttpGet("{restauranteId:int}")]

        public async Task<IActionResult> RestauranteById(int restauranteId)
        {

            var response = await _restauranteApplication.RestauranteById(restauranteId);

            return Ok(response);

        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterRestaurante([FromBody] RestauranteRequestDto requestDto)

        {
            var response = await _restauranteApplication.RegisterRestaurante(requestDto);

            return Ok(response);
        }

        [HttpPut("Edit/{restauranteId:int}")]

        public async Task<IActionResult> EditRestaurante(int restauranteId, [FromBody] RestauranteRequestDto requestDto)
        {

            var response = await _restauranteApplication.EditRestaurante(restauranteId, requestDto);
            return Ok(response);
        }
        [HttpPut("Remove/{restauranteId:int}")]
        public async Task<IActionResult> RemoveRestaurante(int restauranteId)
        {

            var response = await _restauranteApplication.RemoveRestaurante(restauranteId);
            return Ok(response);
        }
    }
}

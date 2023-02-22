using DF.Application.Dtos.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Application.Validators.Category
{
    public class RestauranteValidator : AbstractValidator<RestauranteRequestDto>
    {
        public RestauranteValidator()
        {
            RuleFor(x => x.NombreRestaurante).NotNull().WithMessage("El campo nombre de restaurante no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacio")
                .MaximumLength(50).WithMessage("El nombre del restaurante debe tener menos de 50 caracteres");

            RuleFor(x => x.Telefono).NotNull().WithMessage("El campo telefono de restaurante no puede ser nulo")
            .NotEmpty().WithMessage("El campo telefono no puede ser vacio")
            .MaximumLength(10).WithMessage("El numero de telefono debe tener menos de 8 caracteres");
        }

    }
}

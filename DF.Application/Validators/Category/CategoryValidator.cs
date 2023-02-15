using DF.Application.Dtos.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Application.Validators.Category
{
    public class CategoryValidator : AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Nombre).NotNull().WithMessage("El campo nombre de categoria no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacio")
                .MaximumLength(50).WithMessage("El nombre de lacategoria debe tener menos de 50 caracteres");
        }
    }
}

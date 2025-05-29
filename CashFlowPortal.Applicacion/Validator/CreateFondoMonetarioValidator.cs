using CashFlowPortal.Applicacion.DTOs.FondoMonetario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Validator
{
    public class CreateFondoMonetarioValidator : AbstractValidator<CreateFondoMonetarioDto>
    {
        public CreateFondoMonetarioValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100);

            RuleFor(x => x.Descripcion)
                .MaximumLength(200);
        }
    }
}

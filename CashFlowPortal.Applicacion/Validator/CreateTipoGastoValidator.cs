using CashFlowPortal.Applicacion.DTOs.TipoGasto;
using FluentValidation;

namespace CashFlowPortal.Applicacion.Validator
{
    public class CreateTipoGastoValidator: AbstractValidator<CreateTipoGastoDto>
    {
        public CreateTipoGastoValidator() 
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres.");
        }
    }
}

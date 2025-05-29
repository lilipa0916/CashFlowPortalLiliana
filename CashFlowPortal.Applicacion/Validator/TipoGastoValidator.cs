using CashFlowPortal.Applicacion.DTOs;
using FluentValidation;

namespace CashFlowPortal.Applicacion.Validator
{
    public class TipoGastoValidator : AbstractValidator<TipoGastoDto>
    {
        public TipoGastoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres");
        }
    }
}

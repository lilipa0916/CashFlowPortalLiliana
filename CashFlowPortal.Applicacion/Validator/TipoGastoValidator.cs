using CashFlowPortal.Applicacion.DTOs;
using CashFlowPortal.Applicacion.DTOs.TipoGasto;
using FluentValidation;

namespace CashFlowPortal.Applicacion.Validator
{
    public class TipoGastoValidator : AbstractValidator<CreateTipoGastoDto>
    {
        public TipoGastoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres");
        }
    }
}

using CashFlowPortal.Applicacion.DTOs.Deposito;
using FluentValidation;

namespace CashFlowPortal.Applicacion.Validator
{
    public class DepositoDtoValidator : AbstractValidator<DepositoDto>
    {
        public DepositoDtoValidator()
        {
            RuleFor(x => x.Fecha).NotEmpty();
            RuleFor(x => x.FondoMonetarioId).NotEmpty();
            RuleFor(x => x.Monto)
                .GreaterThan(0).WithMessage("El monto debe ser mayor que cero");
        }
    }
}

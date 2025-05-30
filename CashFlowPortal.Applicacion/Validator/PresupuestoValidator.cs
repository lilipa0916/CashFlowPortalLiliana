using CashFlowPortal.Applicacion.DTOs.Presupuesto;
using FluentValidation;

namespace CashFlowPortal.Applicacion.Validator
{
    public class PresupuestoValidator : AbstractValidator<PresupuestoDto>
    {
        public PresupuestoValidator()
        {
            RuleFor(x => x.UsuarioId).NotEmpty();
            RuleFor(x => x.TipoGastoId).NotEmpty();
            RuleFor(x => x.Mes).NotEmpty();
            RuleFor(x => x.Monto).GreaterThanOrEqualTo(0);
            RuleForEach(x => x.Detalles).SetValidator(new PresupuestoDetalleDtoValidator());
        }
    }
}

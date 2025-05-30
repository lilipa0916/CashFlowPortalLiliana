using CashFlowPortal.Applicacion.DTOs.Presupuesto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Validator
{
    public class PresupuestoDetalleDtoValidator : AbstractValidator<PresupuestoDetalleDto>
    {
        public PresupuestoDetalleDtoValidator()
        {
            RuleFor(x => x.TipoGastoId).NotEmpty();
            RuleFor(x => x.MontoPresupuestado)
                .GreaterThanOrEqualTo(0).WithMessage("El monto presupuestado no puede ser negativo");
        }
    }
}

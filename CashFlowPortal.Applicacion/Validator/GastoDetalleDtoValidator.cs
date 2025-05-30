using CashFlowPortal.Applicacion.DTOs.Gasto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Validator
{
    public class GastoDetalleDtoValidator : AbstractValidator<GastoDetalleDto>
    {
        public GastoDetalleDtoValidator()
        {
            RuleFor(x => x.TipoGastoId).NotEmpty();
            RuleFor(x => x.Monto)
                .GreaterThan(0).WithMessage("El monto debe ser mayor que cero");
        }
    }
}

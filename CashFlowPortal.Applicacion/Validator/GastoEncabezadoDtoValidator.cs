using CashFlowPortal.Applicacion.DTOs.Gasto;
using FluentValidation;

namespace CashFlowPortal.Applicacion.Validator
{
    public class GastoEncabezadoDtoValidator : AbstractValidator<GastoDto>
    {
        public GastoEncabezadoDtoValidator()
        {
            RuleFor(x => x.Fecha).NotEmpty();
            RuleFor(x => x.FondoMonetarioId).NotEmpty();
            RuleFor(x => x.Comercio).NotEmpty().MaximumLength(100);
            RuleFor(x => x.TipoDocumento).NotEmpty();
            RuleFor(x => x.Detalles)
                .NotEmpty().WithMessage("Debe agregar al menos un detalle")
                .ForEach(x => x.SetValidator(new GastoDetalleDtoValidator()));
        }
    }
}

using CashFlowPortal.Applicacion.DTOs.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Validator
{
    public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestDtoValidator()
        {
            RuleFor(x => x.Usuario)
                .NotEmpty().WithMessage("El nombre de usuario es requerido");

            RuleFor(x => x.Clave)
                .NotEmpty().WithMessage("La contraseña es requerida");
        }
    }
}

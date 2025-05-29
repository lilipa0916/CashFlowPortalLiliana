using CashFlowPortal.Applicacion.DTOs;
using CashFlowPortal.Applicacion.DTOs.Presupuesto;
using System.ComponentModel.DataAnnotations;

namespace CashFlowPortal.UnitTests
{
    public class PresupuestoTests
    {
        [Fact]
        public void Monto_Presupuesto_Deberia_Ser_Positivo()
        {
            var presupuesto = new PresupuestoDto
            {
                Monto = -5,
                TipoGastoId = 1,
                Mes = DateTime.Now.Month
            };

            var context = new ValidationContext(presupuesto);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(presupuesto, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("debe ser mayor"));
        }
    }
}

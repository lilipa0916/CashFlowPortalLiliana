using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.DTOs.Auth
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string Rol { get; set; } = null!;

        public DateTime ExpiraEn { get; set; }
    }
}

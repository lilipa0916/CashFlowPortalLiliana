﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.DTOs.TipoGasto
{
    public class TipoGastoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Codigo { get; set; } = null!;
    }
}

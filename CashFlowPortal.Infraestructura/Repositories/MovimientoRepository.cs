using CashFlowPortal.Applicacion.DTOs.Consulta;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Infraestructura.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly AppDbContext _context;
        public MovimientoRepository(AppDbContext context) => _context = context;

        public async Task<List<MovimientoDto>> GetMovimientosAsync(DateTime desde, DateTime hasta)
        {
            var gastos = await _context.Gastos
                .Where(g => g.Fecha >= desde && g.Fecha <= hasta)
                .Select(g => new MovimientoDto
                {
                    Fecha = g.Fecha,
                    Tipo = "Gasto",
                    Fondo = g.FondoMonetario.Nombre,
                    Comercio = g.Comercio,
                    Monto = g.Detalles.Sum(d => d.Monto)
                }).ToListAsync();

            var depositos = await _context.Depositos
                .Where(d => d.Fecha >= desde && d.Fecha <= hasta)
                .Select(d => new MovimientoDto
                {
                    Fecha = d.Fecha,
                    Tipo = "Depósito",
                    Fondo = d.FondoMonetario.Nombre,
                    Comercio = null,
                    Monto = d.Monto
                }).ToListAsync();

            return gastos.Concat(depositos)
                         .OrderBy(m => m.Fecha)
                         .ToList();
        }
    }
}

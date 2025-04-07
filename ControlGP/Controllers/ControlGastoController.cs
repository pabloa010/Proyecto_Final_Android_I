using Microsoft.EntityFrameworkCore;
using ControlGP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlGP.Controllers
{
    public interface IControlGastosController
    {
        Task<List<ControlGasto>> Get(DateTime fechaInicio, DateTime fechaFin);
        Task<decimal> GetSumaGastosIngreso(DateTime fechaInicio, DateTime fechaFin);
        Task<decimal> GetSumaGastosEgreso(DateTime fechaInicio, DateTime fechaFin);
        Task<decimal> GetTotalGastos();
    }
    public class ControlGastoController:IControlGastosController
    {
        private readonly IDbContextFactory<dbContext> db;

        public ControlGastoController(IDbContextFactory<dbContext> dbContextFactory)
        {
            db = dbContextFactory;
        }

        public async Task<List<ControlGasto>> Get(DateTime fechaInicio, DateTime fechaFin)
        {
            using var context = db.CreateDbContext();
            return await context.ControlGastos
                .Where(c => c.Fecha >= fechaInicio && c.Fecha <= fechaFin)
                .ToListAsync();
        }

        public async Task<decimal> GetSumaGastosIngreso(DateTime fechaInicio, DateTime fechaFin)
        {
            using var context = db.CreateDbContext();
            return await context.ControlGastos
                .Where(a => a.Tipo == "Ingreso" && a.Fecha >= fechaInicio && a.Fecha <= fechaFin)
                .SumAsync(a => a.Monto);
        }

        public async Task<decimal> GetSumaGastosEgreso(DateTime fechaInicio, DateTime fechaFin)
        {
            using var context = db.CreateDbContext();
            return await context.ControlGastos
                .Where(a => a.Tipo == "Egreso" && a.Fecha >= fechaInicio && a.Fecha <= fechaFin)
                .SumAsync(a => a.Monto);
        }

        public async Task<decimal> GetTotalGastos()
        {
            using var context = db.CreateDbContext();
            var Ingreso = await context.ControlGastos
                                .Where(a => a.Tipo == "Ingreso")
                                .SumAsync(a => a.Monto);
            var Egreso = await context.ControlGastos
                                .Where(a => a.Tipo == "Egreso")
                                .SumAsync(a => a.Monto);

            var TotalGasto = Ingreso - Egreso;

            return TotalGasto;
        }

    }
}

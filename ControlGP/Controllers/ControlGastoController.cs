using Microsoft.EntityFrameworkCore;
using ControlGP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlGP.Controllers
{
    public interface IControlGastosController
    {
        Task<List<ControlGasto>> Get();
        Task<decimal> GetSumaGastosIngreso();
        Task<decimal> GetSumaGastosEgreso();
        Task<decimal> GetTotalGastos();
    }
    public class ControlGastoController:IControlGastosController
    {
        private readonly IDbContextFactory<dbContext> db;

        public ControlGastoController(IDbContextFactory<dbContext> dbContextFactory)
        {
            db = dbContextFactory;
        }

        public async Task<List<ControlGasto>> Get()
        {
            using var context = db.CreateDbContext();
            return await context.ControlGastos.ToListAsync();
        }

        public async Task<decimal> GetSumaGastosIngreso()
        {
            using var context = db.CreateDbContext();
            return await context.ControlGastos
                                .Where(a => a.Tipo == "Ingreso")
                                .SumAsync(a => a.Monto);
        }

        public async Task<decimal> GetSumaGastosEgreso()
        {
            using var context = db.CreateDbContext();
            return await context.ControlGastos
                                .Where(a => a.Tipo == "Egreso")
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

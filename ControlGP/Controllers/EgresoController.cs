using Microsoft.EntityFrameworkCore;
using ControlGP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGP.Controllers
{
    public interface IEgresoController
    {
        Task<List<Egreso>> Get();
        Task<int> Insert(Egreso Entidad);
        Task<bool> Update(Egreso Entidad);
        Task<bool> Delete(Egreso Entidad);

    }
    public class EgresoController : IEgresoController
    {
        readonly IDbContextFactory<dbContext> db;
        public EgresoController(IDbContextFactory<dbContext> dbContextFactory)
        {
            db = dbContextFactory;
        }
        public async Task<List<Egreso>> Get()
        {
            using var context = db.CreateDbContext();
            return await context.Egreso.ToListAsync();
        }

        public async Task<int> Insert(Egreso Entidad)
        {
            using var context = db.CreateDbContext();
            context.Egreso.Add(Entidad);
            await context.SaveChangesAsync();
            return Entidad.IdEgreso;
        }

        public async Task<bool> Update(Egreso Entidad)
        {
            using var context = db.CreateDbContext();
            context.Egreso.Update(Entidad);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Egreso Entidad)
        {
            using var context = db.CreateDbContext();
            context.Egreso.Remove(Entidad);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

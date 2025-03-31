using Microsoft.EntityFrameworkCore;
using ControlGP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGP.Controllers
{
    public interface IIngresoController
    {
        Task<List<Ingreso>> Get();
        Task<int> Insert(Ingreso Entidad);
        Task<bool> Update(Ingreso Entidad);
        Task<bool> Delete(Ingreso Entidad);

    }
    public class IngresoController:IIngresoController
    {
        readonly IDbContextFactory<dbContext> db;
        public IngresoController(IDbContextFactory<dbContext> dbContextFactory)
        {
            db = dbContextFactory;
        }
        public async Task<List<Ingreso>> Get()
        {
            using var context = db.CreateDbContext();
            return await context.Ingreso.ToListAsync();
        }

        public async Task<int> Insert(Ingreso Entidad)
        {
            using var context = db.CreateDbContext();
            context.Ingreso.Add(Entidad);
            await context.SaveChangesAsync();
            return Entidad.IdIngreso;
        }

        public async Task<bool> Update(Ingreso Entidad)
        {
            using var context = db.CreateDbContext();
            context.Ingreso.Update(Entidad);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Ingreso Entidad)
        {
            using var context = db.CreateDbContext();
            context.Ingreso.Remove(Entidad);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

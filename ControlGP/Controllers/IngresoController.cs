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
            return await context.Ingreso.Where(a=>a.Activo).ToListAsync();
        }

        public async Task<int> Insert(Ingreso Entidad)
        {
            using var context = db.CreateDbContext();
            context.Ingreso.Add(Entidad);
            Entidad.Activo = true;
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
            using var Conexion = db.CreateDbContext();
            var Registro = await Conexion.Ingreso.Where(a => a.IdIngreso == Entidad.IdIngreso).SingleOrDefaultAsync();
            if (Registro != null)
            {
                Registro.Activo = false;
                return await Conexion.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}

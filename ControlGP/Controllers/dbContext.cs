using Microsoft.EntityFrameworkCore;
using ControlGP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGP.Controllers
{
    public class dbContext : DbContext
    {
        public virtual DbSet<Ingreso> Ingreso { get; set; }
        public virtual DbSet<Egreso> Egreso { get; set; }

        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}

using Microsoft.EntityFrameworkCore;

namespace PruebaFall.Model
{
    public class ContextoBD: DbContext
    {
       public ContextoBD(DbContextOptions<ContextoBD> options) : base(options) { }

        public DbSet<Dato> Datos { get; set; }
        public DbSet<Cancelacion> Cancelaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
        }
    }
}
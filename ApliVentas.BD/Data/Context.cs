using ApliVentas.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApliVentas.BD.Data
{
    public class Context : DbContext

    {
        public DbSet<Ganancia> Ganancias => Set<Ganancia>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<PrecioFinal> precioFinals => Set<PrecioFinal>();
        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}

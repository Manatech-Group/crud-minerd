using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using AppCrudMinerd.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppCrudMinerd.Persistence.Context
{
    public class AppCrudMinerdContext : DbContext
    {
        public AppCrudMinerdContext(DbContextOptions<AppCrudMinerdContext> options)
            : base(options)
        {
        }

        // Agrega tu DbSet para la tabla Minerd
        public DbSet<DataMinerd> DATA_MINERD { get; set; }

        // Aquí puedes agregar configuraciones adicionales si lo necesitas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones adicionales si las necesitas
            modelBuilder.Entity<DataMinerd>().ToTable("DATA_MINERD", "dbo");
        }
    }
}

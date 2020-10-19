using Hermoza.BibloMax.Datos.Modelos;
using Hermoza.BibloMax.Datos.Modelos.Mapeo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Datos.Infraestructura.Contextos
{
    public class SOContexto : DbContext
    {

        public SOContexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMapeo());
            modelBuilder.ApplyConfiguration(new PersonaMapeo());
            modelBuilder.ApplyConfiguration(new SedeMapeo());
            modelBuilder.ApplyConfiguration(new ComplejoMapeo());

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Sede> Sede { get; set; }
        public DbSet<Complejo> Complejo { get; set; }

    }
}

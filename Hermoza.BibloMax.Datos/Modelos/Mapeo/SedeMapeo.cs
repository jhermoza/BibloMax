using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Datos.Modelos.Mapeo
{
    class SedeMapeo : IEntityTypeConfiguration<Sede>
    {
        public void Configure(EntityTypeBuilder<Sede> builder)
        {
            builder.ToTable("Sede", "dbo");
            builder.HasKey(e => e.IdSede);
            builder.Property(e => e.IdSede).HasColumnName("IdSede").IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Nombre).HasColumnName("Nombre").IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.Ubicacion).HasColumnName("Ubicacion").IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.NroComplejos).HasColumnName("NroComplejos").IsRequired();
            builder.Property(x => x.Presupuesto).HasColumnName("Presupuesto").IsRequired();
            builder.Property(x => x.Creado).HasColumnName("Creado").IsRequired();
            builder.Property(x => x.Actualizado).HasColumnName("Actualizado").IsRequired();
            builder.Property(x => x.Borrado).HasColumnName("Borrado");
            builder.Property(x => x.EstaBorrado).HasColumnName("EstaBorrado").IsRequired();

        }
    }
}

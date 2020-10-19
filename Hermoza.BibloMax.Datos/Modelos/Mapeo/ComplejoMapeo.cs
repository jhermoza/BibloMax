using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Datos.Modelos.Mapeo
{
    public class ComplejoMapeo : IEntityTypeConfiguration<Complejo>
    {
        public void Configure(EntityTypeBuilder<Complejo> builder)
        {
            builder.ToTable("Complejo", "dbo");
            builder.HasKey(e => e.IdComplejo);
            builder.Property(e => e.IdComplejo).HasColumnName("IdComplejo").IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Localidad).HasColumnName("Localidad").IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.Jefe).HasColumnName("Jefe").IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.AreaTotal).HasColumnName("AreaTotal").IsRequired();
            builder.Property(x => x.Creado).HasColumnName("Creado").IsRequired();
            builder.Property(x => x.Actualizado).HasColumnName("Actualizado").IsRequired();
            builder.Property(x => x.Borrado).HasColumnName("Borrado");
            builder.Property(x => x.EstaBorrado).HasColumnName("EstaBorrado").IsRequired();
            builder.Property(x => x.IdSede).HasColumnName("IdSede").IsRequired();

            builder.HasOne(a => a.Sede).WithMany(b => b.Complejos).HasForeignKey(c => c.IdSede);

        }
    }
}

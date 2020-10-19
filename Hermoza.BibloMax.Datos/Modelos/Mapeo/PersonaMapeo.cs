using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Datos.Modelos.Mapeo
{
    class PersonaMapeo : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Persona", "dbo");
            builder.HasKey(e => e.IdPersona);
            builder.Property(e => e.IdPersona).HasColumnName("IdPersona").IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Nombre).HasColumnName("Nombre").IsUnicode(false).HasMaxLength(50).IsRequired();
            builder.Property(x => x.APaterno).HasColumnName("APaterno").IsUnicode(false).HasMaxLength(50).IsRequired();
            builder.Property(x => x.AMaterno).HasColumnName("AMaterno").IsUnicode(false).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Telefono).HasColumnName("Telefono").IsUnicode(false).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Correo).HasColumnName("Correo").IsUnicode(false).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Direccion).HasColumnName("Direccion").IsUnicode(false).HasMaxLength(100).IsRequired();
            builder.Property(x => x.FechaNacimiento).HasColumnName("FechaNacimiento").IsUnicode(false).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Creado).HasColumnName("Creado").IsRequired();
            builder.Property(x => x.Actualizado).HasColumnName("Actualizado").IsRequired();
            builder.Property(x => x.Borrado).HasColumnName("Borrado");
            builder.Property(x => x.EstaBorrado).HasColumnName("EstaBorrado").IsRequired();

            builder.HasOne(a => a.Usuario).WithOne(b => b.Persona).HasForeignKey<Persona>(b => b.IdUsuario);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Datos.Modelos.Mapeo
{
    public class UsuarioMapeo : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "dbo");
            builder.HasKey(e => e.IdUsuario);
            builder.Property(e => e.IdUsuario).HasColumnName("IdUsuario").IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Username).HasColumnName("Username").IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.Password).HasColumnName("Password").IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt").IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.Creado).HasColumnName("Creado").IsRequired();
            builder.Property(x => x.Actualizado).HasColumnName("Actualizado").IsRequired();
            builder.Property(x => x.Borrado).HasColumnName("Borrado");
            builder.Property(x => x.EstaBorrado).HasColumnName("EstaBorrado").IsRequired();

        }
    }
}

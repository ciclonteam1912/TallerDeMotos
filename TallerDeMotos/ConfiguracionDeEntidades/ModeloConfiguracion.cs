﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ConfiguracionDeEntidades
{
    public class ModeloConfiguracion : EntityTypeConfiguration<Modelo>
    {
        public ModeloConfiguracion()
        {
            ToTable("Modelos");

            Property(m => m.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(v => v.CilindradaId)
                .HasColumnName("CilindradaCodigo");

            Property(m => m.MarcaId)
                .HasColumnName("MarcaCodigo");

            Property(v => v.TipoMotorId)
                .HasColumnName("TipoMotorCodigo");

            Property(m => m.Nombre)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_NombreModelo", 1) { IsUnique = true }));


            HasRequired(v => v.Cilindrada)
                .WithMany(c => c.Modelos)
                .WillCascadeOnDelete(false);

            HasRequired(v => v.TipoMotor)
                .WithMany(c => c.Modelos)
                .WillCascadeOnDelete(false);
        }
    }
}
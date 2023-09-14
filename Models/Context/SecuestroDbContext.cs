﻿using System.Globalization;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Secuestro.Models;

public partial class SecuestroDbContext : DbContext
{
    public SecuestroDbContext()
    {
    }

    public SecuestroDbContext(DbContextOptions<SecuestroDbContext> options, IConfiguration config)
        : base(options)
    {
        
    }

    public virtual DbSet<BandejaTrabajo> BandejaTrabajos { get; set; }

    public virtual DbSet<SecuestroBiene> SecuestroBienes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
        
        List<BandejaTrabajo> bandejaTrabajos = new List<BandejaTrabajo>();
        bandejaTrabajos.Add(new BandejaTrabajo(){
            Id = 1,
            TipoObligacion = "Tránsito",
            EtapaMc = "Secuestro",
            FkNumResolucionEmbargo = "246810",
            NoProcesoGc = "123",
            TipoDocCiudadanoEmpresa = "CC",
            NroDocCiudadanoEmpresa = "100023233",
            NombreCiudadanoEmpresa = "Abogado1 Reyes",
            FechaPreinscripcion = DateTime.Now
        });

        /*
        secuestroBienes.Add(new SecuestroBiene(){
            NoResolucionEmbargo = "246810",
            FechaResolucionEmbargo = new DateTime(2022, 3, 10),
            TipoBien = "Inmueble",
            Entidad = "CDC",
            NoProcesoGc = "123",
            TipoObligacion = "Tránsito",
            TipoDocumento = "CC",
            NumeroDocumento = "1200985576",
            NombreCiudadano = "Fulanito De Tal",
            ValorNominal = 2000,
            Interes = 20,
            Saldo = 1500000m,
            Total = 339774.56m,
            FechaCalculada = new DateTime(2023, 2, 15),
            Diligencia = true
        });*/

        modelBuilder.Entity<BandejaTrabajo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bandeja___3213E83F2B026E74");
    
            entity.ToTable("Bandeja_trabajo");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EtapaMc)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Etapa_mc");
            entity.Property(e => e.FechaPreinscripcion)
                .HasColumnType("date")
                .HasColumnName("Fecha_preinscripcion");
            entity.Property(e => e.FkNumResolucionEmbargo)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fk_num_resolucion_embargo");
            entity.Property(e => e.NoProcesoGc)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("No_proceso_GC");
            entity.Property(e => e.NombreCiudadanoEmpresa)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_ciudadano_empresa");
            entity.Property(e => e.NroDocCiudadanoEmpresa)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nro_doc_ciudadano_empresa");
            entity.Property(e => e.TipoDocCiudadanoEmpresa)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tipo_doc_ciudadano_empresa");
            entity.Property(e => e.TipoObligacion)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Tipo_obligacion");

            entity.HasData(bandejaTrabajos);
        });
    
        List<SecuestroBiene> secuestroBienes = new List<SecuestroBiene>();
        secuestroBienes.Add(new SecuestroBiene(){
            NoResolucionEmbargo = "1234567",
            FechaResolucionEmbargo = new DateTime(2021, 7, 25),
            TipoBien = "Inmueble",
            Entidad = "Agustín Codazzi",
            NoProcesoGc = "123",
            TipoObligacion = "Tránsito",
            TipoDocumento = "CC",
            NumeroDocumento = "56789000",
            NombreCiudadano = "Juanito Alimaña",
            ValorNominal = 100,
            Interes = 17,
            Saldo = 2000000m,
            Total = 762553.56m,
            FechaCalculada = new DateTime(2022, 3, 5),
            Diligencia = false
        });
        secuestroBienes.Add(new SecuestroBiene(){
            NoResolucionEmbargo = "246810",
            FechaResolucionEmbargo = new DateTime(2022, 3, 10),
            TipoBien = "Inmueble",
            Entidad = "CDC",
            NoProcesoGc = "123",
            TipoObligacion = "Tránsito",
            TipoDocumento = "CC",
            NumeroDocumento = "1200985576",
            NombreCiudadano = "Fulanito De Tal",
            ValorNominal = 2000,
            Interes = 20,
            Saldo = 1500000m,
            Total = 339774.56m,
            FechaCalculada = new DateTime(2023, 2, 15),
            Diligencia = true
        });

        modelBuilder.Entity<SecuestroBiene>(entity =>
        {

            entity.HasKey(e => e.NoResolucionEmbargo);
    
            entity.ToTable("Secuestro_bienes");
    
            entity.Property(e => e.NoResolucionEmbargo)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("No_resolucion_embargo");
            entity.Property(e => e.FechaResolucionEmbargo)
                .HasColumnType("date")
                .HasColumnName("Fecha_resolucion_embargo");
            entity.Property(e => e.TipoBien)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Tipo_bien");
            entity.Property(e => e.Entidad)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NoProcesoGc)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("No_proceso_GC");
            entity.Property(e => e.TipoObligacion)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Tipo_obligacion");
            entity.Property(e => e.TipoDocumento)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Tipo_documento");
            entity.Property(e => e.NumeroDocumento)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Numero_documento");
            entity.Property(e => e.NombreCiudadano)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_ciudadano");
            entity.Property(e => e.ValorNominal)
                .HasColumnType("money")
                .HasColumnName("Valor_nominal");
            entity.Property(e => e.Interes).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Saldo).HasColumnType("money");
            entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

            entity.HasData(secuestroBienes);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NURBNB.Alojamiento.Infrastructure.EF.Context;

#nullable disable

namespace NURBNB.Alojamiento.Infrastructure.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    partial class ReadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.CiudadReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ciudadId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("nombre");

                    b.Property<Guid>("PaisId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("paisId");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("ciudad");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.ComodidadReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("descripcion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("comodidad");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.DireccionReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Avenida")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("avenida");

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("calle");

                    b.Property<Guid>("CiudadId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ciudadId");

                    b.Property<double>("Latitud")
                        .HasColumnType("float")
                        .HasColumnName("latitud");

                    b.Property<double>("Longitud")
                        .HasColumnType("float")
                        .HasColumnName("longitud");

                    b.Property<Guid>("PropiedadId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("propiedadId");

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("referencia");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.HasIndex("PropiedadId")
                        .IsUnique();

                    b.ToTable("direccion");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.FotoReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("PropiedadId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("propiedadId");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.HasIndex("PropiedadId");

                    b.ToTable("foto");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.PaisReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("paisId");

                    b.Property<string>("CodigoPais")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("paisCode");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("pais");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.PropiedadComodidadReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("ComodidadId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("comodidadId");

                    b.Property<Guid>("PropiedadId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("propiedadId");

                    b.HasKey("Id");

                    b.HasIndex("ComodidadId");

                    b.HasIndex("PropiedadId");

                    b.ToTable("propiedadComodidad");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.PropiedadReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("propiedadId");

                    b.Property<int>("Camas")
                        .HasColumnType("int")
                        .HasColumnName("camas");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("descripcion");

                    b.Property<int>("Habitaciones")
                        .HasColumnType("int")
                        .HasColumnName("habitaciones");

                    b.Property<int>("Personas")
                        .HasColumnType("int")
                        .HasColumnName("personas");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("precio");

                    b.Property<string>("TipoPropiedad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("tipoPropiedad");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("titulo");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("usuarioId");

                    b.HasKey("Id");

                    b.ToTable("propiedad");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.ReglaReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("PropiedadId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("propiedadId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.HasIndex("PropiedadId");

                    b.ToTable("regla");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.ReservaReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("EstadoReserva")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("estadoReserva");

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaEntrada");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaSalida");

                    b.Property<Guid>("PropiedadId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("propiedadId");

                    b.HasKey("Id");

                    b.HasIndex("PropiedadId");

                    b.ToTable("reserva");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.TransaccionReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("transaccionId");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("monto");

                    b.Property<Guid>("ReservaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("reservaId");

                    b.Property<string>("TipoTransaccion")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("tipoTransaccion");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("usuarioId");

                    b.HasKey("Id");

                    b.ToTable("transaccion");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.CiudadReadModel", b =>
                {
                    b.HasOne("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.PaisReadModel", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.DireccionReadModel", b =>
                {
                    b.HasOne("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.CiudadReadModel", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.PropiedadReadModel", "Propiedad")
                        .WithOne("Direccion")
                        .HasForeignKey("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.DireccionReadModel", "PropiedadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");

                    b.Navigation("Propiedad");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.FotoReadModel", b =>
                {
                    b.HasOne("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.PropiedadReadModel", null)
                        .WithMany("Fotos")
                        .HasForeignKey("PropiedadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.PropiedadComodidadReadModel", b =>
                {
                    b.HasOne("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.ComodidadReadModel", "Comodidad")
                        .WithMany()
                        .HasForeignKey("ComodidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.PropiedadReadModel", "Propiedad")
                        .WithMany("Comodidades")
                        .HasForeignKey("PropiedadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comodidad");

                    b.Navigation("Propiedad");
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.ReglaReadModel", b =>
                {
                    b.HasOne("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.PropiedadReadModel", null)
                        .WithMany("Reglas")
                        .HasForeignKey("PropiedadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.ReservaReadModel", b =>
                {
                    b.HasOne("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.PropiedadReadModel", null)
                        .WithMany("Reservas")
                        .HasForeignKey("PropiedadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NURBNB.Alojamiento.Infrastructure.EF.ReadModel.PropiedadReadModel", b =>
                {
                    b.Navigation("Comodidades");

                    b.Navigation("Direccion");

                    b.Navigation("Fotos");

                    b.Navigation("Reglas");

                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}

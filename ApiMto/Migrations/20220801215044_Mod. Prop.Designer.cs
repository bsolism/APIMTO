﻿// <auto-generated />
using System;
using ApiMto.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiMto.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220801215044_Mod. Prop")]
    partial class ModProp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiMto.Models.Agencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Agencias");
                });

            modelBuilder.Entity("ApiMto.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ApiMto.Models.Camera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<string>("AssetId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("DeviceDescription")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("DeviceId")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInstalacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirmwareVersion")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Mac")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Nota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Online")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("PatchPanel")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int?>("PortChannel")
                        .HasColumnType("int");

                    b.Property<int?>("PortPatchPanel")
                        .HasColumnType("int");

                    b.Property<int?>("PortSwitch")
                        .HasColumnType("int");

                    b.Property<bool>("Retired")
                        .HasColumnType("bit");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.Property<string>("Switch")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("UbicacionConexion")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("UbicacionFisica")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("BrandId");

                    b.HasIndex("ServerId");

                    b.ToTable("Camera", "dbo");
                });

            modelBuilder.Entity("ApiMto.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CameraId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("CameraId");

                    b.ToTable("Evento", "dbo");
                });

            modelBuilder.Entity("ApiMto.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CameraId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Evento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CameraId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Log", "dbo");
                });

            modelBuilder.Entity("ApiMto.Models.LogServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Evento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("LogServer", "dbo");
                });

            modelBuilder.Entity("ApiMto.Models.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AssetId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CanalesIP")
                        .HasColumnType("int");

                    b.Property<int>("CapacidadSata")
                        .HasColumnType("int");

                    b.Property<int>("CapacidadSataInstalado")
                        .HasColumnType("int");

                    b.Property<string>("DeviceId")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("EngravedDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInstalacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirmwareVersion")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Mac")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<bool>("Online")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("PortAnalogo")
                        .HasColumnType("int");

                    b.Property<int>("PortIpPoe")
                        .HasColumnType("int");

                    b.Property<bool>("Retired")
                        .HasColumnType("bit");

                    b.Property<int>("Sata")
                        .HasColumnType("int");

                    b.Property<int>("SataInstalado")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("nota")
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Server", "dbo");
                });

            modelBuilder.Entity("ApiMto.Models.ServerDataSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DataSheetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("ServerDataSheets");
                });

            modelBuilder.Entity("ApiMto.Models.SrvAg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("ServerId");

                    b.ToTable("SrvAgs");
                });

            modelBuilder.Entity("ApiMto.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ApiMto.Models.Camera", b =>
                {
                    b.HasOne("ApiMto.Models.Agencia", "Agencia")
                        .WithMany("Cameras")
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiMto.Models.Brand", "Brand")
                        .WithMany("Cameras")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiMto.Models.Server", "Server")
                        .WithMany("Cameras")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Agencia");

                    b.Navigation("Brand");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("ApiMto.Models.Evento", b =>
                {
                    b.HasOne("ApiMto.Models.Camera", "Camera")
                        .WithMany()
                        .HasForeignKey("CameraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camera");
                });

            modelBuilder.Entity("ApiMto.Models.Log", b =>
                {
                    b.HasOne("ApiMto.Models.Camera", "Camera")
                        .WithMany()
                        .HasForeignKey("CameraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiMto.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camera");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiMto.Models.LogServer", b =>
                {
                    b.HasOne("ApiMto.Models.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiMto.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiMto.Models.Server", b =>
                {
                    b.HasOne("ApiMto.Models.Brand", "Brand")
                        .WithMany("Servers")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ApiMto.Models.ServerDataSheet", b =>
                {
                    b.HasOne("ApiMto.Models.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("ApiMto.Models.SrvAg", b =>
                {
                    b.HasOne("ApiMto.Models.Agencia", "Agencia")
                        .WithMany("SrvAg")
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiMto.Models.Server", "Server")
                        .WithMany("srvAgs")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agencia");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("ApiMto.Models.Agencia", b =>
                {
                    b.Navigation("Cameras");

                    b.Navigation("SrvAg");
                });

            modelBuilder.Entity("ApiMto.Models.Brand", b =>
                {
                    b.Navigation("Cameras");

                    b.Navigation("Servers");
                });

            modelBuilder.Entity("ApiMto.Models.Server", b =>
                {
                    b.Navigation("Cameras");

                    b.Navigation("srvAgs");
                });
#pragma warning restore 612, 618
        }
    }
}

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
    [Migration("20220429184234_Init")]
    partial class Init
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

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateBuys")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateInstallation")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceDescription")
                        .HasColumnType("text");

                    b.Property<string>("DeviceId")
                        .HasColumnType("text");

                    b.Property<string>("FirmwareVersion")
                        .HasColumnType("text");

                    b.Property<string>("IdPatchPanel")
                        .HasColumnType("text");

                    b.Property<string>("IdSwitch")
                        .HasColumnType("text");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsGoodCondition")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LocationConnection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mac")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PortPatchPanel")
                        .HasColumnType("int");

                    b.Property<int?>("PortSwitch")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ServerId");

                    b.ToTable("Camera", "dbo");
                });

            modelBuilder.Entity("ApiMto.Models.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CameraAvailable")
                        .HasColumnType("int");

                    b.Property<int>("CameraCapacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateBuys")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateInstallation")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceId")
                        .HasColumnType("text");

                    b.Property<int>("EngravedDays")
                        .HasColumnType("int");

                    b.Property<string>("FirmwareVersion")
                        .HasColumnType("text");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mac")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StorageAvailable")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isGoodCondition")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("BrandId");

                    b.ToTable("Server", "dbo");
                });

            modelBuilder.Entity("ApiMto.Models.Camera", b =>
                {
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

                    b.Navigation("Brand");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("ApiMto.Models.Server", b =>
                {
                    b.HasOne("ApiMto.Models.Agencia", "Agencia")
                        .WithMany("Servers")
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ApiMto.Models.Brand", "Brand")
                        .WithMany("Servers")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Agencia");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ApiMto.Models.Agencia", b =>
                {
                    b.Navigation("Servers");
                });

            modelBuilder.Entity("ApiMto.Models.Brand", b =>
                {
                    b.Navigation("Cameras");

                    b.Navigation("Servers");
                });

            modelBuilder.Entity("ApiMto.Models.Server", b =>
                {
                    b.Navigation("Cameras");
                });
#pragma warning restore 612, 618
        }
    }
}
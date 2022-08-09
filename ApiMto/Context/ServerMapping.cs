using ApiMto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMto.Context
{
    public class ServerMapping : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.ToTable("Server", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property<int>(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property<string>(x => x.Nombre).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.User).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.Password).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x=> x.Ubicacion).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x=> x.Type).HasColumnType("nvarchar(MAX)");
            builder.Property<int>(x => x.BrandId).HasColumnType("int");
            builder.Property<int>(x => x.PortAnalogo).HasColumnType("int");
            builder.Property<int>(x => x.PortIpPoe).HasColumnType("int");
            builder.Property<int>(x => x.CanalesIP).HasColumnType("int");
            builder.Property<string>(x => x.nota).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.IpAddress).HasColumnType("nvarchar(MAX)");
            builder.Property<int>(x => x.Sata).HasColumnType("int");
            builder.Property<int>(x => x.CapacidadSata).HasColumnType("int");
            builder.Property<int>(x => x.SataInstalado).HasColumnType("int");
            builder.Property<int>(x => x.CapacidadSataInstalado).HasColumnType("int");
            builder.Property<int>(x => x.EngravedDays).HasColumnType("int");
            builder.Property<bool>(x => x.Online).HasColumnType("bit");
            builder.Property<DateTime>(x => x.FechaInstalacion).HasColumnType("datetime2");
            builder.Property<DateTime>(x => x.FechaCompra).HasColumnType("datetime2");
            builder.Property<string>(x => x.Mac).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.Modelo).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.DeviceId).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.FirmwareVersion).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.SerialNumber).HasColumnType("nvarchar(MAX)");
           
            

            builder.HasOne(x => x.Brand)
                .WithMany(x => x.Servers)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.NoAction);
            



        }
    }
}

using ApiMto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMto.Context
{
    public class CameraMapping : IEntityTypeConfiguration<Camera>
    {
        public void Configure(EntityTypeBuilder<Camera> builder)
        {
            builder.ToTable("Camera", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property<int>(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property<string>(x => x.Name).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.User).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.Password).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.Location).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.Type).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.Model).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.IpAddress).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.Mac).HasColumnType("nvarchar(MAX)");
            builder.Property<int>(x => x.BrandId).HasColumnType("int");
            builder.Property<bool>(x => x.IsGoodCondition).HasColumnType("bit");
            builder.Property<DateTime>(x => x.DateInstallation).HasColumnType("datetime2");
            builder.Property<DateTime>(x => x.DateBuys).HasColumnType("datetime2");
            builder.Property<int>(x => x.ServerId).HasColumnType("int");
            builder.Property<string>(x => x.DeviceDescription).HasColumnType("nvarchar(MAX)").IsRequired(false);
            builder.Property<string>(x => x.DeviceId).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.FirmwareVersion).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.SerialNumber).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.IdPatchPanel).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.IdSwitch).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.LocationConnection).HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.PortPatchPanel).HasColumnType("int").IsRequired(false);
            builder.Property(x => x.PortSwitch).HasColumnType("int").IsRequired(false);

            builder.HasOne(x => x.Server)
                .WithMany(x => x.Cameras)
                .HasForeignKey(x => x.ServerId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Brand)
                .WithMany(x => x.Cameras)
                .HasForeignKey(x => x.BrandId);
        }
    }
}

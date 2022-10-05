using ApiMto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMto.Context
{
    public class CameraMapping : IEntityTypeConfiguration<Camera>
    {
        public void Configure(EntityTypeBuilder<Camera> builder)
        {
            builder.ToTable("Cameras", "dbo");
            //builder.HasKey(x => x.Id);
            //builder.Property<string>(x => x.Id).HasColumnType("nvarchar(Max)");
            //builder.Property<string>(x => x.Name).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.User).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.Password).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.Location).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.Connection).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.Type).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.Model).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.IpAddress).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.Mac).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.BrandId).HasColumnType("nvarchar(MAX)");
            //builder.Property<bool>(x => x.Online).HasColumnType("bit");
            //builder.Property<DateTime>(x => x.DateInstallation).HasColumnType("datetime2");
            //builder.Property<DateTime>(x => x.DateBuy).HasColumnType("datetime2");
            //builder.Property<string>(x => x.ServerId).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x=> x.AgencyId).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.DeviceDescription).HasColumnType("nvarchar(MAX)").IsRequired(false);
            //builder.Property<string>(x => x.DeviceId).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.FirmwareVersion).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.SerialNumber).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.PatchPanel).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.Switch).HasColumnType("nvarchar(MAX)");
            //builder.Property(x => x.PortPatchPanel).HasColumnType("int").IsRequired(false);
            //builder.Property(x => x.PortSwitch).HasColumnType("int").IsRequired(false);

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

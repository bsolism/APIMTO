using ApiMto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMto.Context
{
    public class ServerMapping : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.ToTable("Servers", "dbo");
            //builder.HasKey(x => x.Id);
            //builder.Property<string>(x => x.Name).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.User).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.Password).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x=> x.Location).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x=> x.Type).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.BrandId).HasColumnType("nvarchar(MAX)");
            //builder.Property<int>(x => x.PortAnalogo).HasColumnType("int");
            //builder.Property<int>(x => x.PortIpPoe).HasColumnType("int");
            //builder.Property<int>(x => x.ChannelIP).HasColumnType("int");
            //builder.Property<string>(x => x.Note).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.IpAddress).HasColumnType("nvarchar(MAX)");
            //builder.Property<int>(x => x.SlotSata).HasColumnType("int");
            //builder.Property<int>(x => x.CapacityBySlot).HasColumnType("int");
            //builder.Property<int>(x => x.SataAvailable).HasColumnType("int");
            //builder.Property<int>(x => x.CapacityTotal).HasColumnType("int");
            //builder.Property<int>(x => x.EngravedDays).HasColumnType("int");
            //builder.Property<bool>(x => x.Online).HasColumnType("bit");
            //builder.Property<DateTime>(x => x.DateInstallation).HasColumnType("datetime2");
            //builder.Property<DateTime>(x => x.DateBuy).HasColumnType("datetime2");
            //builder.Property<string>(x => x.Mac).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.Model).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.DeviceId).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.FirmwareVersion).HasColumnType("nvarchar(MAX)");
            //builder.Property<string>(x => x.SerialNumber).HasColumnType("nvarchar(MAX)");
           
            

            builder.HasOne(x => x.Brand)
                .WithMany(x => x.Servers)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.NoAction);
            



        }
    }
}

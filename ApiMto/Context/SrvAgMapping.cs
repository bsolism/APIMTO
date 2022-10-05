using ApiMto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMto.Context
{
    public class SrvAgMapping : IEntityTypeConfiguration<SrvAg>
    {
        public void Configure(EntityTypeBuilder<SrvAg> builder)
        {
            builder.ToTable("SrvAgs", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property<int>(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property<string>(x => x.AgencyId).HasColumnType("nvarchar(MAX)");
            builder.Property<string>(x => x.ServerId).HasColumnType("nvarchar(MAX)");
        }
    }
}

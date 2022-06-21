using ApiMto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMto.Context
{
    public class SrvAgMapping : IEntityTypeConfiguration<SrvAg>
    {
        public void Configure(EntityTypeBuilder<SrvAg> builder)
        {
            builder.ToTable("SrvAg", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property<int>(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property<int>(x => x.AgenciaId).HasColumnType("int");
            builder.Property<int>(x => x.ServerId).HasColumnType("int");
        }
    }
}

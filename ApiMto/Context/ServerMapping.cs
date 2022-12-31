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
              

            builder.HasOne(x => x.Brand)
                .WithMany(x => x.Servers)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=> x.Agency)
                .WithMany(x=> x.Servers)
                .HasForeignKey(x => x.AgencyId)
                .OnDelete(DeleteBehavior.NoAction);
            



        }
    }
}

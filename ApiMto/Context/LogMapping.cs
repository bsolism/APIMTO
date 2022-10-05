using ApiMto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMto.Context
{
    public class LogMapping: IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs", "dbo");
            builder.Property(e => e.Date).HasDefaultValueSql("getdate()");


        }
    }
}

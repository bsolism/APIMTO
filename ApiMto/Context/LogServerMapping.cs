using ApiMto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMto.Context
{
    public class LogServerMapping : IEntityTypeConfiguration<LogServer>
    {
        public void Configure(EntityTypeBuilder<LogServer> builder)
        {
            builder.ToTable("LogServers", "dbo");
            builder.Property(e => e.Date).HasDefaultValueSql("getdate()");


        }
    }
}

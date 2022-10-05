using ApiMto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMto.Context
{
    public class IncidentMapping : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.ToTable("Incidents", "dbo");
            builder.Property(e => e.Date).HasDefaultValueSql("getdate()");


        }
    }
}

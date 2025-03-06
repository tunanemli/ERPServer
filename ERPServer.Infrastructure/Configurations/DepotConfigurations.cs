using ERPServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Infrastructure.Configurations
{
    public sealed class DepotConfigurations : IEntityTypeConfiguration<Depot>
    {
        public void Configure(EntityTypeBuilder<Depot> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.City).IsRequired();
            builder.Property(P => P.FullAddress).IsRequired();
            builder.Property(p => p.Town).IsRequired();
        }
    }
}

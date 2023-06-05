using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.DataAccess.Repositories.EntityFramework.Mapping
{
    public class DeveloperMap : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Games)
                .WithOne(p => p.DevelopedBy)
                .HasForeignKey(p => p.DevelopedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

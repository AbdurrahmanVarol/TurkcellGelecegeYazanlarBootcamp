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
    public class GameMap : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(p => p.Id);          

            builder.Property(p => p.Id).HasDefaultValueSql("NEWID()");

            builder.HasMany(p => p.Reviews)
                .WithOne(p => p.Game)
                .HasForeignKey(p => p.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Images)
                .WithOne(p => p.Game)
                .HasForeignKey(p => p.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.DevelopedBy).AutoInclude();
            builder.Navigation(p => p.Genres).AutoInclude();
            builder.Navigation(p => p.PublishedBy).AutoInclude();
            builder.Navigation(p => p.Images).AutoInclude();
            builder.Navigation(p => p.Reviews).AutoInclude();
        }
    }
}

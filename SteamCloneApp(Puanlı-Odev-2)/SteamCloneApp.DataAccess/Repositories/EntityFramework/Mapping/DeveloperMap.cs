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
            builder.HasData(
                new Developer { Id = 1, Name = "Larian Studios", Description = "Larian Studios is an independent RPG developer founded in 1996 in Gent, Belgium." },
                new Developer { Id = 2, Name = "Fromsoftware", Description = "FromSoftware, Inc. is established in Sasazuka, Shibuya-ku, Tokyo, for the development of business application software." },
                new Developer { Id = 3, Name = "Santa Monica Studio", Description = "PlayStation Studios is home to the development of Sony Interactive Entertainment’s own outstanding and immersive games, including some of the most popular and critically acclaimed titles in entertainment history." },
                new Developer { Id = 4, Name = "Guerrilla", Description = "PlayStation Studios is home to the development of Sony Interactive Entertainment’s own outstanding and immersive games, including some of the most popular and critically acclaimed titles in entertainment history." },
                new Developer { Id = 5, Name = "Ubisoft Toronto", Description = "Ubisoft is a creator of worlds, committed to enriching players' lives with original and memorable gaming experiences." },
                new Developer { Id = 6, Name = "Ubisoft Quebec", Description = "Ubisoft is a creator of worlds, committed to enriching players' lives with original and memorable gaming experiences." },
                new Developer { Id = 7, Name = "CD PROJEKT RED", Description = "CD PROJEKT RED is a development studio founded in 2002. Our mission is to tell emotional stories riddled with meaningful choices and consequences, as well as featuring characters gamers can truly connect with." }
                );
        }
    }
}

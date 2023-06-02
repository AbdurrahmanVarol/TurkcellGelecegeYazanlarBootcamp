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
    public class PublisherMap : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Games)
                .WithOne(p => p.PublishedBy)
                .HasForeignKey(p => p.PublishedById)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                    new Publisher { Id = 1, Name = "Larian Studios", Description = "Larian Studios is an independent RPG developer founded in 1996 in Gent, Belgium." },
                    new Publisher { Id = 2, Name = "Bandai Namco Entertainment", Description = "Bandai Namco exists to share dreams, fun and inspiration with people around the world. Do you wish to enjoy every single day to the fullest? What we want is for people like you to always have a reason to smile." },
                    new Publisher { Id = 3, Name = "PlayStation Studios", Description = "PlayStation Studios is home to the development of Sony Interactive Entertainment’s own outstanding and immersive games, including some of the most popular and critically acclaimed titles in entertainment history." },
                    new Publisher { Id = 4, Name = "Ubisoft", Description = "Ubisoft is a creator of worlds, committed to enriching players' lives with original and memorable gaming experiences." },
                    new Publisher { Id = 5, Name = "CD PROJEKT RED", Description = "CD PROJEKT RED is a development studio founded in 2002. Our mission is to tell emotional stories riddled with meaningful choices and consequences, as well as featuring characters gamers can truly connect with." }
                );
        }
    }
}
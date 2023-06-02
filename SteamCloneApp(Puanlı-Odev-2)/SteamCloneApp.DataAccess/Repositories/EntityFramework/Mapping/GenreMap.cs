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
    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Games)
                .WithMany(p => p.Genres);

            builder.HasData(
                    new Genre {Id=1, Name = "Aksiyon" },
                    new Genre {Id=2, Name = "Basit Eğlence" },
                    new Genre {Id=3, Name = "Bağımsız" },
                    new Genre {Id=4, Name = "Devasa Çok Oyunculu" },
                    new Genre {Id=5, Name = "Macera" },
                    new Genre {Id=6, Name = "RYO" },
                    new Genre {Id=7, Name = "Simülasyon" },
                    new Genre {Id=8, Name = "Spor" },
                    new Genre {Id=9, Name = "Strateji" },
                    new Genre {Id=10, Name = "Yarış" }
                    );
        }
    }
}

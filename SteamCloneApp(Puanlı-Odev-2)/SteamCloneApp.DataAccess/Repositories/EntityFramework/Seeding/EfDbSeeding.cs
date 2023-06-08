using SteamCloneApp.DataAccess.Repositories.EntityFramework.Contexts;
using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.DataAccess.Repositories.EntityFramework.Seeding
{
    public static class EfDbSeeding
    {
        public static void SeedDatabase(SteamCloneContext context)
        {
            seedDeveloperIfNoExists(context);
            seedPublisherIfNoExists(context);
            seedGenreIfNoExists(context);
            seedRoleIfNoExists(context);
            seedUserIfNoExists(context);
            seedGameIfNoExists(context);
            seedGameImageIfNoExists(context);
        }

        private static void seedGameIfNoExists(SteamCloneContext context)
        {
            if (!context.Games.Any())
            {
                var genres = context.Genres;

                var games = new List<Game>
                    {
                         new Game
                        {
                            Id = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a"),
                            Title = "Baldur's Gate 3",
                            Description = "Partini topla ve dostluk, ihanet, fedakârlık, hayatta kalma ve mutlak güç arzusuyla dolu bir hikâyede Unutulmuş Diyarlar'a dön.",
                            Price = 799.00M,
                            PublishedById = 1,
                            DevelopedById = 1,
                            ReleaseAt = DateTime.Parse("06.10.2020"),
                            IconUrl = "",
                            CoverUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/header.jpg?t=1681730384",
                            Genres = genres.Where(p=>p.Name.Equals("Aksiyon")|| p.Name.Equals("Strateji")|| p.Name.Equals("RYO")).ToList()
                        },
                        new Game
                        {
                            Id = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9"),
                            Title = "ELDEN RING",
                            Description = "YENİ FANTASTİK AKSİYON ROL YAPMA OYUNU. Tarnished, yüksel ve zarafetin seni yönlendirmesine izin ver. Elden Ring'in gücünü kullan ve Lands Between'de bir Elden Lord ol.",
                            Price = 699.00M,
                            PublishedById = 2,
                            DevelopedById = 2,
                            ReleaseAt = DateTime.Parse("25.02.2022"),
                            IconUrl = "",
                            CoverUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/header.jpg?t=1683618443",
                              Genres = genres.Where(p=>p.Name.Equals("Aksiyon")|| p.Name.Equals("Strateji")|| p.Name.Equals("RYO")).ToList()
                        },
                        new Game
                        {
                            Id = Guid.Parse("beb58c33-0692-40e8-abea-f7921e1af526"),
                            Title = "Horizon Zero Dawn™ Complete Edition",
                            Description = "Makinelerin yönettiği geleceğin Dünyasındaki gizemleri ortaya çıkarmak için Aloy'un efsanevi görevini deneyimleyin. Bu ödüllü aksiyon rol yapma oyununda avınıza karşı yıkıcı etkiye sahip taktiksel saldırılar düzenleyin ve muazzam bir açık dünyayı keşfedin!",
                            Price = 329.00M,
                            PublishedById = 4,
                            DevelopedById = 3,
                            ReleaseAt = DateTime.Parse("07.08.2020"),
                            IconUrl = "",
                            CoverUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1151640/header.jpg?t=1667297464",
                              Genres = genres.Where(p=>p.Name.Equals("Aksiyon")|| p.Name.Equals("Macera")).ToList()
                        },
                        new Game
                        {
                            Id = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151"),
                            Title = "Cyberpunk 2077",
                            Description = "Cyberpunk 2077, karanlık bir gelecekte güç, gösteriş ve vücut modifikasyonu çılgınlığına kapılmış Night City kümekentinde geçen bir açık dünya aksiyon macera hikâyesidir.",
                            Price = 799.00M,
                            PublishedById = 5,
                            DevelopedById = 7,
                            ReleaseAt = DateTime.Parse("10.12.2020"),
                            IconUrl = "",
                            CoverUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/header.jpg?t=1680026109",
                            Genres = genres.Where(p=>p.Name.Equals("Aksiyon")|| p.Name.Equals("Macera")).ToList()
                        },
                        new Game
                        {
                            Id = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514"),
                            Title = "Detroit: Become Human",
                            Description = "Detroit: Become Human sizi makinelerin insanlardan daha akıllı olduğu bir yakın geleceğe taşıyor. Şimdiye kadar oluşturulan hikayeler arasında en fazla dallara ayrılanlardan biri olan bu hikayede, vereceğiniz her karar oyunun sonucunu etkileyecek.",
                            Price = 470.00M,
                            PublishedById = 6,
                            DevelopedById = 8,
                            ReleaseAt = DateTime.Parse("18.06.2020"),
                            IconUrl = "",
                            CoverUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/header.jpg?t=1667468479",
                            Genres = genres.Where(p=>p.Name.Equals("Aksiyon")|| p.Name.Equals("Macera")).ToList()
                        },
                        new Game
                        {
                            Id = Guid.Parse("e07c0e1c-7ea0-4cbf-87c1-6def3629fd04"),
                            Title = "Dying Light 2 Stay Human",
                            Description = "Virüs kazandı ve medeniyet Karanlık Çağ'a geri döndü. İnsanlığın son yerleşkelerinden biri olan Şehir, yıkılmanın eşiğinde. Hayatta kalmak için çevikliğini ve dövüş yeteneklerini kullan ve dünyayı yeniden şekillendir. Seçimlerin herkesin kaderini belirleyecek.",
                            Price = 349.00M,
                            PublishedById = 7,
                            DevelopedById = 9,
                            ReleaseAt = DateTime.Parse("04.02.2022"),
                            IconUrl = "",
                            CoverUrl = "https://cdn.akamai.steamstatic.com/steam/apps/534380/header_alt_assets_18_turkish.jpg?t=1685707337",
                            Genres = genres.Where(p=>p.Name.Equals("Aksiyon")|| p.Name.Equals("Macera")).ToList()
                        },
                        new Game
                        {
                            Id = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49"),
                            Title = "Dying Light",
                            Description = "Et peşindeki zombilerin istila ettiği açık dünyada, kıyamet sonrası dönemde geçen, birinci şahıs aksiyon hayatta kalma oyunu. Gizemli bir virüs salgınıyla perişan olmuş şehri keşfet. Erzak ara, silah üret ve marazlı ordularıyla çarpış.",
                            Price = 59.00M,
                            PublishedById = 7,
                            DevelopedById = 9,
                            ReleaseAt = DateTime.Parse("26.01.2015"),
                            IconUrl = "",
                            CoverUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/header.jpg?t=1674129492",
                            Genres = genres.Where(p=>p.Name.Equals("Aksiyon")|| p.Name.Equals("Macera")).ToList()
                        },
                        new Game
                        {
                            Id = Guid.Parse("c1c4daa3-1cc7-4f1a-8cd8-41de0726c8ad"),
                            Title = "God of War",
                            Description = "Olimpos Tanrılarından aldığı intikamın üzerinden yıllar geçen Kratos, artık İskandinav Tanrılarının ve canavarlarının diyarında sıradan bir insan olarak yaşıyor. Bu sert ve acımasız dünyada hayatta kalabilmek için savaşmak ve oğluna da aynısını öğretmek zorunda.",
                            Price = 329.00M,
                            PublishedById = 3,
                            DevelopedById = 3,
                            ReleaseAt = DateTime.Parse("14.01.2022"),
                            IconUrl = "",
                            CoverUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1593500/header.jpg?t=1650554420",
                            Genres = genres.Where(p=>p.Name.Equals("Aksiyon")|| p.Name.Equals("Macera")).ToList()
                        }
                    };
                context.Games.AddRange(games);
            }
            context.SaveChanges();
        }
        private static void seedGenreIfNoExists(SteamCloneContext context)
        {
            if (!context.Genres.Any())
            {
                var genres = new List<Genre>()
                {
                      new Genre {Name = "Aksiyon" },
                      new Genre {Name = "Basit Eğlence" },
                      new Genre {Name = "Bağımsız" },
                      new Genre {Name = "Devasa Çok Oyunculu" },
                      new Genre {Name = "Macera" },
                      new Genre {Name = "RYO" },
                      new Genre {Name = "Simülasyon" },
                      new Genre {Name = "Spor" },
                      new Genre {Name = "Strateji" },
                      new Genre { Name = "Yarış" }
                };
                context.Genres.AddRange(genres);
                context.SaveChanges();
            }
        }
        private static void seedDeveloperIfNoExists(SteamCloneContext context)
        {
            if (!context.Developers.Any())
            {
                var developers = new List<Developer>()
                {
                      new Developer { Name = "Larian Studios", Description = "Larian Studios is an independent RPG developer founded in 1996 in Gent, Belgium." },
                      new Developer { Name = "Fromsoftware", Description = "FromSoftware, Inc. is established in Sasazuka, Shibuya-ku, Tokyo, for the development of business application software." },
                      new Developer { Name = "Santa Monica Studio", Description = "PlayStation Studios is home to the development of Sony Interactive Entertainment’s own outstanding and immersive games, including some of the most popular and critically acclaimed titles in entertainment history." },
                      new Developer { Name = "Guerrilla", Description = "PlayStation Studios is home to the development of Sony Interactive Entertainment’s own outstanding and immersive games, including some of the most popular and critically acclaimed titles in entertainment history." },
                      new Developer { Name = "Ubisoft Toronto", Description = "Ubisoft is a creator of worlds, committed to enriching players' lives with original and memorable gaming experiences." },
                      new Developer { Name = "Ubisoft Quebec", Description = "Ubisoft is a creator of worlds, committed to enriching players' lives with original and memorable gaming experiences." },
                      new Developer { Name = "CD PROJEKT RED", Description = "CD PROJEKT RED is a development studio founded in 2002. Our mission is to tell emotional stories riddled with meaningful choices and consequences, as well as featuring characters gamers can truly connect with." },
                      new Developer { Name = "Quantic Dream", Description = "Quantic Dream is an award-winning French video game developer and publisher founded to create AAA games with a focus on emotional, interactive storytelling and innovation in narrative." },
                      new Developer { Name = "Techland", Description = "Creator and publisher of Dying Light and Call of Juarez franchises." },
                };
                context.Developers.AddRange(developers);
                context.SaveChanges();
            }
        }
        private static void seedPublisherIfNoExists(SteamCloneContext context)
        {
            if (!context.Publishers.Any())
            {
                var publishers = new List<Publisher>()
                {
                    new Publisher { Name = "Larian Studios", Description = "Larian Studios is an independent RPG developer founded in 1996 in Gent, Belgium." },
                    new Publisher { Name = "Bandai Namco Entertainment", Description = "Bandai Namco exists to share dreams, fun and inspiration with people around the world. Do you wish to enjoy every single day to the fullest? What we want is for people like you to always have a reason to smile." },
                    new Publisher { Name = "PlayStation Studios", Description = "PlayStation Studios is home to the development of Sony Interactive Entertainment’s own outstanding and immersive games, including some of the most popular and critically acclaimed titles in entertainment history." },
                    new Publisher { Name = "Ubisoft", Description = "Ubisoft is a creator of worlds, committed to enriching players' lives with original and memorable gaming experiences." },
                    new Publisher { Name = "CD PROJEKT RED", Description = "CD PROJEKT RED is a development studio founded in 2002. Our mission is to tell emotional stories riddled with meaningful choices and consequences, as well as featuring characters gamers can truly connect with." },
                    new Publisher { Name = "Quantic Dream", Description = "Quantic Dream is an award-winning French video game developer and publisher founded to create AAA games with a focus on emotional, interactive storytelling and innovation in narrative." },
                    new Publisher { Name = "Techland Publishing", Description = "Creator and publisher of Dying Light and Call of Juarez franchises." }
                };
                context.Publishers.AddRange(publishers);
                context.SaveChanges();
            }
        }
        private static void seedRoleIfNoExists(SteamCloneContext context)
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Role>()
                {
                    new Role {Name = "Admin" },
                    new Role {Name = "Customer" }
                };
                context.Roles.AddRange(roles);
                context.SaveChanges();
            }
        }
        private static void seedUserIfNoExists(SteamCloneContext context)
        {
            if (!context.Users.Any())
            {
                //password:12345
                var passwordSalt = "8qjYoxBQ2SgvH7vcbDsPbus2YFpicja5cDbz9IL6hJIgS4gTgr5uq1ADDLy7GHsIEY+0otBju+h74HRuNuFnU25/HWCXOjdKqPlksusj7mNjAR6rk9K9Oy4s1wIySzCoy3xi205Kqhgb4NJ0UcryFCvT6G/9QDQ63A9NyNVQ8s0=";
                var passwordHash = "WMA4dhrMhW2ZW3+8wIlpzcew0pVATmgSq4WZ+tjmiOW1R09J5lKdcxR16RIT1ds44FjeYM0o+ksAeTzSX6aXZQ==";

                var roles = context.Roles;

                var users = new List<User>() {
                        new User 
                        { 
                            FirstName = "Abdurrahman", 
                            LastName = "Varol", 
                            Email = "abdurrahman@gmail.com",
                            NickName = "abdurrahman", 
                            PasswordSalt = passwordSalt,
                            PasswordHash = passwordHash,
                            Roles = roles.Where(p=>p.
                            Name.Equals("Admin")|| p.
                            Name.Equals("Customer")).ToList() 
                        },
                        new User 
                        { 
                            FirstName = "Customer", 
                            LastName = "Customer", 
                            Email = "Customer@gmail.com",
                            NickName = "Customer", 
                            PasswordSalt = passwordSalt,
                            PasswordHash = passwordHash,
                            Roles = roles.Where(p=>p.Name.Equals("Customer")).ToList() 
                        }
                        };
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
        private static void seedGameImageIfNoExists(SteamCloneContext context)
        {
            if (!context.Images.Any())
            {
                var images = new List<Image>()
            {
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_387896248b42a15239a9256844b3e4bff72fbc2a.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_541756ab775d679957dca1e7d249c91a8f5d1ddd.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_85016b8787e589e9f01046d9f01b7de265c90212.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_82ef22724be56337ec220fcc287b93fa9bbb01fb.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_c81bd3bb9b2a3dd26b2dfd4ae3b8cd19331f4263.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_c3ff3176af9e155e1a240b0ff47d34d4d3a86644.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_fbc86702c8ea7ba4ac8bcf05756e7225f976daf2.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_49168eeefdfb6e6030a5aed3fd7c1a83da870a9f.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_ae44286e6679da863ac27a4b6f46e46a5f7718a4.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_d0b50351676da10c5403ec904cf7582636e65346.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_74d11c230ebb44ff9a69b4533a7333551d5bfc6c.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_731cf9144980dac28c6e0224d1533550a7f86681.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_1c3ff278ac430948dc31efeb1f7d2bb0466a1493.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_0b812f33e2fd27eb30d7090122f9b990a7e12e1f.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_eeb53df5fdf81ed0e807cc4efe1cecadf4658bed.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_2ed75eb900bb01434e1697e6630a632bf29ed3de.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_f1e2f32f271422d0443a4f3f03925b8d223ee5b4.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1086940/ss_4e3ff6c1c366db9aabecc356996b9706b402b055.1920x1080.jpg?t=1681730384", GameId = Guid.Parse("5bfbf07a-6e1b-42d7-aef0-07bf212fac0a") },

                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_ae44317e3bd07b7690b4d62cc5d0d1df30367a91.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_e80a907c2c43337e53316c71555c3c3035a1343e.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_b70e156adf9e40aed24c10fb352b7813586e7290.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_3aec1455923ef49f4e777c2a94dbcd0256f77eb0.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_b6c4cdb36cebdbd52b97ab6e0851b7d3e41f03b3.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_e87a3e84890ab19f8995566e62762d5f8ed39315.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_1e3dfe515c04f4071207f01d62b85a1d6b560ced.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_3e556415d1bda00d749b2166ced264bec76f06ee.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_c372274833ae6e5437b952fa1979430546a43ad9.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_b87601dee58f4dbc36e40a8d803dc6a53ceefe07.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_8b58d96262fb0d62a482621b86c6ff85f4f57997.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_1011610a0e330c41a75ffd0b3a9a1bac3205c46a.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_41e2e8f3b0ad631e929e0c2ec3d1f21de883e98c.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_abd681cde3402155a35edb82919b7602cc7ec338.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_0b6e59057b02392b21dde62b4dde65d447e1fa3c.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_7523a8fc7775ae65cabd94d092ebecbd963258b6.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_ebb332e63dfab864c3bf3c3b1001b69f4da25f9f.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1245620/ss_75f25974c20b8704fe5ee246f74896b550088d3e.1920x1080.jpg?t=1683618443", GameId = Guid.Parse("28549390-12d7-474d-bece-3348d1e14af9") },

                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1151640/ss_d09106060fb7de8bf342c23df18b14debc8a15a3.1920x1080.jpg?t=1667297464", GameId = Guid.Parse("beb58c33-0692-40e8-abea-f7921e1af526") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1151640/ss_271f850eec3f96b22aa17be35b948268e0771c7f.1920x1080.jpg?t=1667297464", GameId = Guid.Parse("beb58c33-0692-40e8-abea-f7921e1af526") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1151640/ss_15f5759c441e4e5f51e1a8ee333e4ab9df9aa783.1920x1080.jpg?t=1667297464", GameId = Guid.Parse("beb58c33-0692-40e8-abea-f7921e1af526") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1151640/ss_f7cf51f1ccd909264f2c5814f328e3f72e7b62bd.1920x1080.jpg?t=1667297464", GameId = Guid.Parse("beb58c33-0692-40e8-abea-f7921e1af526") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1151640/ss_9db45aa04e8c8b5043b479f42ed36296bfc3a918.1920x1080.jpg?t=1667297464", GameId = Guid.Parse("beb58c33-0692-40e8-abea-f7921e1af526") },

                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_b529b0abc43f55fc23fe8058eddb6e37c9629a6a.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_8640d9db74f7cad714f6ecfb0e1aceaa3f887e58.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_9284d1c5b248726760233a933dbb83757d7d5d95.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_4bda6f67580d94832ed2d5814e41ebe018ba1d9e.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_e5a94665dbfa5a30931cff2f45cdc0ebea9fcebb.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_429db1d013a0366417d650d84f1eff02d1a18c2d.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_872822c5e50dc71f345416098d29fc3ae5cd26c1.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_ae4465fa8a44dd330dbeb7992ba196c2f32cabb1.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_f79fda81e6f3a37e0978054102102d71840f8b57.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_bb1a60b8e5061caef7208369f42c5c9d574c9ac4.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_a0c4e4015b5cf766d19bf97eee8b086183510e04.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_b20689e73e3ac19bcc5fad2c18d0353c769de144.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_ff3d920e254d18aa2a25d3765ac2ebe845efd208.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_0002f18563d313bdd1d82c725d411408ebf762b0.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_526123764d1c628caa1eb62c596f1b732f416c8c.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_284ba40590de8f604ae693631c751a0aefdc452e.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },
                        new Image { ImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/ss_9beef14102f164fa1163536d0fb3a51d0a2e4a3f.1920x1080.jpg?t=1680026109", GameId = Guid.Parse("91634d8b-dbce-4c88-8042-94258321c151") },

                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/ss_9c900def2b1d9a003b7d3e202ea2a7556a36e081.1920x1080.jpg?t=1667468479", GameId = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/ss_3011c05e404043e3bfed1f6de7fe12ffd58ddc9b.1920x1080.jpg?t=1667468479", GameId = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/ss_9e6c271b6d11b1d0f35da336fb57b35fed0079d1.1920x1080.jpg?t=1667468479", GameId = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/ss_b1e2a185bea13cccfc662e1286912bcd6f4ee798.1920x1080.jpg?t=1667468479", GameId = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/ss_fbc13a0d5b5b784c053042eb4ea09a30de069b3a.1920x1080.jpg?t=1667468479", GameId = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/ss_b6dc18d77c4be0d851d1c26f1c352988ef5b07a2.1920x1080.jpg?t=1667468479", GameId = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/ss_71d12349ce93190af99dbf48faeae50416d9cbc7.1920x1080.jpg?t=1667468479", GameId = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/ss_4ba58d269bce7db923575cc033c888cb83cc1cba.1920x1080.jpg?t=1667468479", GameId = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/ss_d843de340cec5939af9cff19c467371f26a9b4b1.1920x1080.jpg?t=1667468479", GameId = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/ss_f5625ad291da001ad04f19b6ef0d6c0a404d0c91.1920x1080.jpg?t=1667468479", GameId = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/ss_cca3d17b5479784379aaec006dcb36a5406aed34.1920x1080.jpg?t=1667468479", GameId = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1222140/ss_7b1c36dbc3deb1515a65aaaca42795813de08a83.1920x1080.jpg?t=1667468479", GameId = Guid.Parse("d33df182-d821-473f-b20b-7f6b3cace514") },

                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/534380/ss_d7906b3946d4857d28c159e7a1555a003a4426f8.1920x1080.jpg?t=1685707337", GameId = Guid.Parse("e07c0e1c-7ea0-4cbf-87c1-6def3629fd04") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/534380/ss_6b8d4cc1f7d657745cfd7aab941d3be0067dec00.1920x1080.jpg?t=1685707337", GameId = Guid.Parse("e07c0e1c-7ea0-4cbf-87c1-6def3629fd04") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/534380/ss_fe9a52a60f4739a44cbd8b0c0856033ea6996624.1920x1080.jpg?t=1685707337", GameId = Guid.Parse("e07c0e1c-7ea0-4cbf-87c1-6def3629fd04") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/534380/ss_84ca00f3d3b48e0a1fa6b96b17f02a65f1447950.1920x1080.jpg?t=1685707337", GameId = Guid.Parse("e07c0e1c-7ea0-4cbf-87c1-6def3629fd04") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/534380/ss_28860dda506d28aea744a08744bad8afb1b506c5.1920x1080.jpg?t=1685707337", GameId = Guid.Parse("e07c0e1c-7ea0-4cbf-87c1-6def3629fd04") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/534380/ss_64ba1a8bd42d3d0a34bc894d6faa0e57a1328aef.1920x1080.jpg?t=1685707337", GameId = Guid.Parse("e07c0e1c-7ea0-4cbf-87c1-6def3629fd04") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/534380/ss_38ca559ee79b64ef65f6d5c5c722778f6447425e.1920x1080.jpg?t=1685707337", GameId = Guid.Parse("e07c0e1c-7ea0-4cbf-87c1-6def3629fd04") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/534380/ss_1c3c5764cc6d6a9a86122a0de643973c0c8dca1b.1920x1080.jpg?t=1685707337", GameId = Guid.Parse("e07c0e1c-7ea0-4cbf-87c1-6def3629fd04") },

                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_a3771358b8eb4ea4c8f99c5850711f55b87804de.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_1f0dc94f46fa1a953827188188887f6a12911ec2.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_488226f013287012e0feaed2fb7799dbe038fd00.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_37f8192f3bf85359ddee0b5c2e9a58eaaf6c4026.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_ac414827362042b5f4a95ab90df508adc822ddc1.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_3b41c96ae1a6f31c597187672221b8db9b78419b.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_8bf1e0e5333f5899b413f90d67a3cfe8b8b8f8e1.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_e31d8536ca5c947c8cbf6486473f50c3c27ee255.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_d7e781ddd8ea78d5c8fedd27e0c1d02425cd91eb.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_2c18c2b5a03a736453d1222e05019e89f80ed8dc.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_e3d9596c0ee06b6e4f9b09e5320d70fbf59cc78e.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_fd1b12177c50cb45ab5fd6105ba2c68d39f8c012.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_7ed04fc8acf05d721f5d17ee71b2f51080dd8463.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/239140/ss_0f20a60df3fec00deb16c12428cdb35fcce5bf0d.1920x1080.jpg?t=1674129492", GameId = Guid.Parse("908df1f1-b615-4e5e-8beb-6264b7fd6e49") },

                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1593500/ss_6eccc970b5de2943546d93d319be1b5c0618f21b.1920x1080.jpg?t=1650554420", GameId = Guid.Parse("c1c4daa3-1cc7-4f1a-8cd8-41de0726c8ad") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1593500/ss_f1bff24d3967a21d303d95e11ed892e3d9113057.1920x1080.jpg?t=1650554420", GameId = Guid.Parse("c1c4daa3-1cc7-4f1a-8cd8-41de0726c8ad") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1593500/ss_3670ba72c7e3e9c3c3225547ef2c1053504e62b8.1920x1080.jpg?t=1650554420", GameId = Guid.Parse("c1c4daa3-1cc7-4f1a-8cd8-41de0726c8ad") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1593500/ss_93a3ca63aa2cd8c675bbb6430324ee3f2d44b845.1920x1080.jpg?t=1650554420", GameId = Guid.Parse("c1c4daa3-1cc7-4f1a-8cd8-41de0726c8ad") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1593500/ss_1bd99270dcbd4ff9fe9c94b0d9c8ffc50ebb42c7.1920x1080.jpg?t=1650554420", GameId = Guid.Parse("c1c4daa3-1cc7-4f1a-8cd8-41de0726c8ad") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1593500/ss_0858b868ea51d53f73bd805ba7382f027dd33dca.1920x1080.jpg?t=1650554420", GameId = Guid.Parse("c1c4daa3-1cc7-4f1a-8cd8-41de0726c8ad") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1593500/ss_1351cb512d008f7e47fc50b74197f4f8eb6f3419.1920x1080.jpg?t=1650554420", GameId = Guid.Parse("c1c4daa3-1cc7-4f1a-8cd8-41de0726c8ad") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1593500/ss_8db3de5b5d611e50945268848de2889e1ed4ba84.1920x1080.jpg?t=1650554420", GameId = Guid.Parse("c1c4daa3-1cc7-4f1a-8cd8-41de0726c8ad") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1593500/ss_190a972a5bd3144d8944dcdfd7759bb1149017c0.1920x1080.jpg?t=1650554420", GameId = Guid.Parse("c1c4daa3-1cc7-4f1a-8cd8-41de0726c8ad") },
                        new Image {ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1593500/ss_e0edce62c590bc063a90a1296184392d0a9521da.1920x1080.jpg?t=1650554420", GameId = Guid.Parse("c1c4daa3-1cc7-4f1a-8cd8-41de0726c8ad") },                
            };
                context.Images.AddRange(images);
                context.SaveChanges();
            }
        }
    }
}

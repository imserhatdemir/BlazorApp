namespace BlazorApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>().HasKey(ci => new { ci.UserId,ci.ProductId, ci.ProductTypeId });

            modelBuilder.Entity<ProductVariant>().HasKey(p => new { p.ProductId, p.ProductTypeId });

            modelBuilder.Entity<OrderItem>().HasKey(oi => new {oi.OrderId, oi.ProductId, oi.ProductTypeId });

            modelBuilder.Entity<ProductType>().HasData(
                    new ProductType { Id = 1, Name = "Default" },
                    new ProductType { Id = 2, Name = "Paperback" },
                    new ProductType { Id = 3, Name = "E-Book" },
                    new ProductType { Id = 4, Name = "Audiobook" },
                    new ProductType { Id = 5, Name = "Stream" },
                    new ProductType { Id = 6, Name = "Blu-ray" },
                    new ProductType { Id = 7, Name = "VHS" },
                    new ProductType { Id = 8, Name = "PC" },
                    new ProductType { Id = 9, Name = "PlayStation" },
                    new ProductType { Id = 10, Name = "Xbox" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Books",
                    Url = "Books"
                },
                new Category
                {
                    Id = 2,
                    Name = "Team",
                    Url = "Teams"
                },
                new Category
                {
                    Id = 3,
                    Name = "Movie",
                    Url = "Movies"
                }
                );
            modelBuilder.Entity<Product>().HasData(
                        new Product
                        {
                            ID = 1,
                            Title = "The Hitchhiker's Guide to the Galaxy",
                            Description = "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",

                            CategoryId = 1,
                            Featured = false
                        },
                         new Product
                         {
                             ID = 2,
                             Title = "PIC18F26K22-I/SO SMD",
                             Description = "PIC18F26K22-I/SO SMD ürünü ve diğer tüm Microchip marka, 8 Bit, 16 Bit, 32 Bit Mikroişlemci çeşitleri ve Eeprom’ların Dip ve SMD modellerini uygun fiyatlarla üye girişi yaparak veya üye olmadan alabilirsiniz.",
                             ImageURL = "https://st3.myideasoft.com/idea/aq/83/myassets/products/292/2622_min.JPG?revision=1649657943",

                             CategoryId = 2,
                             Featured = true
                         },
                         new Product
                         {
                             ID = 3,
                             Title = "Ready Player One",
                             Description = "Başlat: Ready Player One (Özgün adı:Ready Player One), yönetmenliği Steven Spielberg tarafından gerçekleştirilen ve Ernest Cline'nin aynı isimli romanından uyarlanan 2018 çıkışlı Amerikan yapımı bilimkurgu macera filmidir. Filmin başrollerinde Tye Sheridan, Olivia Cooke, Ben Mendelsohn, Lena Waithe, Simon Pegg, Hannah John-Kamen ve Mark Rylance yer almaktadır.",
                             ImageURL = "https://upload.wikimedia.org/wikipedia/tr/thumb/d/da/Ready_Player_One.jpg/220px-Ready_Player_One.jpg",

                             CategoryId = 3,
                             Featured = false
                         },
                         new Product
                         {
                             ID = 4,
                             CategoryId = 2,
                             Title = "VIPER22A DIP8",
                             Description = "VIPER22A DIP8, entegre ürünü ve diğer tüm ADC(Analog-Dijital Dönüştürücü), DAC(Dijital-Analog Dönüştürücü), OpAmp(Operasyonel Amplifikatörler), Analog Anahtarlama, RTC(Gerçek Zamanlı Saat), Ağ Denetleyici (Ethernet Kontrol vb.), USB Kontrol(USB-Uart Arayüz), Sürücüler, Voltaj Regülatörleri(1.8V, 3.3V, 5V, 12V ve Ayarlanabilir), Step-Servo Motor Sürücüler, Ses Amplifikatörü, PWM Denetleyici vb. Entegre çeşitlerinin Dip ve SMD modellerini uygun fiyat avantajı ile üye girişi yaparak satın alabilirsiniz.",

                             ImageURL = "https://st2.myideasoft.com/idea/aq/83/myassets/products/297/22_min.JPG?revision=1649656295",
                             Featured = true
                         },
                    new Product
                    {
                        ID = 5,
                        CategoryId = 2,
                        Title = "10-32V GİRİŞ / 12-35V ÇIKIŞ 6A Konvertör",
                        Description = "Bir elektrik akımının şiddettini, gerilimini veya şeklini değiştirmeye yarayan cihazdır. Transformatör, iki veya daha fazla elektrik devresini elektromanyetik indüksiyonla birbirine bağlayan bir elektrik aletidir. Bir elektrik devresinden diğer elektrik devresine, enerjiyi elektromanyetik alan yardımı ile iletir.",

                        ImageURL = "https://st1.myideasoft.com/idea/aq/83/myassets/products/281/10-32-1.jpg?revision=1478523901",
                        Featured = true
                    },
                    new Product
                    {
                        ID = 6,
                        CategoryId = 2,
                        Title = "Toy Story",
                        Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",

                        ImageURL = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",
                        Featured = false

                    },
                    new Product
                    {
                        ID = 7,
                        CategoryId = 3,
                        Title = "Half-Life 2",
                        Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",

                        ImageURL = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",
                        Featured = false

                    },
                    new Product
                    {
                        ID = 8,
                        CategoryId = 3,
                        Title = "Diablo II",
                        Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",

                        ImageURL = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
                        Featured = false
                    },
                    new Product
                    {
                        ID = 9,
                        CategoryId = 3,
                        Title = "Day of the Tentacle",
                        Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                        ImageURL = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
                        Featured = true
                    },
                    new Product
                    {
                        ID = 10,
                        CategoryId = 3,
                        Title = "Xbox",
                        Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                        ImageURL = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                        Featured = false
                    },
                    new Product
                    {
                        ID = 11,
                        CategoryId = 3,
                        Title = "Super Nintendo Entertainment System",
                        Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                        ImageURL = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                        Featured = false
                    }


                 );


            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 2,
                    Price = 9.99m,
                    OriginalPrice = 19.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 3,
                    Price = 7.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 4,
                    Price = 19.99m,
                    OriginalPrice = 29.99m
                },
                new ProductVariant
                {
                    ProductId = 2,
                    ProductTypeId = 2,
                    Price = 7.99m,
                    OriginalPrice = 14.99m
                },
                new ProductVariant
                {
                    ProductId = 3,
                    ProductTypeId = 2,
                    Price = 6.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 5,
                    Price = 3.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 6,
                    Price = 9.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 7,
                    Price = 19.99m
                },
                new ProductVariant
                {
                    ProductId = 5,
                    ProductTypeId = 5,
                    Price = 3.99m,
                },
                new ProductVariant
                {
                    ProductId = 6,
                    ProductTypeId = 5,
                    Price = 2.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 8,
                    Price = 19.99m,
                    OriginalPrice = 29.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 9,
                    Price = 69.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 10,
                    Price = 49.99m,
                    OriginalPrice = 59.99m
                },
                new ProductVariant
                {
                    ProductId = 8,
                    ProductTypeId = 8,
                    Price = 9.99m,
                    OriginalPrice = 24.99m,
                },
                new ProductVariant
                {
                    ProductId = 9,
                    ProductTypeId = 8,
                    Price = 14.99m
                },
                new ProductVariant
                {
                    ProductId = 10,
                    ProductTypeId = 1,
                    Price = 159.99m,
                    OriginalPrice = 299m
                },
                new ProductVariant
                {
                    ProductId = 11,
                    ProductTypeId = 1,
                    Price = 79.99m,
                    OriginalPrice = 399m
                }
            );
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CustomerNum> CustomerNums { get; set; }
        public DbSet<CentreNumber> CentreNumbers { get; set; }
        public DbSet<ContactAbout> ContactAbouts { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<MissionVision> MissionVisions { get; set; }
        public DbSet<Responsibility> Responsibilities { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

    }
}

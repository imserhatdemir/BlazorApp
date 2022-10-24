﻿namespace BlazorApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                            Price = 9.99m,
                            CategoryId = 1
                        },
                         new Product
                         {
                             ID = 2,
                             Title = "Fenerbahçe",
                             Description = "Fenerbahçe erkek futbol takımı, Fenerbahçe Spor Kulübü'nün Süper Lig'de mücadele eden profesyonel futbol takımıdır.[2] Kulübün futbol dışında faaliyet gösterdiği diğer spor dalları basketbol, voleybol, atletizm, boks, kürek, yelken, yüzme ve masa tenisi'dir. Takım, iç saha maçlarını İstanbul Kadıköy'de bulunan 50.530 kişilik Fenerbahçe Şükrü Saracoğlu Stadyumu'nda yapmaktadır.[2] 1907 yılında bir spor kulübü olarak kurulan Fenerbahçe, Türkiye futbol tarihinin en başarılı ve en çok taraftarı olan spor kulüplerinden birisidir.",
                             ImageURL = "https://upload.wikimedia.org/wikipedia/tr/thumb/8/86/Fenerbahçe_SK.png/150px-Fenerbahçe_SK.png",
                             Price = 7.99m,
                             CategoryId = 2
                         },
                         new Product
                         {
                             ID = 3,
                             Title = "Ready Player One",
                             Description = "Başlat: Ready Player One (Özgün adı:Ready Player One), yönetmenliği Steven Spielberg tarafından gerçekleştirilen ve Ernest Cline'nin aynı isimli romanından uyarlanan 2018 çıkışlı Amerikan yapımı bilimkurgu macera filmidir. Filmin başrollerinde Tye Sheridan, Olivia Cooke, Ben Mendelsohn, Lena Waithe, Simon Pegg, Hannah John-Kamen ve Mark Rylance yer almaktadır.",
                             ImageURL = "https://upload.wikimedia.org/wikipedia/tr/thumb/d/da/Ready_Player_One.jpg/220px-Ready_Player_One.jpg",
                             Price = 6.99m,
                             CategoryId = 3
                         },
                         new Product
                         {
                             ID = 4,
                             CategoryId = 2,
                             Title = "The Matrix",
                             Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
                             Price = 6.99m,
                             ImageURL = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg"
                         },
                    new Product
                    {
                        ID = 5,
                        CategoryId = 2,
                        Title = "Back to the Future",
                        Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
                        Price = 6.99m,
                        ImageURL = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg"
                    },
                    new Product
                    {
                        ID = 6,
                        CategoryId = 2,
                        Title = "Toy Story",
                        Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
                        Price = 6.99m,
                        ImageURL = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg"

                    },
                    new Product
                    {
                        ID = 7,
                        CategoryId = 3,
                        Title = "Half-Life 2",
                        Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
                        Price = 6.99m,
                        ImageURL = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg"

                    },
                    new Product
                    {
                        ID = 8,
                        CategoryId = 3,
                        Title = "Diablo II",
                        Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
                        Price = 6.99m,
                        ImageURL = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png"
                    },
                    new Product
                    {
                        ID = 9,
                        CategoryId = 3,
                        Title = "Day of the Tentacle",
                        Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                        Price = 6.99m,
                        ImageURL = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg"
                    },
                    new Product
                    {
                        ID = 10,
                        CategoryId = 3,
                        Title = "Xbox",
                        Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                        Price = 6.99m,
                        ImageURL = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg"
                    },
                    new Product
                    {
                        ID = 11,
                        CategoryId = 3,
                        Title = "Super Nintendo Entertainment System",
                        Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                        Price = 6.99m,
                        ImageURL = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg"
                    }


                 );
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
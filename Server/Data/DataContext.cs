namespace BlazorApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                        new Product
                        {
                            ID = 1,
                            Title = "The Hitchhiker's Guide to the Galaxy",
                            Description = "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                            Price = 9.99m
                        },
                         new Product
                         {
                             ID = 2,
                             Title = "Fenerbahçe",
                             Description = "Fenerbahçe erkek futbol takımı, Fenerbahçe Spor Kulübü'nün Süper Lig'de mücadele eden profesyonel futbol takımıdır.[2] Kulübün futbol dışında faaliyet gösterdiği diğer spor dalları basketbol, voleybol, atletizm, boks, kürek, yelken, yüzme ve masa tenisi'dir. Takım, iç saha maçlarını İstanbul Kadıköy'de bulunan 50.530 kişilik Fenerbahçe Şükrü Saracoğlu Stadyumu'nda yapmaktadır.[2] 1907 yılında bir spor kulübü olarak kurulan Fenerbahçe, Türkiye futbol tarihinin en başarılı ve en çok taraftarı olan spor kulüplerinden birisidir.",
                             ImageURL = "https://upload.wikimedia.org/wikipedia/tr/thumb/8/86/Fenerbahçe_SK.png/150px-Fenerbahçe_SK.png",
                             Price = 7.99m
                         },
                         new Product
                         {
                             ID = 3,
                             Title = "Ready Player One",
                             Description = "Başlat: Ready Player One (Özgün adı:Ready Player One), yönetmenliği Steven Spielberg tarafından gerçekleştirilen ve Ernest Cline'nin aynı isimli romanından uyarlanan 2018 çıkışlı Amerikan yapımı bilimkurgu macera filmidir. Filmin başrollerinde Tye Sheridan, Olivia Cooke, Ben Mendelsohn, Lena Waithe, Simon Pegg, Hannah John-Kamen ve Mark Rylance yer almaktadır.",
                             ImageURL = "https://upload.wikimedia.org/wikipedia/tr/thumb/d/da/Ready_Player_One.jpg/220px-Ready_Player_One.jpg",
                             Price = 6.99m
                         }
                 );
        }
        public DbSet<Product> Products { get; set; }

    }
}

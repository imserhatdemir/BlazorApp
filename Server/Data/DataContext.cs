namespace BlazorApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>().HasKey(ci => new { ci.UserId, ci.ProductId, ci.ProductTypeId });

            modelBuilder.Entity<FavItem>().HasKey(ci => new { ci.UserId, ci.ProductId });

            modelBuilder.Entity<ProductVariant>().HasKey(p => new { p.ProductId, p.ProductTypeId });

            modelBuilder.Entity<OrderItem>().HasKey(oi => new { oi.OrderId, oi.ProductId, oi.ProductTypeId });


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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<HumanResources> Humans { get; set; }
        public DbSet<SendMail> Sends { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<FavItem> FavItems { get; set; }
        public DbSet<SliderImages> SliderImages { get; set; }
        public DbSet<CategoryImages> CategoryImages { get; set; }
        public DbSet<BrandImage> BrandImages { get; set; }
        public DbSet<Kvkk> Kvkks { get; set; }
        public DbSet<Pdf> Pdfs { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
    }
}

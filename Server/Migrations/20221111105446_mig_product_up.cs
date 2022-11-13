using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class mig_product_up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "VIPER22A DIP8, entegre ürünü ve diğer tüm ADC(Analog-Dijital Dönüştürücü), DAC(Dijital-Analog Dönüştürücü), OpAmp(Operasyonel Amplifikatörler), Analog Anahtarlama, RTC(Gerçek Zamanlı Saat), Ağ Denetleyici (Ethernet Kontrol vb.), USB Kontrol(USB-Uart Arayüz), Sürücüler, Voltaj Regülatörleri(1.8V, 3.3V, 5V, 12V ve Ayarlanabilir), Step-Servo Motor Sürücüler, Ses Amplifikatörü, PWM Denetleyici vb. Entegre çeşitlerinin Dip ve SMD modellerini uygun fiyat avantajı ile üye girişi yaparak satın alabilirsiniz.", "https://st2.myideasoft.com/idea/aq/83/myassets/products/297/22_min.JPG?revision=1649656295", "VIPER22A DIP8" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "Bir elektrik akımının şiddettini, gerilimini veya şeklini değiştirmeye yarayan cihazdır. Transformatör, iki veya daha fazla elektrik devresini elektromanyetik indüksiyonla birbirine bağlayan bir elektrik aletidir. Bir elektrik devresinden diğer elektrik devresine, enerjiyi elektromanyetik alan yardımı ile iletir.", "https://st1.myideasoft.com/idea/aq/83/myassets/products/281/10-32-1.jpg?revision=1478523901", "10-32V GİRİŞ / 12-35V ÇIKIŞ 6A Konvertör" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", "The Matrix" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", "Back to the Future" });
        }
    }
}

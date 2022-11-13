using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class update_product_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "PIC18F26K22-I/SO SMD ürünü ve diğer tüm Microchip marka, 8 Bit, 16 Bit, 32 Bit Mikroişlemci çeşitleri ve Eeprom’ların Dip ve SMD modellerini uygun fiyatlarla üye girişi yaparak veya üye olmadan alabilirsiniz.", "https://st3.myideasoft.com/idea/aq/83/myassets/products/292/2622_min.JPG?revision=1649657943", "PIC18F26K22-I/SO SMD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "Fenerbahçe erkek futbol takımı, Fenerbahçe Spor Kulübü'nün Süper Lig'de mücadele eden profesyonel futbol takımıdır.[2] Kulübün futbol dışında faaliyet gösterdiği diğer spor dalları basketbol, voleybol, atletizm, boks, kürek, yelken, yüzme ve masa tenisi'dir. Takım, iç saha maçlarını İstanbul Kadıköy'de bulunan 50.530 kişilik Fenerbahçe Şükrü Saracoğlu Stadyumu'nda yapmaktadır.[2] 1907 yılında bir spor kulübü olarak kurulan Fenerbahçe, Türkiye futbol tarihinin en başarılı ve en çok taraftarı olan spor kulüplerinden birisidir.", "https://upload.wikimedia.org/wikipedia/tr/thumb/8/86/Fenerbahçe_SK.png/150px-Fenerbahçe_SK.png", "Fenerbahçe" });
        }
    }
}

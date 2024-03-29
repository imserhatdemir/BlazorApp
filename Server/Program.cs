global using BlazorApp.Server.Data;
global using BlazorApp.Server.Services.CartService;
global using BlazorApp.Server.Services.CategoryService;
global using BlazorApp.Server.Services.ProductService;
global using BlazorApp.Server.Services.OrderService;
global using BlazorApp.Server.Services.AuthService;
global using BlazorApp.Server.Services.PaymentService;
global using BlazorApp.Server.Services.AddressService;
global using BlazorApp.Server.Services.ProductTypeService;
global using BlazorApp.Server.Services.AboutService;
global using BlazorApp.Server.Services.BankAccountService;
global using BlazorApp.Server.Services.CentreNumberService;
global using BlazorApp.Server.Services.ContactAboutService;
global using BlazorApp.Server.Services.ContactAddressService;
global using BlazorApp.Server.Services.ContactFormService;
global using BlazorApp.Server.Services.CustomerNumService;
global using BlazorApp.Server.Services.FaqService;
global using BlazorApp.Server.Services.MissionVisionService;
global using BlazorApp.Server.Services.ResponsibilityService;
global using BlazorApp.Server.Services.BrandService;
global using BlazorApp.Server.Services.ShipmentService;
global using BlazorApp.Server.Services.CommentService;
global using BlazorApp.Server.Services.HumanService;
global using BlazorApp.Server.Services.SendMailService;
global using BlazorApp.Server.Services.SliderService;
global using BlazorApp.Server.Services.FavService;
global using BlazorApp.Server.Services.KvkkService;
global using BlazorApp.Server.Services.MainCategoryService;
global using BlazorApp.Shared;
global using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllersWithViews(); 
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IBankAccountService, BankAccountService>();
builder.Services.AddScoped<ICentreNumberService, CentreNumberService>();
builder.Services.AddScoped<IContactAboutService, ContactAboutService>();
builder.Services.AddScoped<IContactAddressService, ContactAddressService>();
builder.Services.AddScoped<IContactFormService, ContactFormService>();
builder.Services.AddScoped<ICustomerNumService, CustomerNumService>();
builder.Services.AddScoped<IFaqService, FaqService>();
builder.Services.AddScoped<IMissionVisionService, MissionVisionService>();
builder.Services.AddScoped<IResponsibilityService, ResponsibilityService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IHumanService, HumanService>();
builder.Services.AddScoped<ISendMailService, SendMailService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IFavService, FavService>();
builder.Services.AddScoped<IKvkkService, KvkkService>();
builder.Services.AddScoped<IMainCategoryService, MainCategoryService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
        new SymmetricSecurityKey(System.Text.Encoding.UTF8
        .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



builder.Services.AddHttpContextAccessor();


builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", builder =>
      builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
});


var app = builder.Build();

app.UseSwaggerUI();


app.UseCors("NewPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

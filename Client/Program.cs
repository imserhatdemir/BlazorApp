global using BlazorApp.Shared;
global using System.Net.Http.Json;
global using BlazorApp.Client.Services.ProductService;
global using BlazorApp.Client.Services.CategoryService;
global using Microsoft.AspNetCore.Components.Web;
global using BlazorApp.Client.Services.CartService;
global using BlazorApp.Client.Services.AuthService;
global using Microsoft.AspNetCore.Components.Authorization;
global using BlazorApp.Client.Services.OrderService;
global using BlazorApp.Client.Services.AddressService;
global using BlazorApp.Client.Services.ProductTypeService;
global using BlazorApp.Client.Services.AboutService;
global using BlazorApp.Client.Services.MissionVisionService;
global using BlazorApp.Client.Services.ResponsibilityService;
global using BlazorApp.Client.Services.CustomerNumService;
global using BlazorApp.Client.Services.CentreNumberService;
global using BlazorApp.Client.Services.ContactAboutService;
global using BlazorApp.Client.Services.ContactAddressService;
global using BlazorApp.Client.Services.BankAccountService;
global using BlazorApp.Client.Services.FaqService;
global using BlazorApp.Client.Services.BrandService;
global using BlazorApp.Client.Services.CommentService;
global using BlazorApp.Client.Services.ContactFormService;
global using BlazorApp.Client.Services.HumanService;
global using BlazorApp.Client.Services.SendMailService;
global using BlazorApp.Client.Services.ShipmentService;
global using BlazorApp.Client.Services.SliderService;
global using BlazorApp.Client.Services.FavService;
global using BlazorApp.Client.Services.KvkkService;
global using BlazorApp.Client.Services.MainCategoryService;
global using CurrieTechnologies.Razor.SweetAlert2;
using BlazorApp.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using MudBlazor.Services;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IMissionVisionService, MissionVisionService>();
builder.Services.AddScoped<IResponsibilityService, ResponsibilityService>();
builder.Services.AddScoped<ICustomerNumService, CustomerNumService>();
builder.Services.AddScoped<ICentreNumberService, CentreNumberService>();
builder.Services.AddScoped<IContactAboutService, ContactAboutService>();
builder.Services.AddScoped<IContactAddressService, ContactAddressService>();
builder.Services.AddScoped<IBankAccountService, BankAccountService>();
builder.Services.AddScoped<IFaqService, FaqService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IContactFormService, ContactFormService>();
builder.Services.AddScoped<IHumanService, HumanService>();
builder.Services.AddScoped<ISendMailService, SendMailService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IFavService, FavService>();
builder.Services.AddScoped<IKvkkService, KvkkService>();
builder.Services.AddScoped<IMainCategoryService, MainCategoryService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddSweetAlert2();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

await builder.Build().RunAsync();

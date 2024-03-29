﻿using BlazorApp.Shared;
using System.Net.Http.Json;

namespace BlazorApp.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Product> AdminProducts { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading Products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public event Action ProductsChanged;

        public async Task<Product> CreateProduct(Product product)
        {
            var result = await _http.PostAsJsonAsync("api/product",  product);
            return (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Product>>()).Data; 
        }

        public async Task DeleteProduct(Product productId)
        {
            var result = await _http.DeleteAsync($"api/product/{productId.ID}");
        }

        public async Task GetAdminProducts()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/admin/");
            AdminProducts = result.Data;
            CurrentPage = 1;
            PageCount = 0;
            if (AdminProducts.Count == 0)
                Message = "No products found.";
        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
            return result;
        }

        public async Task GetProductsAsync()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/");
            Products = result.Data;
            CurrentPage = 1;
            PageCount = 0;
            if (Products.Count == 0)
                Message = "No Products found";
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                 await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
                 await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            if (result != null && result.Data != null)
                Products = result.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Products.Count == 0)
                Message = "No products found";

            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchProducts(string searchText,int page)
        {
            LastSearchText = searchText;
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/product/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Products.Count == 0) Message = "No product found.";
            ProductsChanged?.Invoke();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await _http.PutAsJsonAsync($"api/product", product);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<Product>>()).Data;
        }

        public async Task PageProducts(string Url, int page)
        {
            LastSearchText = Url;
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/product/list/{Url}/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Products.Count == 0) Message = "No product found.";
            ProductsChanged?.Invoke();
        }

        public async Task AdminPageProducts(int page)
        {
           
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/product/admin/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Products.Count == 0) Message = "No product found.";
            ProductsChanged?.Invoke();
        }

        public async Task AllPageProducts(int page)
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/product/all/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Products.Count == 0) Message = "No product found.";
            ProductsChanged?.Invoke();
        }

        //public async Task GetProductsBySub(string? subUrl = null)
        //{
        //    var result = subUrl == null ?
        //         await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
        //         await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/{subUrl}");
        //    if (result != null && result.Data != null)
        //        Products = result.Data;

        //    CurrentPage = 1;
        //    PageCount = 0;

        //    if (Products.Count == 0)
        //        Message = "No products found";

        //    ProductsChanged.Invoke();
        //}

    }
}

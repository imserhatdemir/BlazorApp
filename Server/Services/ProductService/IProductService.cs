﻿namespace BlazorApp.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl);
        Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
        Task<ServiceResponse<List<Product>>> GetFeatureProducts();
        Task<ServiceResponse<List<Product>>> GetAdminProducts();
        Task<ServiceResponse<Product>> CreateProduct(Product product);
        Task<ServiceResponse<Product>> UpdateProduct(Product product);
        Task<ServiceResponse<bool>> DeleteProduct(int Id);
        //Task<ServiceResponse<List<Product>>> GetProductBySubCategory(string suburl);
        Task<ServiceResponse<ProductSearchResult>> PageProducts(string Url, int page);
        Task<ServiceResponse<ProductSearchResult>> AdminPageProducts(int page);
        Task<ServiceResponse<ProductSearchResult>> AllPageProducts(int page);

    }
}

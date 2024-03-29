﻿namespace BlazorApp.Client.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        event Action OnChange;
        public List<ProductType> ProductTypes { get; set; }
        Task GetProductTypes();
        Task AddProductTypes(ProductType productType);
        Task UpdateProductTypes(ProductType productType);
        ProductType CreateNewProductType();
    }
}

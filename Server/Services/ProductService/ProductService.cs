﻿namespace BlazorApp.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService()
        {
        }

        public ProductService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<ProductSearchResult>> AdminPageProducts(int page)
        {
            var pageResults = 9f;
            var pageCount = Math.Ceiling((await FindProduct()).Count/ pageResults);
            var products = await _context.Products
                                .Where(p =>!p.Deleted)
                                .Select(p => new Product
                                {
                                    Title = p.Title,
                                    ID = p.ID,
                                    Images = p.Images,
                                    Variants = p.Variants,
                                    Visible = p.Visible,
                                    Featured = p.Featured
                                })
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<ProductSearchResult>
            {
                Data = new ProductSearchResult
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };
            
            return response;
        }

        public async Task<ServiceResponse<Product>> CreateProduct(Product product)
        {
            foreach (var variant in product.Variants)
            {
                variant.ProductType = null;
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Product> { Data = product };
        }

        public async Task<ServiceResponse<bool>> DeleteProduct(int Id)
        {
            var dbProduct = await _context.Products.FindAsync(Id);
            if (dbProduct == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Product not found"
                };
            }
            dbProduct.Deleted = true;
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<Product>>> GetAdminProducts()
        {

            var response = new ServiceResponse<List<Product>>();
            response.Data = await _context.Products
                .Where(p => !p.Deleted)
                .Select(p => new Product
                {
                    Title = p.Title,
                    ID=p.ID,
                    Variants = p.Variants,
                    Visible = p.Visible,
                    Featured = p.Featured
                })
                .ToListAsync();
            return response;
        }


        public async Task<ServiceResponse<List<Product>>> GetFeatureProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Where(p => p.Featured && p.Visible && !p.Deleted)
                .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                .Include(c => c.Images)
                .Include(a => a.Pdfs)
                .ToListAsync()
            };
            return response;   
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            Product product = null;
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.Products
                    .Include(p => p.Variants.Where(v => !v.Deleted))
                    .ThenInclude(v => v.ProductType)
                    .Include(c=>c.Images).Include(a => a.Pdfs)
                    .FirstOrDefaultAsync(p => p.ID == productId && !p.Deleted);

            }
            else
            {
               product = await _context.Products
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                    .ThenInclude(v => v.ProductType)
                    .Include(c => c.Images).Include(a => a.Pdfs)
                    .FirstOrDefaultAsync(p => p.ID == productId && !p.Deleted && p.Visible);

            }
            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist.";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products.Where(p => p.MainCategory.Url.ToLower().Equals(categoryUrl.ToLower())&& 
                p.Visible && !p.Deleted)
                .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                .Include(p => p.Images).Include(a => a.Pdfs)
                .ToListAsync()
            };
            return response;
        }

        //public async Task<ServiceResponse<List<Product>>> GetProductBySubCategory(string suburl)
        //{
        //    var response = new ServiceResponse<List<Product>>
        //    {
        //        Data = await _context.Products.Where(p => p.MainCategory.Url.ToLower().Equals(suburl.ToLower()) &&
        //        p.Visible && !p.Deleted)
        //       .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
        //       .Include(p => p.Images).Include(a => a.Pdfs)
        //       .ToListAsync()
        //    };
        //    return response;
        //}

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                    .Where(p => p.Visible && !p.Deleted)
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                    .Include(c => c.Images).Include(a => a.Pdfs)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<ProductSearchResult>> PageProducts(string Url, int page)
        {
            var pageResults = 9f;
            var pageCount = Math.Ceiling((await FindProductByUrl(Url)).Count / pageResults);
            var products = await _context.Products
                                .Where(p => p.MainCategory.Url.ToLower().Equals(Url.ToLower()) &&
                                    p.Visible && !p.Deleted)
                                .Select(p => new Product
                                {
                                    Title = p.Title,
                                    ID = p.ID,
                                    Variants = p.Variants,
                                    Images = p.Images
                                })
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<ProductSearchResult>
            {
                Data = new ProductSearchResult
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };

            return response;
        }

        public async Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page)
        {
            var pageResults = 9f;
            var pageCount = Math.Ceiling((await FindProductBySearchText(searchText)).Count / pageResults);
            var products = await _context.Products
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower()) ||
                                    p.Description.ToLower().Contains(searchText.ToLower()) &&
                                    p.Visible && !p.Deleted)
                                .Select(p => new Product
                                {
                                    Title = p.Title,
                                    ID = p.ID,
                                    Variants = p.Variants,
                                    Images = p.Images
                                })
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<ProductSearchResult>
            {
                Data = new ProductSearchResult
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };

            return response;
        }

        public async Task<ServiceResponse<Product>> UpdateProduct(Product product)
        {
            var dbProduct = await _context.Products
                .Include(p=>p.Images )
                .FirstOrDefaultAsync(p => p.ID == product.ID);
            if (dbProduct == null)
            {
                return new ServiceResponse<Product>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            dbProduct.Title = product.Title;
            dbProduct.Description = product.Description;
            dbProduct.ImageURL = product.ImageURL;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.MainCategoryId = product.MainCategoryId;
            dbProduct.Visible = product.Visible;
            dbProduct.Featured = product.Featured;
            dbProduct.WizardTitle = product.WizardTitle;
            dbProduct.WizardDesc = product.WizardDesc;
            dbProduct.WizardTitle1 = product.WizardTitle1;
            dbProduct.WizardDesc1 = product.WizardDesc1;
            dbProduct.WizardTitle2 = product.WizardTitle2;
            dbProduct.WizardDesc2 = product.WizardDesc2;
            dbProduct.WizardTitle3 = product.WizardTitle3;
            dbProduct.WizardDesc3 = product.WizardDesc3;
            dbProduct.WizardTitle4 = product.WizardTitle4;
            dbProduct.WizardDesc4 = product.WizardDesc4;
            dbProduct.KeyWords = product.KeyWords;



            var productImages = dbProduct.Images;
            _context.Images.RemoveRange(productImages);

            var productPdfs = dbProduct.Pdfs;
            _context.Pdfs.RemoveRange(productPdfs);

            dbProduct.Pdfs = product.Pdfs;
            dbProduct.Images = product.Images;

            foreach (var variant in product.Variants)
            {
                var dbVariant = await _context.ProductVariants
                    .SingleOrDefaultAsync(v => v.ProductId == variant.ProductId &&
                        v.ProductTypeId == variant.ProductTypeId);
                if (dbVariant == null)
                {
                    variant.ProductType = null;
                    _context.ProductVariants.Add(variant);
                }
                else
                {
                    dbVariant.ProductTypeId = variant.ProductTypeId;
                    dbVariant.Price = variant.Price;
                    dbVariant.OriginalPrice = variant.OriginalPrice;
                    dbVariant.Visible = variant.Visible;
                    dbVariant.Deleted = variant.Deleted;

                }
            }

           

            await _context.SaveChangesAsync();
            return new ServiceResponse<Product> { Data = product };
        }

        private async Task<List<Product>> FindProductBySearchText(string searchText)
        {
            return await _context.Products
                            .Where(p => p.Title.ToLower().Contains(searchText.ToLower())|| p.Description.ToLower().Contains(searchText.ToLower())
                            && p.Visible && !p.Deleted)
                            .Include(p => p.Variants).ToListAsync();
        }

        private async Task<List<Product>> FindProductByUrl(string searchText)
        {
            return await _context.Products
                            .Where(p => p.MainCategory.Url.ToLower().Equals(searchText.ToLower())
                            && p.Visible && !p.Deleted)
                            .Include(p => p.Variants)
                            .Include(p=>p.Images).ToListAsync();
        }
        private async Task<List<Product>> FindProduct()
        {
            return await _context.Products
                           .Where(p => !p.Deleted)
                    .Include(p => p.Variants.Where(v => !v.Deleted))
                    .ThenInclude(v => v.ProductType)
                    .Include(c => c.Images)
                    .Include(a => a.Pdfs).ToListAsync();
        }



        private async Task<List<Product>> AllFindProduct()
        {
            return await _context.Products
                           .Where(p =>p.Visible && !p.Deleted)
                    .Include(p => p.Variants.Where(v => !v.Deleted))
                    .ThenInclude(v => v.ProductType)
                    .Include(c => c.Images)
                    .Include(a => a.Pdfs).ToListAsync();
        }






        public async Task<ServiceResponse<ProductSearchResult>> AllPageProducts(int page)
        {
            //var pageResults = 9f;
            //var pageCount = Math.Ceiling((await AllFindProduct()).Count / pageResults);
            //var products = await _context.Products
            //                    .Where(p =>
            //                        p.Visible && !p.Deleted)
            //                    .Include(p => p.Variants)
            //                    .Include(c => c.Images).Include(a => a.Pdfs)
            //                    .Skip((page - 1) * (int)pageResults)
            //                    .Take((int)pageResults)
            //                    .ToListAsync();

            //var response = new ServiceResponse<ProductSearchResult>
            //{
            //    Data = new ProductSearchResult
            //    {
            //        Products = products,
            //        CurrentPage = page,
            //        Pages = (int)pageCount
            //    }
            //};

            //return response;
            var pageResults = 9f;
            var pageCount = Math.Ceiling((await AllFindProduct()).Count / pageResults);
            var products = await _context.Products
                                .Where(p =>
                                    p.Visible && !p.Deleted)
                                .Select(p => new Product
                                {
                                    Title = p.Title,
                                    ID = p.ID,
                                    Variants = p.Variants,
                                    Images = p.Images
                                })
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<ProductSearchResult>
            {
                Data = new ProductSearchResult
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };

            return response;
        }
    }
}

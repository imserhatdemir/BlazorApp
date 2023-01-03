using BlazorApp.Client.Pages.Admin;
using BlazorApp.Shared;
using Blazored.LocalStorage;

namespace BlazorApp.Client.Services.FavService
{
    public class FavService : IFavService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
        private readonly IAuthService _authService;

        public FavService(ILocalStorageService localStorage, HttpClient http, IAuthService authService)
        {
            _localStorage = localStorage;
            _http = http;
            _authService = authService;
        }


        public event Action OnChange;

        public async Task AddToFav(FavItem favItem)
        {
            if (await _authService.IsUserAuthenticated())
            {
                await _http.PostAsJsonAsync("api/fav/add", favItem);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<FavItem>>("fav");
                if (cart == null)
                {
                    cart = new List<FavItem>();
                }
                var sameItem = cart.Find(p => p.ProductId == favItem.ProductId);
                if (sameItem == null)
                {
                    cart.Add(favItem);
                }
                else
                {
                    sameItem.Quantity += favItem.Quantity;
                }


                await _localStorage.SetItemAsync("fav", cart);
            }
            await GetFavItemsCount();
        }

        public async Task GetFavItemsCount()
        {
            if (await _authService.IsUserAuthenticated())
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/fav/count");
                var count = result.Data;

                await _localStorage.SetItemAsync<int>("favItemsCount", count);

            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<FavItem>>("fav");
                await _localStorage.SetItemAsync<int>("favItemsCount", cart != null ? cart.Count : 0);
            }

            OnChange.Invoke();
        }

        public async Task<List<FavProductResponse>> GetFavProduct()
        {
            if (await _authService.IsUserAuthenticated())
            {
                var response = await _http.GetFromJsonAsync<ServiceResponse<List<FavProductResponse>>>("api/fav");
                return response.Data;
            }
            else
            {
                var cartItems = await _localStorage.GetItemAsync<List<FavItem>>("fav");
                if (cartItems == null)
                    return new List<FavProductResponse>();
                var response = await _http.PostAsJsonAsync("api/fav/products", cartItems);
                var cartProducts = await response.Content.ReadFromJsonAsync<ServiceResponse<List<FavProductResponse>>>();
                return cartProducts.Data;
            }
        }

        public async Task RemoveProductFromFav(int productId)
        {
            if (await _authService.IsUserAuthenticated())
            {
                await _http.DeleteAsync($"api/fav/{productId}");
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<FavItem>>("fav");
                if (cart == null)
                {
                    return;
                }


                var cartItem = cart.Find(x => x.ProductId == productId);
                if (cartItem != null)
                {
                    cart.Remove(cartItem);
                    await _localStorage.SetItemAsync("fav", cart);
                }
            }
        }

        public async Task StoreFavItems(bool emptyLocalCart)
        {
            var localCart = await _localStorage.GetItemAsync<List<FavItem>>("fav");
            if (localCart == null)
            {
                return;
            }

            await _http.PostAsJsonAsync("api/fav", localCart);

            if (emptyLocalCart)
            {
                await _localStorage.RemoveItemAsync("fav");
            }
        }

        public async Task UpdateQuantity(FavProductResponse product)
        {
            if (await _authService.IsUserAuthenticated())
            {
                var request = new CartItem
                {
                    ProductId = product.ProductId,
                    Quantity = product.Quantity
                };
                await _http.PutAsJsonAsync("api/fav/update-quantity", request);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<FavItem>>("fav");
                if (cart == null)
                {
                    return;
                }


                var cartItem = cart.Find(x => x.ProductId == product.ProductId);
                if (cartItem != null)
                {
                    cartItem.Quantity = product.Quantity;
                    await _localStorage.SetItemAsync("fav", cart);

                }
            }
        }
    }
}

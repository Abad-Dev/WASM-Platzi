using System.Text.Json;
using WASM_Platzi.Models;
namespace WASM_Platzi.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions options; 

    public ProductService( HttpClient httpClient)
    {
        _client = httpClient;
        options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<List<Product>> GetProductsAsync(string productLimit)
    {
        var response = await _client.GetAsync("products?limit="+productLimit);
        return await JsonSerializer.DeserializeAsync<List<Product>>(await response.Content.ReadAsStreamAsync(), options);
    }

    
}

public interface IProductService
{
    public Task<List<Product>> GetProductsAsync(string productLimit);
}
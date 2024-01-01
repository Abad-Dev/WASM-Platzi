using System.Net.Http.Json;
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

    public async Task<List<Product>> GetProductsAsync()
    {
        var response = await _client.GetAsync("products");
        return await JsonSerializer.DeserializeAsync<List<Product>>(await response.Content.ReadAsStreamAsync(), options);
    }

    public async Task Add(Product product)
    {
        var response = await _client.PostAsync("products", JsonContent.Create(product));
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }

    public async Task Delete(int productId)
    {
        var response = await _client.DeleteAsync($"products/{productId}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }
}

public interface IProductService
{
    public Task<List<Product>> GetProductsAsync();
    public Task Add(Product product);
    public Task Delete(int productId);
}
using System.Net.Http.Json;
using System.Text.Json;
using WASM_Platzi.Models;
namespace WASM_Platzi.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions options; 
    public List<Product> AddedProducts = new() {};

    public ProductService( HttpClient httpClient)
    {
        _client = httpClient;
        options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public List<Product> GetAddedProducts()
    {
        return AddedProducts;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var response = await _client.GetAsync("products");
        return await JsonSerializer.DeserializeAsync<List<Product>>(await response.Content.ReadAsStreamAsync(), options);
    }

    public async Task Add(Product product)
    {
        // Esta es la lógica que seguiría normalmente
        var response = await _client.PostAsync("products", JsonContent.Create(product));
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        // Esta es solo para que lo vea el usuario
        AddedProducts.Add(product);
    }
}

public interface IProductService
{
    public List<Product> GetAddedProducts();
    public Task<List<Product>> GetProductsAsync();
    public Task Add(Product product);
}
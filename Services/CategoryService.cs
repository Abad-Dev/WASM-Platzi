using System.Text.Json;
using WASM_Platzi.Models;
namespace WASM_Platzi.Services;

public class CategoryService : ICategoryService
{
      private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        public CategoryService(HttpClient client)
        {
            this.client = client;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<Category>> Get()
        {
            var response = await client.GetAsync("categories");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<Category>>(content, options);
        }
}

public interface ICategoryService
{
    public Task<List<Category>> Get();
}
using MultiCoreApp.MVC.DTOs;
using Newtonsoft.Json;

namespace MultiCoreApp.MVC.ApiServices
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<ProductDto> productDtos;
            var response = await _httpClient.GetAsync("product");
            if (response.IsSuccessStatusCode)
            {
                productDtos = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                productDtos = null!;
            }
            return productDtos!;
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"product/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync())!;
            }
            return null!;
        }

        public async Task<ProductDto> AddAsync(ProductDto proDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(proDto), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("product", stringContent);
            if (response.IsSuccessStatusCode)
            {
                proDto = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                proDto = null!;
            }
            return proDto!;
        }

        public async Task<bool> Update(ProductDto proDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(proDto), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("product", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}

﻿using MultiCoreApp.MVC.DTOs;
using Newtonsoft.Json;

namespace MultiCoreApp.MVC.ApiServices
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDtos;
            var response = await _httpClient.GetAsync("category");
            if (response.IsSuccessStatusCode)
            {
                categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                categoryDtos = null!;
            }
            return categoryDtos!;
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"category/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync())!;
            }
            return null!;
        }
        
        public async Task<CategoryDto> AddAsync(CategoryDto catDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(catDto), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("category", stringContent);
            if (response.IsSuccessStatusCode)
            {
                catDto = JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                catDto = null!;
            }
            return catDto;
        }

        public async Task<bool> Update(CategoryDto catDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(catDto), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("category", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        
    }
}

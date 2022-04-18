using MultiCoreApp.Core.Models;

namespace MultiCoreApp.API.DTOs
{
    public class CategoryWithProductsDto:CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}

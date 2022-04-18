using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.API.DTOs;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _catService;
        private IMapper _mapper;

        public CategoryController(ICategoryService catService, IMapper mapper)
        {
            _catService = catService;
            _mapper = mapper;
        }

        [HttpGet] //SELECT ISLEMLERI ICIN API'DE KULLANILAN KEYWORDTUR
        public async Task<IActionResult> GetAll()
        {
            var cat  =await _catService.GetAllAsync();
            //return Ok(cat);
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(cat));
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cat = await _catService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(cat));
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto catDto)
        {
            var newCat = await _catService.AddAsync(_mapper.Map<Category>(catDto));
            return Created(String.Empty, catDto);
            //_mapper.Map<CategoryDto>(newCat)
        }

        [HttpPut]
        public IActionResult Update(CategoryDto catDto)
        {
            var cat = _catService.Update(_mapper.Map<Category>(catDto));
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Remove(Guid id)
        {
            var cat = _catService.GetByIdAsync(id).Result;
            _catService.Remove(cat);
            return NoContent();
        }

        [HttpDelete("{name:alpha}")]
        public IActionResult RemoveByName(string name)
        {
            var cat = _catService.FirstOrDefaultAsync(s => s.Name == name).Result;
            _catService.Remove(cat);
            return NoContent();
        }

        [HttpGet("{id:guid}/products")]
        public async Task<IActionResult> GetWithProductWithId(Guid id)
        {
            var cat = await _catService.GetCategoryWithProductsAsync(id);
            return Ok(_mapper.Map<CategoryWithProductsDto>(cat));
        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.MVC.ApiServices;
using MultiCoreApp.MVC.DTOs;

namespace MultiCoreApp.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _catService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService catService, IMapper mapper, CategoryApiService categoryApiService)
        {
            _catService = catService;
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }
        
        public async Task<IActionResult> Index()
        {
            //var categories = await _catService.GetAllAsync();

            IEnumerable<CategoryDto> cat = await _categoryApiService.GetAllAsync();

            //return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
            return View(cat);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto catDto)
        {
            await _categoryApiService.AddAsync(catDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var cat = await _categoryApiService.GetByIdAsync(id);
            return View(cat);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto catDto)
        {
            await _categoryApiService.Update(catDto);
            return RedirectToAction("Index");
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.MVC.ApiServices;
using MultiCoreApp.MVC.DTOs;

namespace MultiCoreApp.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ProductApiService _productApiService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ProductApiService productApiService, IMapper mapper)
        {
            _productService = productService;
            _productApiService = productApiService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            //var categories = await _catService.GetAllAsync();

            IEnumerable<ProductDto> pro = await _productApiService.GetAllAsync();

            //return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
            return View(pro);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto proDto)
        {
            await _productApiService.AddAsync(proDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var pro = await _productApiService.GetByIdAsync(id);
            return View(pro);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDto proDto)
        {
            await _productApiService.Update(proDto);
            return RedirectToAction("Index");
        }
    }
}

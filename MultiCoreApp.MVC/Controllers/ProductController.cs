using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiCoreApp.MVC.ApiServices;
using MultiCoreApp.MVC.DTOs;

namespace MultiCoreApp.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;

        public ProductController(ProductApiService productApiService, CategoryApiService categoryApiService)
        {
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
        }
        public async Task<IActionResult> Index()
        {
            //var categories = await _catService.GetAllAsync();

            var pro = await _productApiService.GetAllAsyncWithCategory();

            //return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
            return View(pro);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _productApiService.GetByIdForDetailsAsync(id);
            return View(product);
        }

        public IActionResult Create()
        {

            var cat = _categoryApiService.GetAllAsync().Result;
            ViewData["CategoryId"] = new SelectList(cat, "Id", "Name");


            //ViewBag.Categories = _categoryApiService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductWithCategoryDto proDto)
        {

            

            if (ModelState.IsValid)
            {
                await _productApiService.AddAsync(proDto);
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_categoryApiService.GetAllAsync().Result, "Id", "Name",proDto.CategoryId);
            //ViewBag.Categories = _categoryApiService.GetAllAsync();
            //ViewBag.CategoryId = proDto.CategoryId;
            return View(proDto);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var proDto = await _productApiService.GetByIdAsync(id);
            ViewData["CategoryId"] = new SelectList(_categoryApiService.GetAllAsync().Result, "Id", "Name", proDto.CategoryId);
            //ViewBag.Categories = _categoryApiService.GetAllAsync();
            //ViewBag.CategoryName = proDto.CategoryId;
            return View(proDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDto proDto)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.Update(proDto);
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_categoryApiService.GetAllAsync().Result, "Id", "Name", proDto.CategoryId);
            return View(proDto);
        }

        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var proDto = await _productApiService.;
        //}


    }
}

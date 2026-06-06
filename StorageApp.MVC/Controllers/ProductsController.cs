using Microsoft.AspNetCore.Mvc;
using StorageApp.BLL.Interfaces;
using StorageApp.MVC.Models;

namespace StorageApp.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var product = new StorageApp.DAL.Models.Product
            {
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId
            };

            await _productService.CreateAsync(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            var model = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var product = await _productService.GetByIdAsync(model.Id);

            if (product == null)
                return NotFound();

            product.Name = model.Name;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;

            await _productService.UpdateAsync(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            var model = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            await _productService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}

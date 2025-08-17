using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ecommerce.Models;
using ecommerce.Repositories;
using ecommerce.Models.ViewModels;

namespace ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return Json(new { data = products });
        }

        // GET: Admin/Products
        public IActionResult Index()
        {
            return View();
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    IsActive = model.IsActive
                };

                await _productRepository.AddAsync(product);
                return Json(new { success = true, message = "Product added successfully!" });
            }
            return Json(new { success = false, message = "Failed to add product." });
        }
    }
}
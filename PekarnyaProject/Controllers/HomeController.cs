using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PekarnyaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace PekarnyaProject.Controllers
{
    
    public class HomeController : Controller

    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Products()

        {
            var products = new List<Product>
  
         {
        new Product { Id = 1, Name = "Житній хліб", Price = 45.00m, Description = "Традиційний хліб на заквасці" },
        new Product { Id = 2, Name = "Круасан", Price = 35.50m, Description = "Свіжа випічка з маслом" },
        new Product { Id = 3, Name = "Багет Французький", Price = 30.00m, Description = "Хрустка скоринка" },
        new Product { Id = 4, Name = "Пампушки", Price = 50.00m, Description = "Приголомшливий смак" },
        new Product { Id = 5, Name = "Булочки для бургерів", Price = 55.00m, Description = "М'якенькі та свіженькі" },
        new Product { Id = 6, Name = "Булочки для хот - догів", Price = 45.00m, Description = "Чудово підійдуть для приготування хот - догів" },


            };  
            return View(products);
        }

        // 1. Оголошуємо змінну контексту
        private readonly ApplicationDbContext _context;

        // 2. Створюємо конструктор, який отримує контекст від системи
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult UpdateProductInline(Product updatedProduct)
        {
            var product = _context.Products.Find(updatedProduct.Id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                product.Count = updatedProduct.Count;
                _context.SaveChanges();
            }
            return RedirectToAction("Products"); // Сторінка просто оновиться з новими даними
        }

    }
}
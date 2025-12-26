using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PekarnyaProject.Models;
using PekarnyaProject.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace PekarnyaProject.Controllers
{
    public class CartController : Controller
    {
        // Підключення до бази даних
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Відображення кошика
        public IActionResult Index()
        {
            string sessionId = HttpContext.Session.Id;

            var cart = _context.CartItems
                .Where(x => x.SessionId == sessionId)
                .Include(x => x.Product)
                .ToList();

            return View(cart);
        }


        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            string sessionId = HttpContext.Session.Id;

            var item = _context.CartItems
                .FirstOrDefault(x => x.ProductId == productId && x.SessionId == sessionId);

            if (item == null)
            {
                _context.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    SessionId = sessionId,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }

            _context.SaveChanges();

            TempData["CartMessage"] = "Товар успішно додано до кошика!";
            return RedirectToAction("Products", "Home");
        }

    }
}
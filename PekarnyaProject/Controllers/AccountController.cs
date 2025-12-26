using Microsoft.AspNetCore.Mvc;
using PekarnyaProject.Models;
using Microsoft.AspNetCore.Http; // Потрібно для роботи з сесією

namespace PekarnyaProject.Controllers
{
    public class AccountController : Controller
    {
        // Показує сторінку входу
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Обробляє дані з форми входу
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("UserRole", "User"); // Або "Admin"
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Неправильний логін або пароль!";
            return View(model);

          
        }


        // Вихід із системи
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserRole");
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(LoginViewModel model)
        {
            // Для курсової: імітуємо успішну реєстрацію
            if (ModelState.IsValid)
            {
                // Можна додати логіку збереження, але для захисту достатньо 
                // просто перенаправити на логін з повідомленням про успіх
                TempData["Success"] = "Реєстрація успішна! Тепер ви можете увійти.";
                return RedirectToAction("Login");
            }
            return View(model);
        }

    }
}
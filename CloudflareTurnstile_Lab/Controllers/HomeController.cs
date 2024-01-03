using CloudflareTurnstile_Lab.Models;
using CloudflareTurnstile_Lab.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CloudflareTurnstile_Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CaptchaService _captchaService;

        public HomeController(ILogger<HomeController> logger, CaptchaService captchaService)
        {
            _logger = logger;
            _captchaService = captchaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CloudflareTurnstile()
        {
            return View();
        }
        public IActionResult GoogleRecaptcha()
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
    }
}